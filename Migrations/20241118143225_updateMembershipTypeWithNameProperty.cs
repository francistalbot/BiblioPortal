using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BiblioPortal.Migrations
{
    /// <inheritdoc />
    public partial class updateMembershipTypeWithNameProperty : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // migrationBuilder.Sql("UPDATE MembershipType SET Name = 'Particulier' WHERE Name IS '0'");

            migrationBuilder.UpdateData(
                table: "MembershipType",
                keyColumn: "DiscountRate",
                keyValue: "0",
                column: "Name",
                value: "Particulier"
                );

            migrationBuilder.UpdateData(
                table: "MembershipType",
                keyColumn: "DiscountRate",
                keyValue: "10",
                column: "Name",
                value: "Premium"
                );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
