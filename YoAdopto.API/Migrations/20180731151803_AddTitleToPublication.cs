using Microsoft.EntityFrameworkCore.Migrations;

namespace YoAdopto.API.Migrations
{
    public partial class AddTitleToPublication : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Publications",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Title",
                table: "Publications");
        }
    }
}
