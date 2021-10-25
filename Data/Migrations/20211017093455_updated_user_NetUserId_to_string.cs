using Microsoft.EntityFrameworkCore.Migrations;
using System;

#nullable disable

namespace TroubleInParadise.Data.Migrations
{
    public partial class updated_user_NetUserId_to_string : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "NetUserId",
                table: "users",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<Guid>(
                name: "NetUserId",
                table: "users",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }
    }
}
