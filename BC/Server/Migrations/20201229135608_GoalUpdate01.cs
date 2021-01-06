using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BC.Server.Migrations
{
    public partial class GoalUpdate01 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DateCompleted",
                table: "Goals",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateIndex(
                name: "IX_Goals_Difficulty",
                table: "Goals",
                column: "Difficulty");

            migrationBuilder.CreateIndex(
                name: "IX_Goals_ExpectedDeadline",
                table: "Goals",
                column: "ExpectedDeadline");

            migrationBuilder.CreateIndex(
                name: "IX_Goals_IsCompleted",
                table: "Goals",
                column: "IsCompleted");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Goals_Difficulty",
                table: "Goals");

            migrationBuilder.DropIndex(
                name: "IX_Goals_ExpectedDeadline",
                table: "Goals");

            migrationBuilder.DropIndex(
                name: "IX_Goals_IsCompleted",
                table: "Goals");

            migrationBuilder.DropColumn(
                name: "DateCompleted",
                table: "Goals");
        }
    }
}
