using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DemoWebApp.Migrations.ApplicationDb
{
    public partial class MedicineDetailsModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MedicineDetails",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BatchNo = table.Column<string>(nullable: false),
                    Quantity = table.Column<int>(nullable: false),
                    Rate = table.Column<float>(nullable: false),
                    ManufactureDate = table.Column<DateTime>(nullable: false),
                    ExpiryDate = table.Column<DateTime>(nullable: false),
                    MedicineRefId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicineDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MedicineDetails_Medicine_MedicineRefId",
                        column: x => x.MedicineRefId,
                        principalTable: "Medicine",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MedicineDetails_MedicineRefId",
                table: "MedicineDetails",
                column: "MedicineRefId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MedicineDetails");
        }
    }
}
