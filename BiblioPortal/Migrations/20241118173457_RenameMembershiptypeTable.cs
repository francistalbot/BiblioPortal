using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BiblioPortal.Migrations
{
    /// <inheritdoc />
    public partial class RenameMembershiptypeTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.RenameTable(
                name: "MembershipType", // Nom actuel
                newName: "MembershipTypes" // Nouveau nom
            );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.RenameTable(
                name: "MembershipTypes", // Nouveau nom
                newName: "MembershipType" // Revenir à l'ancien nom si besoin
            );
        }
    }
}
