using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SLN7.DATA.Migrations
{
    public partial class employeetable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Employee",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmpId = table.Column<int>(type: "int", nullable: true),
                    EmpFName = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    EmpLName = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    EmpUserName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    EmpEmailId = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    EmpPassword = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    EmpMobileNo = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    DOJ = table.Column<DateTime>(type: "datetime2", maxLength: 10, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    Branch = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Position = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CTC_PA = table.Column<decimal>(type: "decimal(18,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employee");
        }
    }
}
