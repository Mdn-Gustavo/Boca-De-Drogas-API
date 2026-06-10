using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BocaDeDrogasAPI.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CUSTOMERS",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(type: "TEXT", nullable: false),
                    Divida = table.Column<decimal>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CUSTOMERS", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DRUGS",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(type: "TEXT", nullable: false),
                    Preco = table.Column<decimal>(type: "TEXT", nullable: false),
                    Estoque = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DRUGS", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SELLS",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ConsumidorId = table.Column<int>(type: "INTEGER", nullable: false),
                    DrogaId = table.Column<int>(type: "INTEGER", nullable: false),
                    Quantidade = table.Column<int>(type: "INTEGER", nullable: false),
                    ValorTotal = table.Column<decimal>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SELLS", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SELLS_CUSTOMERS_ConsumidorId",
                        column: x => x.ConsumidorId,
                        principalTable: "CUSTOMERS",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SELLS_DRUGS_DrogaId",
                        column: x => x.DrogaId,
                        principalTable: "DRUGS",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SELLS_ConsumidorId",
                table: "SELLS",
                column: "ConsumidorId");

            migrationBuilder.CreateIndex(
                name: "IX_SELLS_DrogaId",
                table: "SELLS",
                column: "DrogaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SELLS");

            migrationBuilder.DropTable(
                name: "CUSTOMERS");

            migrationBuilder.DropTable(
                name: "DRUGS");
        }
    }
}
