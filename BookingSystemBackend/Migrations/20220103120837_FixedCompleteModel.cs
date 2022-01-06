using Microsoft.EntityFrameworkCore.Migrations;

namespace BookingSystemBackend.Migrations
{
    public partial class FixedCompleteModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cars_Trains_TrainId1",
                table: "Cars");

            migrationBuilder.DropIndex(
                name: "IX_Cars_TrainId1",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "TrainId1",
                table: "Cars");

            migrationBuilder.AlterColumn<string>(
                name: "TrainId",
                table: "Cars",
                type: "nvarchar(30)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Cars_TrainId",
                table: "Cars",
                column: "TrainId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_Trains_TrainId",
                table: "Cars",
                column: "TrainId",
                principalTable: "Trains",
                principalColumn: "TrainId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cars_Trains_TrainId",
                table: "Cars");

            migrationBuilder.DropIndex(
                name: "IX_Cars_TrainId",
                table: "Cars");

            migrationBuilder.AlterColumn<int>(
                name: "TrainId",
                table: "Cars",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TrainId1",
                table: "Cars",
                type: "nvarchar(30)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Cars_TrainId1",
                table: "Cars",
                column: "TrainId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_Trains_TrainId1",
                table: "Cars",
                column: "TrainId1",
                principalTable: "Trains",
                principalColumn: "TrainId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
