using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskMaster.Pro.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddIdentityTables_v2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: new Guid("5b3b6b20-5318-4bac-904a-8377630deeed"));

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "Id", "Name", "OwnerId" },
                values: new object[] { new Guid("1c4e9548-9b1e-4b5a-9c2d-7e8f3a4b5c6d"), "Test Project 1", new Guid("1c4e9548-9b1e-4b5a-9c2d-7e8f3a4b5c6d") });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: new Guid("1c4e9548-9b1e-4b5a-9c2d-7e8f3a4b5c6d"));

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "Id", "Name", "OwnerId" },
                values: new object[] { new Guid("5b3b6b20-5318-4bac-904a-8377630deeed"), "Test Project 1", new Guid("6d8188f1-8a23-43fa-b804-6e7cbf204767") });
        }
    }
}
