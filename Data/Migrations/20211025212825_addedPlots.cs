using Microsoft.EntityFrameworkCore.Migrations;

namespace TroubleInParadise.Data.Migrations
{
    public partial class addedPlots : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Plot_Type",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ResourceCollectionId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Plot_Type", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Plot_Type_resourceCollections_ResourceCollectionId",
                        column: x => x.ResourceCollectionId,
                        principalTable: "resourceCollections",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Server_Plots",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ServerId = table.Column<int>(type: "int", nullable: false),
                    PlotTypeId = table.Column<int>(type: "int", nullable: true),
                    startLocationId = table.Column<int>(type: "int", nullable: true),
                    endLocationId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Server_Plots", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Server_Plots_locations_endLocationId",
                        column: x => x.endLocationId,
                        principalTable: "locations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Server_Plots_locations_startLocationId",
                        column: x => x.startLocationId,
                        principalTable: "locations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Server_Plots_Plot_Type_PlotTypeId",
                        column: x => x.PlotTypeId,
                        principalTable: "Plot_Type",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Server_Plots_servers_ServerId",
                        column: x => x.ServerId,
                        principalTable: "servers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Plot_Type_ResourceCollectionId",
                table: "Plot_Type",
                column: "ResourceCollectionId");

            migrationBuilder.CreateIndex(
                name: "IX_Server_Plots_endLocationId",
                table: "Server_Plots",
                column: "endLocationId");

            migrationBuilder.CreateIndex(
                name: "IX_Server_Plots_PlotTypeId",
                table: "Server_Plots",
                column: "PlotTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Server_Plots_ServerId",
                table: "Server_Plots",
                column: "ServerId");

            migrationBuilder.CreateIndex(
                name: "IX_Server_Plots_startLocationId",
                table: "Server_Plots",
                column: "startLocationId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Server_Plots");

            migrationBuilder.DropTable(
                name: "Plot_Type");
        }
    }
}
