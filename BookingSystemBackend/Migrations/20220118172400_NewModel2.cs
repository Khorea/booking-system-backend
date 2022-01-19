using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BookingSystemBackend.Migrations
{
    public partial class NewModel2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Seats_Bookings_BookingDate_BookingSeatId",
                table: "Seats");

            migrationBuilder.DropIndex(
                name: "IX_Seats_BookingDate_BookingSeatId",
                table: "Seats");

            migrationBuilder.DropColumn(
                name: "BookingDate",
                table: "Seats");

            migrationBuilder.DropColumn(
                name: "BookingSeatId",
                table: "Seats");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "BookingDate",
                table: "Seats",
                type: "Date",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "BookingSeatId",
                table: "Seats",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Seats_BookingDate_BookingSeatId",
                table: "Seats",
                columns: new[] { "BookingDate", "BookingSeatId" });

            migrationBuilder.AddForeignKey(
                name: "FK_Seats_Bookings_BookingDate_BookingSeatId",
                table: "Seats",
                columns: new[] { "BookingDate", "BookingSeatId" },
                principalTable: "Bookings",
                principalColumns: new[] { "BookingDate", "SeatId" },
                onDelete: ReferentialAction.Restrict);
        }
    }
}
