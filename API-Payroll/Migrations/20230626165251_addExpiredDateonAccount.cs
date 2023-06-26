using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API_Payroll.Migrations
{
    public partial class addExpiredDateonAccount : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "isUsed",
                table: "tb_m_accounts",
                newName: "IsUsed");

            migrationBuilder.RenameColumn(
                name: "isDeleted",
                table: "tb_m_accounts",
                newName: "IsDeleted");

            migrationBuilder.AddColumn<DateTime>(
                name: "ExpiredTime",
                table: "tb_m_accounts",
                type: "datetime2",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ExpiredTime",
                table: "tb_m_accounts");

            migrationBuilder.RenameColumn(
                name: "IsUsed",
                table: "tb_m_accounts",
                newName: "isUsed");

            migrationBuilder.RenameColumn(
                name: "IsDeleted",
                table: "tb_m_accounts",
                newName: "isDeleted");
        }
    }
}
