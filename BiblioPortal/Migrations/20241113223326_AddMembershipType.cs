using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BiblioPortal.Migrations
{
    /// <inheritdoc />
    public partial class AddMembershipType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte>(
                name: "MembershipTypeId",
                table: "Clients",
                type: "tinyint",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.CreateTable(
                name: "MembershipType",
                columns: table => new
                {
                    Id = table.Column<byte>(type: "tinyint", nullable: false),
                    SignUpFee = table.Column<short>(type: "smallint", nullable: false),
                    DurationInMonths = table.Column<byte>(type: "tinyint", nullable: false),
                    DiscountRate = table.Column<byte>(type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MembershipType", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Clients_MembershipTypeId",
                table: "Clients",
                column: "MembershipTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Clients_MembershipType_MembershipTypeId",
                table: "Clients",
                column: "MembershipTypeId",
                principalTable: "MembershipType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clients_MembershipType_MembershipTypeId",
                table: "Clients");

            migrationBuilder.DropTable(
                name: "MembershipType");

            migrationBuilder.DropIndex(
                name: "IX_Clients_MembershipTypeId",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "MembershipTypeId",
                table: "Clients");
        }
    }
}
