using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace YoAdopto.API.Migrations
{
    public partial class RemovedWorkflowTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Publications_PublicationWorkflows_PublicationWorkflowId",
                table: "Publications");

            migrationBuilder.DropTable(
                name: "PublicationWorkflows");

            migrationBuilder.DropIndex(
                name: "IX_Publications_PublicationWorkflowId",
                table: "Publications");

            migrationBuilder.DropColumn(
                name: "PublicationWorkflowId",
                table: "Publications");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PublicationWorkflowId",
                table: "Publications",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "PublicationWorkflows",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Active = table.Column<bool>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    PublicationTypeId = table.Column<int>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PublicationWorkflows", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PublicationWorkflows_PublicationTypes_PublicationTypeId",
                        column: x => x.PublicationTypeId,
                        principalTable: "PublicationTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Publications_PublicationWorkflowId",
                table: "Publications",
                column: "PublicationWorkflowId");

            migrationBuilder.CreateIndex(
                name: "IX_PublicationWorkflows_PublicationTypeId",
                table: "PublicationWorkflows",
                column: "PublicationTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Publications_PublicationWorkflows_PublicationWorkflowId",
                table: "Publications",
                column: "PublicationWorkflowId",
                principalTable: "PublicationWorkflows",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
