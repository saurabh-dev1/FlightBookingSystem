using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FlightBookingSystem.Migrations
{
    /// <inheritdoc />
    public partial class _6th : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Passengers_FlightBookings_FlightBookingId",
                table: "Passengers");

            migrationBuilder.DropIndex(
                name: "IX_Passengers_FlightBookingId",
                table: "Passengers");

            migrationBuilder.DropColumn(
                name: "FlightBookingId",
                table: "Passengers");

            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                table: "Passengers",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(11)",
                oldMaxLength: 11);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                table: "Passengers",
                type: "nvarchar(11)",
                maxLength: 11,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "FlightBookingId",
                table: "Passengers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Passengers_FlightBookingId",
                table: "Passengers",
                column: "FlightBookingId");

            migrationBuilder.AddForeignKey(
                name: "FK_Passengers_FlightBookings_FlightBookingId",
                table: "Passengers",
                column: "FlightBookingId",
                principalTable: "FlightBookings",
                principalColumn: "FlightBookingId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
