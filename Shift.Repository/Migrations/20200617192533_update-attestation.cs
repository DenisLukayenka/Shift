using Microsoft.EntityFrameworkCore.Migrations;

namespace Shift.Repository.Migrations
{
    public partial class updateattestation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Attestations_Protocol_ProtocolId",
                table: "Attestations");

            migrationBuilder.DropIndex(
                name: "IX_Attestations_ProtocolId",
                table: "Attestations");

            migrationBuilder.DropColumn(
                name: "ProtocolId",
                table: "Attestations");

            migrationBuilder.AddColumn<int>(
                name: "CommissionProtocolId",
                table: "Attestations",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CommissionResult",
                table: "Attestations",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DepartmentProtocolId",
                table: "Attestations",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DepartmentResult",
                table: "Attestations",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Attestations_CommissionProtocolId",
                table: "Attestations",
                column: "CommissionProtocolId");

            migrationBuilder.CreateIndex(
                name: "IX_Attestations_DepartmentProtocolId",
                table: "Attestations",
                column: "DepartmentProtocolId");

            migrationBuilder.AddForeignKey(
                name: "FK_Attestations_Protocol_CommissionProtocolId",
                table: "Attestations",
                column: "CommissionProtocolId",
                principalTable: "Protocol",
                principalColumn: "ProtocolId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Attestations_Protocol_DepartmentProtocolId",
                table: "Attestations",
                column: "DepartmentProtocolId",
                principalTable: "Protocol",
                principalColumn: "ProtocolId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Attestations_Protocol_CommissionProtocolId",
                table: "Attestations");

            migrationBuilder.DropForeignKey(
                name: "FK_Attestations_Protocol_DepartmentProtocolId",
                table: "Attestations");

            migrationBuilder.DropIndex(
                name: "IX_Attestations_CommissionProtocolId",
                table: "Attestations");

            migrationBuilder.DropIndex(
                name: "IX_Attestations_DepartmentProtocolId",
                table: "Attestations");

            migrationBuilder.DropColumn(
                name: "CommissionProtocolId",
                table: "Attestations");

            migrationBuilder.DropColumn(
                name: "CommissionResult",
                table: "Attestations");

            migrationBuilder.DropColumn(
                name: "DepartmentProtocolId",
                table: "Attestations");

            migrationBuilder.DropColumn(
                name: "DepartmentResult",
                table: "Attestations");

            migrationBuilder.AddColumn<int>(
                name: "ProtocolId",
                table: "Attestations",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Attestations_ProtocolId",
                table: "Attestations",
                column: "ProtocolId");

            migrationBuilder.AddForeignKey(
                name: "FK_Attestations_Protocol_ProtocolId",
                table: "Attestations",
                column: "ProtocolId",
                principalTable: "Protocol",
                principalColumn: "ProtocolId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
