using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FlightBookingSystem.Migrations
{
    /// <inheritdoc />
    public partial class New : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SeatAllocations_SeatAvailables_SeatAvailableId",
                table: "SeatAllocations");

            migrationBuilder.DropTable(
                name: "SeatAvailables");

            migrationBuilder.DropIndex(
                name: "IX_SeatAllocations_SeatAvailableId",
                table: "SeatAllocations");

            migrationBuilder.DropColumn(
                name: "SeatAvailableId",
                table: "SeatAllocations");

            migrationBuilder.AddColumn<int>(
                name: "AvailableSeats",
                table: "Flights",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TotalSeats",
                table: "Flights",
                type: "int",
                maxLength: 800,
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AvailableSeats",
                table: "Flights");

            migrationBuilder.DropColumn(
                name: "TotalSeats",
                table: "Flights");

            migrationBuilder.AddColumn<int>(
                name: "SeatAvailableId",
                table: "SeatAllocations",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "SeatAvailables",
                columns: table => new
                {
                    SeatAvailableId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FlightId = table.Column<int>(type: "int", nullable: false),
                    IsAvailable = table.Column<bool>(type: "bit", nullable: false),
                    SeatBooked = table.Column<int>(type: "int", nullable: false),
                    TotalSeats = table.Column<int>(type: "int", maxLength: 800, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SeatAvailables", x => x.SeatAvailableId);
                    table.ForeignKey(
                        name: "FK_SeatAvailables_Flights_FlightId",
                        column: x => x.FlightId,
                        principalTable: "Flights",
                        principalColumn: "FlightId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SeatAllocations_SeatAvailableId",
                table: "SeatAllocations",
                column: "SeatAvailableId");

            migrationBuilder.CreateIndex(
                name: "IX_SeatAvailables_FlightId",
                table: "SeatAvailables",
                column: "FlightId");

            migrationBuilder.AddForeignKey(
                name: "FK_SeatAllocations_SeatAvailables_SeatAvailableId",
                table: "SeatAllocations",
                column: "SeatAvailableId",
                principalTable: "SeatAvailables",
                principalColumn: "SeatAvailableId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
