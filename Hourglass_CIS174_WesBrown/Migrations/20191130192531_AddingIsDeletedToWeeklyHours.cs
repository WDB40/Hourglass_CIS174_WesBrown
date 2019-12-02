using Microsoft.EntityFrameworkCore.Migrations;

namespace Hourglass_CIS174_WesBrown.Migrations
{
    public partial class AddingIsDeletedToWeeklyHours : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "WeeklyHours",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "WeeklyHours");
        }
    }
}
