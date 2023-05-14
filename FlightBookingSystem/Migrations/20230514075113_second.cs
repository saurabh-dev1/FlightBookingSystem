using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FlightBookingSystem.Migrations
{
    /// <inheritdoc />
    public partial class second : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Flights_Admins_AdminId",
                table: "Flights");

            migrationBuilder.DropIndex(
                name: "IX_Flights_AdminId",
                table: "Flights");

            migrationBuilder.DropColumn(
                name: "AdminId",
                table: "Flights");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AdminId",
                table: "Flights",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Flights_AdminId",
                table: "Flights",
                column: "AdminId");

            migrationBuilder.AddForeignKey(
                name: "FK_Flights_Admins_AdminId",
                table: "Flights",
                column: "AdminId",
                principalTable: "Admins",
                principalColumn: "AdminId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
