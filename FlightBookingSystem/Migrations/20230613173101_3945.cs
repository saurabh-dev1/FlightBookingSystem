using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FlightBookingSystem.Migrations
{
    /// <inheritdoc />
    public partial class _3945 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NoOfPassenger",
                table: "FlightBookings");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "NoOfPassenger",
                table: "FlightBookings",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
