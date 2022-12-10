using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HouseRentingSystem.Infrastructure.Migrations
{
    public partial class UpdateDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2d6a0c08-15dd-4f3d-8036-cbd1a68d9d89", "AQAAAAEAACcQAAAAECjSo99EcEg9ezow9c1MSZP5QWnn8bOk1BiZpVVI1GtZN+TJ1pVfyCe49ndebADlAg==", "35db63f1-f175-428c-9402-a1e8d99097bb" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ba2b0a61-73c5-4b42-bb67-4f9057995c63", "AQAAAAEAACcQAAAAEKXBb3Bk37dMkAjdmyHhKEPFh0Gz7QDnbX8aDDuUur+h+/F9cry8z2KIiI385gGI6g==", "8c022520-57de-4968-87e5-46bd0c148988" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "cbfee9a9-8897-47a6-8126-cc58aa8675ea", "AQAAAAEAACcQAAAAEAmXmpJghCZ4NUVFQCSqzh+wv9x/N6H1ei4dzeShIDrcaYHTEamL8jyxiQ4+hb74Aw==", "a84cfb32-2155-4867-8a74-4d1a80dc2451" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f864322b-4aa3-4cd5-b6b7-0122f301d9d5", "AQAAAAEAACcQAAAAEB0gJ0WF0WKIgWEa51d3FqUy4UeHp8tDk5w/Wt2OlF+k3DLgWPEWnSr8Obt+FuHOHA==", "804f5906-ffdd-4d44-b691-4a81a2788a85" });
        }
    }
}
