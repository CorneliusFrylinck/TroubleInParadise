using Microsoft.EntityFrameworkCore.Migrations;
using System;

#nullable disable

namespace TroubleInParadise.Data.Migrations
{
    public partial class added_events : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Event",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TimeStamp = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EffectId = table.Column<int>(type: "int", nullable: true),
                    IsPermanent = table.Column<bool>(type: "bit", nullable: false),
                    EventId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Event", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Event_bases_EventId",
                        column: x => x.EventId,
                        principalTable: "bases",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Event_buildings_EventId",
                        column: x => x.EventId,
                        principalTable: "buildings",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Event_effects_EffectId",
                        column: x => x.EffectId,
                        principalTable: "effects",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Event_player_EventId",
                        column: x => x.EventId,
                        principalTable: "player",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Event_EffectId",
                table: "Event",
                column: "EffectId");

            migrationBuilder.CreateIndex(
                name: "IX_Event_EventId",
                table: "Event",
                column: "EventId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Event");
        }
    }
}
