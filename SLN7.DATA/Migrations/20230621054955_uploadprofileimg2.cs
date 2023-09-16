using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SLN7.DATA.Migrations
{
    public partial class uploadprofileimg2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UploadFileId",
                table: "tblUserRegistration",
                type: "int",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UploadFileId",
                table: "tblUserRegistration");
        }
    }
}
