using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace o.Migrations
{
    /// <inheritdoc />
    public partial class @base : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tarla",
                columns: table => new
                {
                    tarlaId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    TarlaAdı = table.Column<string>(type: "TEXT", nullable: true),
                    TarlaGenislik = table.Column<string>(type: "TEXT", nullable: true),
                    tarlaBolge = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tarla", x => x.tarlaId);
                });

            migrationBuilder.CreateTable(
                name: "ekin",
                columns: table => new
                {
                    ekinId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ekinAdı = table.Column<string>(type: "TEXT", nullable: true),
                    ekinFiyat = table.Column<string>(type: "TEXT", nullable: true),
                    ekinstock = table.Column<string>(type: "TEXT", nullable: true),
                    tarlaId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ekin", x => x.ekinId);
                    table.ForeignKey(
                        name: "FK_ekin_tarla_tarlaId",
                        column: x => x.tarlaId,
                        principalTable: "tarla",
                        principalColumn: "tarlaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ilac",
                columns: table => new
                {
                    ilacId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ilacAdı = table.Column<string>(type: "TEXT", nullable: true),
                    ilacFiyat = table.Column<string>(type: "TEXT", nullable: true),
                    ilacStock = table.Column<string>(type: "TEXT", nullable: true),
                    ekinId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ilac", x => x.ilacId);
                    table.ForeignKey(
                        name: "FK_ilac_ekin_ekinId",
                        column: x => x.ekinId,
                        principalTable: "ekin",
                        principalColumn: "ekinId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ekin_tarlaId",
                table: "ekin",
                column: "tarlaId");

            migrationBuilder.CreateIndex(
                name: "IX_ilac_ekinId",
                table: "ilac",
                column: "ekinId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ilac");

            migrationBuilder.DropTable(
                name: "ekin");

            migrationBuilder.DropTable(
                name: "tarla");
        }
    }
}
