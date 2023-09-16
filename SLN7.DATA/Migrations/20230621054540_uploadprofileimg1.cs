using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SLN7.DATA.Migrations
{
    public partial class uploadprofileimg1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "tblUploadFile",
                type: "int",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserId",
                table: "tblUploadFile");
        }
    }
}
