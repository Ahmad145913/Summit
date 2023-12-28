using Microsoft.EntityFrameworkCore.Migrations;

namespace SummitSchool.Migrations
{
    public partial class new_com : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PhoneNumer",
                table: "AspNetUsers");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "PhoneNumer",
                table: "AspNetUsers",
                type: "float",
                nullable: true);
        }
    }
}
