using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API_Payroll.Migrations
{
    public partial class updateAccount : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "OTP",
                table: "tb_m_accounts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "isDeleted",
                table: "tb_m_accounts",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "isUsed",
                table: "tb_m_accounts",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OTP",
                table: "tb_m_accounts");

            migrationBuilder.DropColumn(
                name: "isDeleted",
                table: "tb_m_accounts");

            migrationBuilder.DropColumn(
                name: "isUsed",
                table: "tb_m_accounts");
        }
    }
}
