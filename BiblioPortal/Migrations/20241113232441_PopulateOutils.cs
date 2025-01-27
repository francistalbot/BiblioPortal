using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BiblioPortal.Migrations
{
    /// <inheritdoc />
    public partial class PopulateOutils : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.InsertData(
                table: "Outils",
                columns: new[] { "Id", "name", "description" },
                values: new object[,]
                {
                    {"1", "Marteau","" },
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
