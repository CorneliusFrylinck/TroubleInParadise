using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TroubleInParadise.Data.Migrations
{
    public partial class player_changes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_bases_player_PlayerId",
                table: "bases");

            migrationBuilder.DropTable(
                name: "playerTypes");

            migrationBuilder.DropIndex(
                name: "IX_bases_PlayerId",
                table: "bases");

            migrationBuilder.DropColumn(
                name: "PlayerTypeId",
                table: "player");

            migrationBuilder.AddForeignKey(
                name: "FK_bases_player_BaseId",
                table: "bases",
                column: "BaseId",
                principalTable: "player",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_bases_player_BaseId",
                table: "bases");

            migrationBuilder.AddColumn<int>(
                name: "PlayerTypeId",
                table: "player",
                type: "int",
                nullable: false,
                defaultValue: 0);

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

            migrationBuilder.CreateIndex(
                name: "IX_bases_PlayerId",
                table: "bases",
                column: "PlayerId");

            migrationBuilder.AddForeignKey(
                name: "FK_bases_player_PlayerId",
                table: "bases",
                column: "PlayerId",
                principalTable: "player",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
