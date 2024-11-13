using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BiblioPortal.Migrations
{
    /// <inheritdoc />
    public partial class PopulateMembershipType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "MembershipType",
                columns: new[] { "Id", "SignUpFee", "DurationInMonths", "DiscountRate" },
                values: new object[,]
                {
                    {"1", "0","0", "0" },
                    {"2", "30"," 1", "10" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
