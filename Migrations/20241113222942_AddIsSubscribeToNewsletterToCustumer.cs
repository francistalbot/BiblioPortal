using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BiblioPortal.Migrations
{
    /// <inheritdoc />
    public partial class AddIsSubscribeToNewsletterToCustumer : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsSubscribeToNewsletter",
                table: "Clients",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsSubscribeToNewsletter",
                table: "Clients");
        }
    }
}
