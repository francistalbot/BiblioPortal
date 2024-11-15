using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BiblioPortal.Migrations
{
    /// <inheritdoc />
    public partial class OutilRename : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "name",
                table: "Outils",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "description",
                table: "Outils",
                newName: "Description");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Outils",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Outils",
                newName: "description");
        }
    }
}
