using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HouseRentingSystem.Infrastructure.Migrations
{
    public partial class UpdateDatabase_2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8cccb1ca-90bf-4b35-85aa-9a0392ca3d03", "AQAAAAEAACcQAAAAEAZe/mz4aMb93m70Fp5zXhEuUO9cQG+PxN7dqZP3NOMacgFFxyb6IzJYpd/+M2rIWg==", "4182c0f5-7472-4ad2-99a8-f0ef81e27923" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b6f9f41e-dc68-46ac-925f-f63feb1eab21", "AQAAAAEAACcQAAAAEOa/V3F0kwhYWLcZwof4j8mLw1kpzvEnV9lmpn+iDNxLbGF2qGKxKHUCrbIGHREcPA==", "ee5ec2d0-7e99-4acb-9d8b-6c11d3a30e98" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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
    }
}
