using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TroubleInParadise.Data.Migrations
{
    public partial class added_other_user_roles : Migration
    {
        const string BETA_USER_ROLE_GUID = "8fb245cc-5c3f-46f5-81af-e4622b2b7d5c";
        const string USER_ROLE_GUID = "64fa1f54-de14-4060-8341-2e05d582aff1";
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql($"INSERT INTO AspNetRoles (Id, Name, NormalizedName) VALUES ('{BETA_USER_ROLE_GUID}', 'Beta', 'BETA')");
            migrationBuilder.Sql($"INSERT INTO AspNetRoles (Id, Name, NormalizedName) VALUES ('{USER_ROLE_GUID}', 'User', 'USER')");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
