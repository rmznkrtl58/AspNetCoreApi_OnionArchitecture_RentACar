using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarBook.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class mig_addCustomerAndRentACarProcessTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    CustomerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameSurname = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Mail = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.CustomerId);
                });

            migrationBuilder.CreateTable(
                name: "rentACarProcesses",
                columns: table => new
                {
                    RentACarProcessId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CarId = table.Column<int>(type: "int", nullable: false),
                    PickUpLocationId = table.Column<int>(type: "int", nullable: false),
                    DropOffLocationId = table.Column<int>(type: "int", nullable: false),
                    PickUpDate = table.Column<DateTime>(type: "Date", nullable: false),
                    DropOffDate = table.Column<DateTime>(type: "Date", nullable: false),
                    PickUpTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    DropOffTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    PickUpDescription = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    DropOffDescription = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    TotalPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_rentACarProcesses", x => x.RentACarProcessId);
                    table.ForeignKey(
                        name: "FK_rentACarProcesses_Cars_CarId",
                        column: x => x.CarId,
                        principalTable: "Cars",
                        principalColumn: "CarId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_rentACarProcesses_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_rentACarProcesses_CarId",
                table: "rentACarProcesses",
                column: "CarId");

            migrationBuilder.CreateIndex(
                name: "IX_rentACarProcesses_CustomerId",
                table: "rentACarProcesses",
                column: "CustomerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "rentACarProcesses");

            migrationBuilder.DropTable(
                name: "Customers");
        }
    }
}
