using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Migrations;
using System.Text;

#nullable disable

namespace TroubleInParadise.Data.Migrations
{
    public partial class add_startup_data : Migration
    {
        const string ADMIN_USER_GUID = "08b3cb11-2ad5-49a2-9501-72349b46afcb";
        const string ADMIN_ROLE_GUID = "1f1fe536-bfe3-4a99-bf1e-8239f025cd09";
        const string BETA_USER_ROLE_GUID = "8fb245cc-5c3f-46f5-81af-e4622b2b7d5c";
        const string USER_ROLE_GUID = "64fa1f54-de14-4060-8341-2e05d582aff1";
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            AddAdminUser(migrationBuilder);
            //AddResources(migrationBuilder);
            AddBuildingTypes(migrationBuilder);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql($"DELETE FROM AspNetUserRoles WHERE UserId = '{ADMIN_USER_GUID}' AND RoleId = '{ADMIN_ROLE_GUID}'");
            migrationBuilder.Sql($"DELETE FROM AspNetUsers WHERE UserId = '{ADMIN_USER_GUID}'");
            migrationBuilder.Sql($"DELETE FROM AspNetRoles");
        }

        private void AddBuildingTypes(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql($"INSERT INTO buildingTypes (Name, Description) VALUES ('Command Centre', 'To be added later')");
            migrationBuilder.Sql($"INSERT INTO buildingTypes (Name, Description) VALUES ('Warroom', 'To be added later')");
            migrationBuilder.Sql($"INSERT INTO buildingTypes (Name, Description) VALUES ('Outpost', 'To be added later')");
            migrationBuilder.Sql($"INSERT INTO buildingTypes (Name, Description) VALUES ('Barracks', 'To be added later')");
            migrationBuilder.Sql($"INSERT INTO buildingTypes (Name, Description) VALUES ('Medical Facility', 'To be added later')");
            migrationBuilder.Sql($"INSERT INTO buildingTypes (Name, Description) VALUES ('Research Facility', 'To be added later')");
            migrationBuilder.Sql($"INSERT INTO buildingTypes (Name, Description) VALUES ('Tradepost', 'To be added later')");
            migrationBuilder.Sql($"INSERT INTO buildingTypes (Name, Description) VALUES ('Market', 'To be added later')");
            migrationBuilder.Sql($"INSERT INTO buildingTypes (Name, Description) VALUES ('Silos', 'To be added later')");
            migrationBuilder.Sql($"INSERT INTO buildingTypes (Name, Description) VALUES ('Vaults', 'To be added later')");
            migrationBuilder.Sql($"INSERT INTO buildingTypes (Name, Description) VALUES ('Bunker', 'To be added later')");
            migrationBuilder.Sql($"INSERT INTO buildingTypes (Name, Description) VALUES ('Shield', 'To be added later')");
        }

        private void AddResources(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql($"INSERT INTO resources (Name, Value, Description) VALUES ('Metal', '100', 'To be added later')");
            migrationBuilder.Sql($"INSERT INTO resources (Name, Value, Description) VALUES ('Cement', '100', 'To be added later')");
            migrationBuilder.Sql($"INSERT INTO resources (Name, Value, Description) VALUES ('Lumber', '100', 'To be added later')");
            migrationBuilder.Sql($"INSERT INTO resources (Name, Value, Description) VALUES ('Water', '100', 'To be added later')");
            migrationBuilder.Sql($"INSERT INTO resources (Name, Value, Description) VALUES ('Food', '100', 'To be added later')");
            migrationBuilder.Sql($"INSERT INTO resources (Name, Value, Description) VALUES ('Oxygen', '100', 'To be added later')");
            migrationBuilder.Sql($"INSERT INTO resources (Name, Value, Description) VALUES ('Crystal', '100', 'To be added later')");
            migrationBuilder.Sql($"INSERT INTO resources (Name, Value, Description) VALUES ('Living Steel', '100', 'To be added later')");
        }


        private void AddAdminUser(MigrationBuilder migrationBuilder)
        {
            var hasher = new PasswordHasher<IdentityUser>();

            var passwordHash = hasher.HashPassword(null, "kxlfmmtkyeX!7"); // TODO - hide PW

            StringBuilder sb = new StringBuilder();

            sb.AppendLine("INSERT INTO AspNetUsers(Id, UserName, NormalizedUserName, Email, EmailConfirmed, PhoneNumberConfirmed, TwoFactorEnabled, LockoutEnabled, AccessFailedCount, NormalizedEmail, PasswordHash, SecurityStamp)");
            sb.AppendLine(" VALUES (");
            sb.AppendLine($"'{ADMIN_USER_GUID}'");
            sb.AppendLine(", 'corneliusfrylinck@zohomail.com'");
            sb.AppendLine(", 'CORNELIUSFRYLINCK@ZOHOMAIL.COM'");
            sb.AppendLine(", 'corneliusfrylinck@zohomail.com'");
            sb.AppendLine(", 1");
            sb.AppendLine(", 0");
            sb.AppendLine(", 0");
            sb.AppendLine(", 0");
            sb.AppendLine(", 0");
            sb.AppendLine(", 'CORNELIUSFRYLINCK@ZOHOMAIL.COM'");
            sb.AppendLine($", '{passwordHash}'");
            sb.AppendLine(", ''");
            sb.AppendLine(")");

            migrationBuilder.Sql(sb.ToString());

            migrationBuilder.Sql($"INSERT INTO AspNetRoles (Id, Name, NormalizedName) VALUES ('{ADMIN_ROLE_GUID}', 'Admin', 'ADMIN')");
            //migrationBuilder.Sql($"INSERT INTO AspNetRoles (Id, Name, NormalizedName) VALUES ('{BETA_USER_ROLE_GUID}', 'Beta', 'BETA')");
            //migrationBuilder.Sql($"INSERT INTO AspNetRoles (Id, Name, NormalizedName) VALUES ('{USER_ROLE_GUID}', 'User', 'USER')");

            migrationBuilder.Sql($"INSERT INTO AspNetUserRoles (UserId, RoleId) VALUES ('{ADMIN_USER_GUID}', '{ADMIN_ROLE_GUID}')");
        }
    }
}
