using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API_Payroll.Migrations
{
    public partial class deletetypeonovertime : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "tipe",
                table: "tb_m_overtimes");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "tipe",
                table: "tb_m_overtimes",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
