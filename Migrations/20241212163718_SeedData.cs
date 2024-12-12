using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace bookstore.Migrations
{
    /// <inheritdoc />
    public partial class SeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "BookEntities",
                columns: new[] { "Id", "Title" },
                values: new object[,]
                {
                    { new Guid("0e01c4ab-7cb9-4185-9744-9efd35129641"), "The Return of the King" },
                    { new Guid("3cf3308a-d801-4307-8c2e-79ed0b467d4d"), "The Fellowship of the Ring" },
                    { new Guid("9d981a6c-c173-4b6d-9209-293f571d1e25"), "The Two Towers" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "BookEntities",
                keyColumn: "Id",
                keyValue: new Guid("0e01c4ab-7cb9-4185-9744-9efd35129641"));

            migrationBuilder.DeleteData(
                table: "BookEntities",
                keyColumn: "Id",
                keyValue: new Guid("3cf3308a-d801-4307-8c2e-79ed0b467d4d"));

            migrationBuilder.DeleteData(
                table: "BookEntities",
                keyColumn: "Id",
                keyValue: new Guid("9d981a6c-c173-4b6d-9209-293f571d1e25"));
        }
    }
}
