using Microsoft.EntityFrameworkCore.Migrations;

namespace YoAdopto.API.Migrations
{
    public partial class AddEndedToPublication : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "PublicationEnded",
                table: "Publications",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PublicationEnded",
                table: "Publications");
        }
    }
}
