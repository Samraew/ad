using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace o.Migrations
{
    /// <inheritdoc />
    public partial class lester : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ilacadın",
                table: "ilac",
                type: "TEXT",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ilacadın",
                table: "ilac");
        }
    }
}
