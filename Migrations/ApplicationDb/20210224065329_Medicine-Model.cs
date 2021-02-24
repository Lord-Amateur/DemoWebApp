using Microsoft.EntityFrameworkCore.Migrations;

namespace DemoWebApp.Migrations.ApplicationDb
{
    public partial class MedicineModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Medicine",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    GenericName = table.Column<string>(nullable: false),
                    Unit = table.Column<string>(nullable: false),
                    Place = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medicine", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Medicine");
        }
    }
}
