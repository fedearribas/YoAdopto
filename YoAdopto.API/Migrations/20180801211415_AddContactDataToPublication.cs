using Microsoft.EntityFrameworkCore.Migrations;

namespace YoAdopto.API.Migrations
{
    public partial class AddContactDataToPublication : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ContactEmail",
                table: "Publications",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ContactPhone",
                table: "Publications",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ContactEmail",
                table: "Publications");

            migrationBuilder.DropColumn(
                name: "ContactPhone",
                table: "Publications");
        }
    }
}
