using Microsoft.EntityFrameworkCore.Migrations;

namespace BC.Server.Migrations
{
    public partial class AnnouncementFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Goals_UserProfiles_AuthorUserProfileId",
                table: "Goals");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Goals",
                table: "Goals");

            migrationBuilder.RenameTable(
                name: "Goals",
                newName: "Announcements");

            migrationBuilder.RenameIndex(
                name: "IX_Goals_PostingDate",
                table: "Announcements",
                newName: "IX_Announcements_PostingDate");

            migrationBuilder.RenameIndex(
                name: "IX_Goals_AuthorUserProfileId",
                table: "Announcements",
                newName: "IX_Announcements_AuthorUserProfileId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Announcements",
                table: "Announcements",
                column: "AnnouncementId");

            migrationBuilder.AddForeignKey(
                name: "FK_Announcements_UserProfiles_AuthorUserProfileId",
                table: "Announcements",
                column: "AuthorUserProfileId",
                principalTable: "UserProfiles",
                principalColumn: "UserProfileId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Announcements_UserProfiles_AuthorUserProfileId",
                table: "Announcements");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Announcements",
                table: "Announcements");

            migrationBuilder.RenameTable(
                name: "Announcements",
                newName: "Goals");

            migrationBuilder.RenameIndex(
                name: "IX_Announcements_PostingDate",
                table: "Goals",
                newName: "IX_Goals_PostingDate");

            migrationBuilder.RenameIndex(
                name: "IX_Announcements_AuthorUserProfileId",
                table: "Goals",
                newName: "IX_Goals_AuthorUserProfileId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Goals",
                table: "Goals",
                column: "AnnouncementId");

            migrationBuilder.AddForeignKey(
                name: "FK_Goals_UserProfiles_AuthorUserProfileId",
                table: "Goals",
                column: "AuthorUserProfileId",
                principalTable: "UserProfiles",
                principalColumn: "UserProfileId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
