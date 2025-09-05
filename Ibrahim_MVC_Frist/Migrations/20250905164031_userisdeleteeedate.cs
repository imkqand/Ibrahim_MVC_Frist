using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ibrahim_MVC_Frist.Migrations
{
    /// <inheritdoc />
    public partial class userisdeleteeedate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DeleteDate",
                table: "employeesm",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DeleteDate",
                table: "employeesm");
        }
    }
}
