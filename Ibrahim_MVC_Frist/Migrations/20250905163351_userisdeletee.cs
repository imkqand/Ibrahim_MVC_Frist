using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ibrahim_MVC_Frist.Migrations
{
    /// <inheritdoc />
    public partial class userisdeletee : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserDeleted",
                table: "employeesm",
                type: "int",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserDeleted",
                table: "employeesm");
        }
    }
}
