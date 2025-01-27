using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BiblioPortal.Migrations
{
    /// <inheritdoc />
    public partial class populateClients : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Clients",
                columns: new[] { "Id", "Name", "Email", "DateOfBirth", "MembershipTypeId" },
                values: new object[,]
                {
                    {"1", "Francis t","","10/12/1989",1 },
                });

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
