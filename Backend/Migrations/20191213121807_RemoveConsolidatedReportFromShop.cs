using Microsoft.EntityFrameworkCore.Migrations;

namespace mmbm.Migrations
{
    public partial class RemoveConsolidatedReportFromShop : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ConsolidatedReports_Shops_ShopId",
                table: "ConsolidatedReports");

            migrationBuilder.DropIndex(
                name: "IX_ConsolidatedReports_ShopId",
                table: "ConsolidatedReports");

            migrationBuilder.DropColumn(
                name: "ShopId",
                table: "ConsolidatedReports");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ShopId",
                table: "ConsolidatedReports",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ConsolidatedReports_ShopId",
                table: "ConsolidatedReports",
                column: "ShopId");

            migrationBuilder.AddForeignKey(
                name: "FK_ConsolidatedReports_Shops_ShopId",
                table: "ConsolidatedReports",
                column: "ShopId",
                principalTable: "Shops",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
