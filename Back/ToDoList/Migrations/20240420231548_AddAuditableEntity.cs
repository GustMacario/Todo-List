using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ToDoList.Migrations
{
    /// <inheritdoc />
    public partial class AddAuditableEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Delayed",
                table: "ToDos");

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "ToDos",
                type: "TEXT",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "ToDos");

            migrationBuilder.AddColumn<bool>(
                name: "Delayed",
                table: "ToDos",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);
        }
    }
}
