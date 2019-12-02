using Microsoft.EntityFrameworkCore.Migrations;

namespace Hourglass_CIS174_WesBrown.Migrations
{
    public partial class AddingIsDeletedToPayments : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Payments",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Payments");
        }
    }
}
