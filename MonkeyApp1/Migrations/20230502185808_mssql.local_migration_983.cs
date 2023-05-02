using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MonkeyApp1.Migrations
{
    /// <inheritdoc />
    public partial class mssqllocal_migration_983 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ContinentId",
                table: "Monkey",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Continent",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Continent", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Monkey_ContinentId",
                table: "Monkey",
                column: "ContinentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Monkey_Continent_ContinentId",
                table: "Monkey",
                column: "ContinentId",
                principalTable: "Continent",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Monkey_Continent_ContinentId",
                table: "Monkey");

            migrationBuilder.DropTable(
                name: "Continent");

            migrationBuilder.DropIndex(
                name: "IX_Monkey_ContinentId",
                table: "Monkey");

            migrationBuilder.DropColumn(
                name: "ContinentId",
                table: "Monkey");
        }
    }
}
