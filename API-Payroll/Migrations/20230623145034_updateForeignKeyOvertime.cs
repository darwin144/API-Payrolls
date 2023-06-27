using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API_Payroll.Migrations
{
    public partial class updateForeignKeyOvertime : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tb_m_overtimes_tb_m_employees_Id",
                table: "tb_m_overtimes");

            migrationBuilder.CreateIndex(
                name: "IX_tb_m_overtimes_employee_id",
                table: "tb_m_overtimes",
                column: "employee_id");

            migrationBuilder.AddForeignKey(
                name: "FK_tb_m_overtimes_tb_m_employees_employee_id",
                table: "tb_m_overtimes",
                column: "employee_id",
                principalTable: "tb_m_employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tb_m_overtimes_tb_m_employees_employee_id",
                table: "tb_m_overtimes");

            migrationBuilder.DropIndex(
                name: "IX_tb_m_overtimes_employee_id",
                table: "tb_m_overtimes");

            migrationBuilder.AddForeignKey(
                name: "FK_tb_m_overtimes_tb_m_employees_Id",
                table: "tb_m_overtimes",
                column: "Id",
                principalTable: "tb_m_employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
