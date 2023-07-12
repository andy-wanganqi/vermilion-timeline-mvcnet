using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace VermilionTimeline.IdentityDataAccess.Migrations
{
    /// <inheritdoc />
    public partial class Initialrolesandadmin : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "b54918b5-eb1a-42c2-907e-594850d52ba2", "b54918b5-eb1a-42c2-907e-594850d52ba2", "User", "User" },
                    { "dc2bb782-be50-4a99-87f7-5515457cc680", "dc2bb782-be50-4a99-87f7-5515457cc680", "Admin", "Admin" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "39f847c1-01a9-44ce-b1a8-7c667f6efe73", 0, "349e7f62-9492-4e90-93ca-d8ff9577835e", "914173725@qq.com", false, false, null, "914173725@QQ.COM", "914173725@QQ.COM", "AQAAAAIAAYagAAAAEN6f7uhsAGU67DRFofiE+g53tE2Z/8ey/maWpEiszU0ufvARDn9WjHYNAR4MIG+sug==", null, false, "b47fcfb2-14bc-4d56-913d-d186771f230b", false, "914173725@qq.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "dc2bb782-be50-4a99-87f7-5515457cc680", "39f847c1-01a9-44ce-b1a8-7c667f6efe73" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b54918b5-eb1a-42c2-907e-594850d52ba2");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "dc2bb782-be50-4a99-87f7-5515457cc680", "39f847c1-01a9-44ce-b1a8-7c667f6efe73" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "dc2bb782-be50-4a99-87f7-5515457cc680");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "39f847c1-01a9-44ce-b1a8-7c667f6efe73");
        }
    }
}
