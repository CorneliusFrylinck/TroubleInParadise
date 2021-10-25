using Microsoft.EntityFrameworkCore.Migrations;
using System;

#nullable disable

namespace TroubleInParadise.Data.Migrations
{
    public partial class Initial_Creation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "buildingTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_buildingTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "buildingUpgrades",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UpgradeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_buildingUpgrades", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "effects",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Value = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_effects", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "locations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    X = table.Column<int>(type: "int", nullable: false),
                    Y = table.Column<int>(type: "int", nullable: false),
                    Z = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_locations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "playerTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_playerTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "resourceCollections",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_resourceCollections", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "servers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ReleaseDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CloseDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_servers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Gold = table.Column<int>(type: "int", nullable: false),
                    NetUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "resources",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CostId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Value = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_resources", x => x.Id);
                    table.ForeignKey(
                        name: "FK_resources_resourceCollections_CostId",
                        column: x => x.CostId,
                        principalTable: "resourceCollections",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "upgrades",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CostId = table.Column<int>(type: "int", nullable: true),
                    EffectChange = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_upgrades", x => x.Id);
                    table.ForeignKey(
                        name: "FK_upgrades_resourceCollections_CostId",
                        column: x => x.CostId,
                        principalTable: "resourceCollections",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "player",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ServerId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    Last_Seen = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Last_Updated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PlayerTypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_player", x => x.Id);
                    table.ForeignKey(
                        name: "FK_player_servers_ServerId",
                        column: x => x.ServerId,
                        principalTable: "servers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "bases",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlayerId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LocationId = table.Column<int>(type: "int", nullable: false),
                    BaseId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_bases", x => x.Id);
                    table.ForeignKey(
                        name: "FK_bases_player_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "player",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_bases_resourceCollections_BaseId",
                        column: x => x.BaseId,
                        principalTable: "resourceCollections",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "buildings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BaseId = table.Column<int>(type: "int", nullable: false),
                    BuildingTypeID = table.Column<int>(type: "int", nullable: false),
                    EffectId = table.Column<int>(type: "int", nullable: true),
                    Level = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_buildings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_buildings_bases_BaseId",
                        column: x => x.BaseId,
                        principalTable: "bases",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_buildings_buildingTypes_BuildingTypeID",
                        column: x => x.BuildingTypeID,
                        principalTable: "buildingTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_buildings_effects_EffectId",
                        column: x => x.EffectId,
                        principalTable: "effects",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_bases_BaseId",
                table: "bases",
                column: "BaseId");

            migrationBuilder.CreateIndex(
                name: "IX_bases_PlayerId",
                table: "bases",
                column: "PlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_buildings_BaseId",
                table: "buildings",
                column: "BaseId");

            migrationBuilder.CreateIndex(
                name: "IX_buildings_BuildingTypeID",
                table: "buildings",
                column: "BuildingTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_buildings_EffectId",
                table: "buildings",
                column: "EffectId");

            migrationBuilder.CreateIndex(
                name: "IX_player_ServerId",
                table: "player",
                column: "ServerId");

            migrationBuilder.CreateIndex(
                name: "IX_resources_CostId",
                table: "resources",
                column: "CostId");

            migrationBuilder.CreateIndex(
                name: "IX_upgrades_CostId",
                table: "upgrades",
                column: "CostId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "buildings");

            migrationBuilder.DropTable(
                name: "buildingUpgrades");

            migrationBuilder.DropTable(
                name: "locations");

            migrationBuilder.DropTable(
                name: "playerTypes");

            migrationBuilder.DropTable(
                name: "resources");

            migrationBuilder.DropTable(
                name: "upgrades");

            migrationBuilder.DropTable(
                name: "users");

            migrationBuilder.DropTable(
                name: "bases");

            migrationBuilder.DropTable(
                name: "buildingTypes");

            migrationBuilder.DropTable(
                name: "effects");

            migrationBuilder.DropTable(
                name: "player");

            migrationBuilder.DropTable(
                name: "resourceCollections");

            migrationBuilder.DropTable(
                name: "servers");
        }
    }
}
