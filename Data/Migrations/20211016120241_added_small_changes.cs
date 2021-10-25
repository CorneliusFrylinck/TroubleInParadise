using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TroubleInParadise.Data.Migrations
{
    public partial class added_small_changes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Event_bases_EventId",
                table: "Event");

            migrationBuilder.DropForeignKey(
                name: "FK_Event_buildings_EventId",
                table: "Event");

            migrationBuilder.DropForeignKey(
                name: "FK_Event_effects_EffectId",
                table: "Event");

            migrationBuilder.DropForeignKey(
                name: "FK_Event_player_EventId",
                table: "Event");

            migrationBuilder.DropForeignKey(
                name: "FK_upgrades_resourceCollections_CostId",
                table: "upgrades");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Event",
                table: "Event");

            migrationBuilder.RenameTable(
                name: "Event",
                newName: "events");

            migrationBuilder.RenameIndex(
                name: "IX_Event_EventId",
                table: "events",
                newName: "IX_events_EventId");

            migrationBuilder.RenameIndex(
                name: "IX_Event_EffectId",
                table: "events",
                newName: "IX_events_EffectId");

            migrationBuilder.AlterColumn<int>(
                name: "CostId",
                table: "upgrades",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_events",
                table: "events",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_events_bases_EventId",
                table: "events",
                column: "EventId",
                principalTable: "bases",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_events_buildings_EventId",
                table: "events",
                column: "EventId",
                principalTable: "buildings",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_events_effects_EffectId",
                table: "events",
                column: "EffectId",
                principalTable: "effects",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_events_player_EventId",
                table: "events",
                column: "EventId",
                principalTable: "player",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_upgrades_resourceCollections_CostId",
                table: "upgrades",
                column: "CostId",
                principalTable: "resourceCollections",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_events_bases_EventId",
                table: "events");

            migrationBuilder.DropForeignKey(
                name: "FK_events_buildings_EventId",
                table: "events");

            migrationBuilder.DropForeignKey(
                name: "FK_events_effects_EffectId",
                table: "events");

            migrationBuilder.DropForeignKey(
                name: "FK_events_player_EventId",
                table: "events");

            migrationBuilder.DropForeignKey(
                name: "FK_upgrades_resourceCollections_CostId",
                table: "upgrades");

            migrationBuilder.DropPrimaryKey(
                name: "PK_events",
                table: "events");

            migrationBuilder.RenameTable(
                name: "events",
                newName: "Event");

            migrationBuilder.RenameIndex(
                name: "IX_events_EventId",
                table: "Event",
                newName: "IX_Event_EventId");

            migrationBuilder.RenameIndex(
                name: "IX_events_EffectId",
                table: "Event",
                newName: "IX_Event_EffectId");

            migrationBuilder.AlterColumn<int>(
                name: "CostId",
                table: "upgrades",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Event",
                table: "Event",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Event_bases_EventId",
                table: "Event",
                column: "EventId",
                principalTable: "bases",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Event_buildings_EventId",
                table: "Event",
                column: "EventId",
                principalTable: "buildings",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Event_effects_EffectId",
                table: "Event",
                column: "EffectId",
                principalTable: "effects",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Event_player_EventId",
                table: "Event",
                column: "EventId",
                principalTable: "player",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_upgrades_resourceCollections_CostId",
                table: "upgrades",
                column: "CostId",
                principalTable: "resourceCollections",
                principalColumn: "Id");
        }
    }
}
