using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewsMediatorAPI.Migrations
{
    /// <inheritdoc />
    public partial class CreateAgain : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Aurthor",
                table: "News",
                newName: "Author");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Author",
                table: "News",
                newName: "Aurthor");
        }
    }
}
