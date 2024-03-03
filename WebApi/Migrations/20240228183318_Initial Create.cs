using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApi.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DbItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DbItems", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DbUnits",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(255)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DbUnits", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DbItemsUnits",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdItem = table.Column<int>(type: "int", nullable: false),
                    DbItemsId = table.Column<int>(type: "int", nullable: true),
                    IdUnit = table.Column<int>(type: "int", nullable: false),
                    DbUnitsId = table.Column<int>(type: "int", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(10,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DbItemsUnits", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DbItemsUnits_DbItems_DbItemsId",
                        column: x => x.DbItemsId,
                        principalTable: "DbItems",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_DbItemsUnits_DbUnits_DbUnitsId",
                        column: x => x.DbUnitsId,
                        principalTable: "DbUnits",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_DbItemsUnits_DbItemsId",
                table: "DbItemsUnits",
                column: "DbItemsId");

            migrationBuilder.CreateIndex(
                name: "IX_DbItemsUnits_DbUnitsId",
                table: "DbItemsUnits",
                column: "DbUnitsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DbItemsUnits");

            migrationBuilder.DropTable(
                name: "DbItems");

            migrationBuilder.DropTable(
                name: "DbUnits");
        }
    }
}
