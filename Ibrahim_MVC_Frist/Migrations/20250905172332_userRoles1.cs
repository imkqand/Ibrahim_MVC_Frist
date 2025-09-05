using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ibrahim_MVC_Frist.Migrations
{
    /// <inheritdoc />
    public partial class userRoles1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserRoleId",
                table: "employeesm",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "UserRoles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoles", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_employeesm_UserRoleId",
                table: "employeesm",
                column: "UserRoleId");

            migrationBuilder.AddForeignKey(
                name: "FK_employeesm_UserRoles_UserRoleId",
                table: "employeesm",
                column: "UserRoleId",
                principalTable: "UserRoles",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_employeesm_UserRoles_UserRoleId",
                table: "employeesm");

            migrationBuilder.DropTable(
                name: "UserRoles");

            migrationBuilder.DropIndex(
                name: "IX_employeesm_UserRoleId",
                table: "employeesm");

            migrationBuilder.DropColumn(
                name: "UserRoleId",
                table: "employeesm");
        }
    }
}
