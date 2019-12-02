using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Hourglass_CIS174_WesBrown.Migrations
{
    public partial class InitialHourglassMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FirstName = table.Column<string>(maxLength: 25, nullable: false),
                    LastName = table.Column<string>(maxLength: 25, nullable: false),
                    PayRate = table.Column<double>(nullable: false),
                    RemainingPtoHours = table.Column<double>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PtoRequests",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    EmployeeId = table.Column<int>(nullable: false),
                    RequestDate = table.Column<DateTime>(nullable: false),
                    RequestedHours = table.Column<double>(nullable: false),
                    Approved = table.Column<bool>(nullable: false),
                    IsDeleted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PtoRequests", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WeeklyHours",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    EmployeeId = table.Column<int>(nullable: false),
                    TotalHours = table.Column<double>(nullable: false),
                    RegularHours = table.Column<double>(nullable: false),
                    OvertimeHours = table.Column<double>(nullable: false),
                    PtoHours = table.Column<double>(nullable: false),
                    WeekStartDate = table.Column<DateTime>(nullable: false),
                    WeekEndtDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WeeklyHours", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "PtoRequests");

            migrationBuilder.DropTable(
                name: "WeeklyHours");
        }
    }
}
