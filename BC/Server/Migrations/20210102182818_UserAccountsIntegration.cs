using Microsoft.EntityFrameworkCore.Migrations;

namespace BC.Server.Migrations
{
    public partial class UserAccountsIntegration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "OwnerId",
                table: "Goals",
                type: "int",
                nullable: false,
                defaultValue: 0);

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
                    AvatarUrl = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserProfiles", x => x.UserProfileId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Goals_OwnerId",
                table: "Goals",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_UserProfiles_EmailAddress",
                table: "UserProfiles",
                column: "EmailAddress",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Goals_UserProfiles_OwnerId",
                table: "Goals",
                column: "OwnerId",
                principalTable: "UserProfiles",
                principalColumn: "UserProfileId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Goals_UserProfiles_OwnerId",
                table: "Goals");

            migrationBuilder.DropTable(
                name: "UserProfiles");

            migrationBuilder.DropIndex(
                name: "IX_Goals_OwnerId",
                table: "Goals");

            migrationBuilder.DropColumn(
                name: "OwnerId",
                table: "Goals");
        }
    }
}
