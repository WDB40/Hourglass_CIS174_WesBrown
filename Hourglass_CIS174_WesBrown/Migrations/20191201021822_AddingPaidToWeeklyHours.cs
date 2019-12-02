using Microsoft.EntityFrameworkCore.Migrations;

namespace Hourglass_CIS174_WesBrown.Migrations
{
    public partial class AddingPaidToWeeklyHours : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Paid",
                table: "WeeklyHours",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Paid",
                table: "WeeklyHours");
        }
    }
}
