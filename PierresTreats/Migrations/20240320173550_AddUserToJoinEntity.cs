using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PierresTreats.Migrations
{
    public partial class AddUserToJoinEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "TreatFlavors",
                type: "varchar(255)",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_TreatFlavors_UserId",
                table: "TreatFlavors",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_TreatFlavors_AspNetUsers_UserId",
                table: "TreatFlavors",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TreatFlavors_AspNetUsers_UserId",
                table: "TreatFlavors");

            migrationBuilder.DropIndex(
                name: "IX_TreatFlavors_UserId",
                table: "TreatFlavors");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "TreatFlavors");
        }
    }
}
