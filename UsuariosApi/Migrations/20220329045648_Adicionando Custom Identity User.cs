using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace UsuariosApi.Migrations
{
    public partial class AdicionandoCustomIdentityUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 99998);

            migrationBuilder.AddColumn<DateTime>(
                name: "DataNascimento",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 99999,
                column: "ConcurrencyStamp",
                value: "8bc4361f-566d-4fbc-a58c-a7a60011851d");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { 9999, "5e88d1ec-a455-4463-b526-3618f43820f1", "regular", "REGULAR" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 99999,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d5da3b9d-0ee5-4031-9343-c10cc9b12d06", "AQAAAAEAACcQAAAAEC+6uTay8Jz/q47+XRUUnuSo7ccxIRWonGhRAmiiV1tq2s8HKcdGTOjj3YSj6g9K3Q==", "daebce9c-3ef9-4e63-a78a-0238e9b7c1f7" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 9999);

            migrationBuilder.DropColumn(
                name: "DataNascimento",
                table: "AspNetUsers");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 99999,
                column: "ConcurrencyStamp",
                value: "44640c00-cf4a-4893-bba7-7c1d0345a02a");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { 99998, "b895aad4-95fe-4e34-8ecb-a6552dc50cec", "regular", "REGULAR" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 99999,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1d2f29f0-57a6-4f9c-989b-847450c4dc4e", "AQAAAAEAACcQAAAAEJ8DVvJF74S8/ZU2F/djOgQbrzfHdFyiMEMnrQih8JKSgISBTKZZZ6k7YUt8yZiloA==", "7a66cac1-6948-4b82-92f1-8d3bfcb5d530" });
        }
    }
}
