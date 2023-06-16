using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Backed.API.DataAcces.Migrations
{
    /// <inheritdoc />
    public partial class migracion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Airports",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IATACode = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    Location = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Airports", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RouteFlights",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RouteName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RouteFlights", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Flights",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AirportOriginId = table.Column<int>(type: "int", nullable: false),
                    AirportDestineId = table.Column<int>(type: "int", nullable: false),
                    DepartureTime = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ArrivalTime = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    RouteFlightId = table.Column<int>(type: "int", maxLength: 50, nullable: false),
                    AirporOriginId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Flights", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Flights_Airports_AirportDestineId",
                        column: x => x.AirportDestineId,
                        principalTable: "Airports",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Flights_Airports_AirportOriginId",
                        column: x => x.AirportOriginId,
                        principalTable: "Airports",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Flights_RouteFlights_RouteFlightId",
                        column: x => x.RouteFlightId,
                        principalTable: "RouteFlights",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Flights_AirportDestineId",
                table: "Flights",
                column: "AirportDestineId");

            migrationBuilder.CreateIndex(
                name: "IX_Flights_AirportOriginId",
                table: "Flights",
                column: "AirportOriginId");

            migrationBuilder.CreateIndex(
                name: "IX_Flights_RouteFlightId",
                table: "Flights",
                column: "RouteFlightId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Flights");

            migrationBuilder.DropTable(
                name: "Airports");

            migrationBuilder.DropTable(
                name: "RouteFlights");
        }
    }
}
