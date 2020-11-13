using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace mmbm.Migrations
{
    public partial class RenameKioskToShop : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ConsolidatedReport_Employees_EmployeeId",
                table: "ConsolidatedReport");

            migrationBuilder.DropForeignKey(
                name: "FK_ConsolidatedReport_Kiosks_KioskId",
                table: "ConsolidatedReport");

            migrationBuilder.DropForeignKey(
                name: "FK_MobileMoneyReport_ConsolidatedReport_ConsolidatedReportId",
                table: "MobileMoneyReport");

            migrationBuilder.DropTable(
                name: "Kiosks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MobileMoneyReport",
                table: "MobileMoneyReport");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ConsolidatedReport",
                table: "ConsolidatedReport");

            migrationBuilder.DropIndex(
                name: "IX_ConsolidatedReport_KioskId",
                table: "ConsolidatedReport");

            migrationBuilder.DropColumn(
                name: "KioskId",
                table: "ConsolidatedReport");

            migrationBuilder.RenameTable(
                name: "MobileMoneyReport",
                newName: "MobileMoneyReports");

            migrationBuilder.RenameTable(
                name: "ConsolidatedReport",
                newName: "ConsolidatedReports");

            migrationBuilder.RenameIndex(
                name: "IX_MobileMoneyReport_ConsolidatedReportId",
                table: "MobileMoneyReports",
                newName: "IX_MobileMoneyReports_ConsolidatedReportId");

            migrationBuilder.RenameIndex(
                name: "IX_ConsolidatedReport_EmployeeId",
                table: "ConsolidatedReports",
                newName: "IX_ConsolidatedReports_EmployeeId");

            migrationBuilder.AddColumn<int>(
                name: "ShopId",
                table: "ConsolidatedReports",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_MobileMoneyReports",
                table: "MobileMoneyReports",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ConsolidatedReports",
                table: "ConsolidatedReports",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Shops",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(nullable: true),
                    BranchId = table.Column<int>(nullable: false),
                    EmployeeId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shops", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Shops_Branches_BranchId",
                        column: x => x.BranchId,
                        principalTable: "Branches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Shops_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ConsolidatedReports_ShopId",
                table: "ConsolidatedReports",
                column: "ShopId");

            migrationBuilder.CreateIndex(
                name: "IX_Shops_BranchId",
                table: "Shops",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_Shops_EmployeeId",
                table: "Shops",
                column: "EmployeeId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ConsolidatedReports_Employees_EmployeeId",
                table: "ConsolidatedReports",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ConsolidatedReports_Shops_ShopId",
                table: "ConsolidatedReports",
                column: "ShopId",
                principalTable: "Shops",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MobileMoneyReports_ConsolidatedReports_ConsolidatedReportId",
                table: "MobileMoneyReports",
                column: "ConsolidatedReportId",
                principalTable: "ConsolidatedReports",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ConsolidatedReports_Employees_EmployeeId",
                table: "ConsolidatedReports");

            migrationBuilder.DropForeignKey(
                name: "FK_ConsolidatedReports_Shops_ShopId",
                table: "ConsolidatedReports");

            migrationBuilder.DropForeignKey(
                name: "FK_MobileMoneyReports_ConsolidatedReports_ConsolidatedReportId",
                table: "MobileMoneyReports");

            migrationBuilder.DropTable(
                name: "Shops");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MobileMoneyReports",
                table: "MobileMoneyReports");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ConsolidatedReports",
                table: "ConsolidatedReports");

            migrationBuilder.DropIndex(
                name: "IX_ConsolidatedReports_ShopId",
                table: "ConsolidatedReports");

            migrationBuilder.DropColumn(
                name: "ShopId",
                table: "ConsolidatedReports");

            migrationBuilder.RenameTable(
                name: "MobileMoneyReports",
                newName: "MobileMoneyReport");

            migrationBuilder.RenameTable(
                name: "ConsolidatedReports",
                newName: "ConsolidatedReport");

            migrationBuilder.RenameIndex(
                name: "IX_MobileMoneyReports_ConsolidatedReportId",
                table: "MobileMoneyReport",
                newName: "IX_MobileMoneyReport_ConsolidatedReportId");

            migrationBuilder.RenameIndex(
                name: "IX_ConsolidatedReports_EmployeeId",
                table: "ConsolidatedReport",
                newName: "IX_ConsolidatedReport_EmployeeId");

            migrationBuilder.AddColumn<int>(
                name: "KioskId",
                table: "ConsolidatedReport",
                type: "integer",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_MobileMoneyReport",
                table: "MobileMoneyReport",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ConsolidatedReport",
                table: "ConsolidatedReport",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Kiosks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    BranchId = table.Column<int>(type: "integer", nullable: false),
                    EmployeeId = table.Column<int>(type: "integer", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kiosks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Kiosks_Branches_BranchId",
                        column: x => x.BranchId,
                        principalTable: "Branches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Kiosks_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ConsolidatedReport_KioskId",
                table: "ConsolidatedReport",
                column: "KioskId");

            migrationBuilder.CreateIndex(
                name: "IX_Kiosks_BranchId",
                table: "Kiosks",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_Kiosks_EmployeeId",
                table: "Kiosks",
                column: "EmployeeId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ConsolidatedReport_Employees_EmployeeId",
                table: "ConsolidatedReport",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ConsolidatedReport_Kiosks_KioskId",
                table: "ConsolidatedReport",
                column: "KioskId",
                principalTable: "Kiosks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MobileMoneyReport_ConsolidatedReport_ConsolidatedReportId",
                table: "MobileMoneyReport",
                column: "ConsolidatedReportId",
                principalTable: "ConsolidatedReport",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
