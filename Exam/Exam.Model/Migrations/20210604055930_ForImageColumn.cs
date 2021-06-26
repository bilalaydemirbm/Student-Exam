using Microsoft.EntityFrameworkCore.Migrations;

namespace Exam.Model.Migrations
{
    public partial class ForImageColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ProfileBacgroundImageURL",
                table: "Students",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ProfileImageURL",
                table: "Students",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProfileBacgroundImageURL",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "ProfileImageURL",
                table: "Students");
        }
    }
}
