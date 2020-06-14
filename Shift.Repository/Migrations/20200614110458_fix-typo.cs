using Microsoft.EntityFrameworkCore.Migrations;

namespace Shift.Repository.Migrations
{
    public partial class fixtypo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ReseachParticipation",
                table: "RationalInfo");

            migrationBuilder.AddColumn<string>(
                name: "ResearchParticipation",
                table: "RationalInfo",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ResearchParticipation",
                table: "RationalInfo");

            migrationBuilder.AddColumn<string>(
                name: "ReseachParticipation",
                table: "RationalInfo",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
