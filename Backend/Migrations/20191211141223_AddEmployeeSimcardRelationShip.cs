using Microsoft.EntityFrameworkCore.Migrations;

namespace mmbm.Migrations
{
    public partial class AddEmployeeSimcardRelationShip : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EmployeeId",
                table: "Simcards",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Simcards_EmployeeId",
                table: "Simcards",
                column: "EmployeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Simcards_Employees_EmployeeId",
                table: "Simcards",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Simcards_Employees_EmployeeId",
                table: "Simcards");

            migrationBuilder.DropIndex(
                name: "IX_Simcards_EmployeeId",
                table: "Simcards");

            migrationBuilder.DropColumn(
                name: "EmployeeId",
                table: "Simcards");
        }
    }
}
