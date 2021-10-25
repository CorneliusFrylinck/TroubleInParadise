using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TroubleInParadise.Data.Migrations
{
    public partial class updateResources : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_resources_resourceCollections_CostId",
                table: "resources");

            migrationBuilder.DropIndex(
                name: "IX_resources_CostId",
                table: "resources");

            migrationBuilder.DropColumn(
                name: "CostId",
                table: "resources");

            migrationBuilder.AddColumn<int>(
                name: "ResourceId",
                table: "resources",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_resources_ResourceId",
                table: "resources",
                column: "ResourceId");

            migrationBuilder.AddForeignKey(
                name: "FK_resources_resourceCollections_ResourceId",
                table: "resources",
                column: "ResourceId",
                principalTable: "resourceCollections",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_resources_resourceCollections_ResourceId",
                table: "resources");

            migrationBuilder.DropIndex(
                name: "IX_resources_ResourceId",
                table: "resources");

            migrationBuilder.DropColumn(
                name: "ResourceId",
                table: "resources");

            migrationBuilder.AddColumn<int>(
                name: "CostId",
                table: "resources",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_resources_CostId",
                table: "resources",
                column: "CostId");

            migrationBuilder.AddForeignKey(
                name: "FK_resources_resourceCollections_CostId",
                table: "resources",
                column: "CostId",
                principalTable: "resourceCollections",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
