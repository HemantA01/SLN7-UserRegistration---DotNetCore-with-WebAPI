using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SLN7.DATA.Migrations
{
    public partial class addtables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Employee",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Branch = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tblCountryMaster",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CountryName = table.Column<string>(type: "nvarchar(55)", maxLength: 55, nullable: true),
                    CountryAbb = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblCountryMaster", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tblLeadSource",
                columns: table => new
                {
                    LeadSourceID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LeadSourceDeleteSpace = table.Column<int>(type: "int", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    LeadSourceStatus = table.Column<bool>(type: "bit", nullable: true),
                    LeadSourceRemkt = table.Column<bool>(type: "bit", nullable: true),
                    LeadSourceOrigID = table.Column<int>(type: "int", nullable: true),
                    LeadSourceText = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    LeadSourceCreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LeadSourceUpdateOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LeadSourceUpdatedBy = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblLeadSource", x => x.LeadSourceID);
                });

            migrationBuilder.CreateTable(
                name: "tblStateMaster",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CountryId = table.Column<int>(type: "int", nullable: true),
                    StateName = table.Column<string>(type: "nvarchar(55)", maxLength: 55, nullable: true),
                    StateAbb = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    CreatedBy = table.Column<int>(type: "int", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblStateMaster", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tblUserLogin",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserPassword = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblUserLogin", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tblUserRegistration",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: true),
                    UserFname = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    UserLname = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    UserContact = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    UserEmail = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    DOB = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Nationality = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    TemporaryAddress = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    PermanentAddress = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    CountryId = table.Column<int>(type: "int", nullable: true),
                    StateId = table.Column<int>(type: "int", nullable: true),
                    City = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    EmploymentId = table.Column<int>(type: "int", nullable: true),
                    Employment = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    UserCreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UserCreatedBy = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblUserRegistration", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employee");

            migrationBuilder.DropTable(
                name: "tblCountryMaster");

            migrationBuilder.DropTable(
                name: "tblLeadSource");

            migrationBuilder.DropTable(
                name: "tblStateMaster");

            migrationBuilder.DropTable(
                name: "tblUserLogin");

            migrationBuilder.DropTable(
                name: "tblUserRegistration");
        }
    }
}
