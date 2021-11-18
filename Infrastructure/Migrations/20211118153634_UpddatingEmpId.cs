using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class UpddatingEmpId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Interactions_Employees_EmployeesId",
                table: "Interactions");

            migrationBuilder.DropIndex(
                name: "IX_Interactions_EmployeesId",
                table: "Interactions");

            migrationBuilder.DropColumn(
                name: "EmployeesId",
                table: "Interactions");

            migrationBuilder.RenameColumn(
                name: "EmpId",
                table: "Interactions",
                newName: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Interactions_EmployeeId",
                table: "Interactions",
                column: "EmployeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Interactions_Employees_EmployeeId",
                table: "Interactions",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Interactions_Employees_EmployeeId",
                table: "Interactions");

            migrationBuilder.DropIndex(
                name: "IX_Interactions_EmployeeId",
                table: "Interactions");

            migrationBuilder.RenameColumn(
                name: "EmployeeId",
                table: "Interactions",
                newName: "EmpId");

            migrationBuilder.AddColumn<int>(
                name: "EmployeesId",
                table: "Interactions",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Interactions_EmployeesId",
                table: "Interactions",
                column: "EmployeesId");

            migrationBuilder.AddForeignKey(
                name: "FK_Interactions_Employees_EmployeesId",
                table: "Interactions",
                column: "EmployeesId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
