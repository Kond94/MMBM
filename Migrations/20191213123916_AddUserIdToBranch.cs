using Microsoft.EntityFrameworkCore.Migrations;

namespace mmbm.Migrations
{
    public partial class AddUserIdToBranch : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Branches",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Branches");
        }
    }
}
