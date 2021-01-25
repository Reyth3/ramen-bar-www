using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BC.Server.Migrations
{
    public partial class InitialSetup : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MenuItems",
                columns: table => new
                {
                    MenuItemId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ItemName = table.Column<string>(type: "nvarchar(96)", maxLength: 96, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Price = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MenuItems", x => x.MenuItemId);
                });

            migrationBuilder.CreateTable(
                name: "UserProfiles",
                columns: table => new
                {
                    UserProfileId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmailAddress = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(48)", maxLength: 48, nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false),
                    IsEditor = table.Column<bool>(type: "bit", maxLength: 128, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserProfiles", x => x.UserProfileId);
                });

            migrationBuilder.CreateTable(
                name: "Goals",
                columns: table => new
                {
                    AnnouncementId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Preview = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Text = table.Column<string>(type: "nvarchar(max)", maxLength: 5000, nullable: true),
                    Thumbnail = table.Column<byte[]>(type: "varbinary(max)", maxLength: 1048576, nullable: true),
                    PostingDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    AuthorUserProfileId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Goals", x => x.AnnouncementId);
                    table.ForeignKey(
                        name: "FK_Goals_UserProfiles_AuthorUserProfileId",
                        column: x => x.AuthorUserProfileId,
                        principalTable: "UserProfiles",
                        principalColumn: "UserProfileId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Reservations",
                columns: table => new
                {
                    ReservationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReservationTime = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    GuestsNumber = table.Column<int>(type: "int", nullable: false),
                    OwnerUserProfileId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservations", x => x.ReservationId);
                    table.ForeignKey(
                        name: "FK_Reservations_UserProfiles_OwnerUserProfileId",
                        column: x => x.OwnerUserProfileId,
                        principalTable: "UserProfiles",
                        principalColumn: "UserProfileId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Goals_AuthorUserProfileId",
                table: "Goals",
                column: "AuthorUserProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_Goals_PostingDate",
                table: "Goals",
                column: "PostingDate");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_GuestsNumber",
                table: "Reservations",
                column: "GuestsNumber");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_OwnerUserProfileId",
                table: "Reservations",
                column: "OwnerUserProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_ReservationTime",
                table: "Reservations",
                column: "ReservationTime");

            migrationBuilder.CreateIndex(
                name: "IX_UserProfiles_EmailAddress",
                table: "UserProfiles",
                column: "EmailAddress",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Goals");

            migrationBuilder.DropTable(
                name: "MenuItems");

            migrationBuilder.DropTable(
                name: "Reservations");

            migrationBuilder.DropTable(
                name: "UserProfiles");
        }
    }
}
