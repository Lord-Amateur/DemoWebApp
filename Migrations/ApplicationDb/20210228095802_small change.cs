using Microsoft.EntityFrameworkCore.Migrations;

namespace DemoWebApp.Migrations.ApplicationDb
{
    public partial class smallchange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<float>(
                name: "Net",
                table: "Sales",
                nullable: false,
                defaultValue: 0f);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Net",
                table: "Sales");
        }
    }
}
