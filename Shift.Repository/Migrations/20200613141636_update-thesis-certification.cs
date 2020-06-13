using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Shift.Repository.Migrations
{
    public partial class updatethesiscertification : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Graduates_Departments_DepartmentId",
                table: "Graduates");

            migrationBuilder.DropForeignKey(
                name: "FK_Undergraduates_Departments_DepartmentId",
                table: "Undergraduates");

            migrationBuilder.DropIndex(
                name: "IX_Undergraduates_DepartmentId",
                table: "Undergraduates");

            migrationBuilder.DropIndex(
                name: "IX_Graduates_DepartmentId",
                table: "Graduates");

            migrationBuilder.DropColumn(
                name: "DepartmentId",
                table: "Undergraduates");

            migrationBuilder.DropColumn(
                name: "DepartmentId",
                table: "Graduates");

            migrationBuilder.AddColumn<DateTime>(
                name: "PreliminaryApproveDate",
                table: "ThesisCertifications",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PreliminaryResult",
                table: "ThesisCertifications",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProtocolId",
                table: "ThesisCertifications",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ThesisCertifications_ProtocolId",
                table: "ThesisCertifications",
                column: "ProtocolId");

            migrationBuilder.AddForeignKey(
                name: "FK_ThesisCertifications_Protocol_ProtocolId",
                table: "ThesisCertifications",
                column: "ProtocolId",
                principalTable: "Protocol",
                principalColumn: "ProtocolId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ThesisCertifications_Protocol_ProtocolId",
                table: "ThesisCertifications");

            migrationBuilder.DropIndex(
                name: "IX_ThesisCertifications_ProtocolId",
                table: "ThesisCertifications");

            migrationBuilder.DropColumn(
                name: "PreliminaryApproveDate",
                table: "ThesisCertifications");

            migrationBuilder.DropColumn(
                name: "PreliminaryResult",
                table: "ThesisCertifications");

            migrationBuilder.DropColumn(
                name: "ProtocolId",
                table: "ThesisCertifications");

            migrationBuilder.AddColumn<int>(
                name: "DepartmentId",
                table: "Undergraduates",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DepartmentId",
                table: "Graduates",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Undergraduates_DepartmentId",
                table: "Undergraduates",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Graduates_DepartmentId",
                table: "Graduates",
                column: "DepartmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Graduates_Departments_DepartmentId",
                table: "Graduates",
                column: "DepartmentId",
                principalTable: "Departments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Undergraduates_Departments_DepartmentId",
                table: "Undergraduates",
                column: "DepartmentId",
                principalTable: "Departments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
