using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Application.Dal.Migrations
{
    public partial class addnewTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
             

            migrationBuilder.CreateTable(
                name: "VisitiorCounter",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LastDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TodayCount = table.Column<int>(type: "int", nullable: false),
                    TotalCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VisitiorCounter", x => x.Id);
                });

        
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "birthday_Table");

            migrationBuilder.DropTable(
                name: "EventCalendars");

            migrationBuilder.DropTable(
                name: "FileBinary");

            migrationBuilder.DropTable(
                name: "Files");

            migrationBuilder.DropTable(
                name: "Permissions");

            migrationBuilder.DropTable(
                name: "Pictures");

            migrationBuilder.DropTable(
                name: "PinnedNews");

            migrationBuilder.DropTable(
                name: "PRURM");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Settings");

            migrationBuilder.DropTable(
                name: "UserInfo");

            migrationBuilder.DropTable(
                name: "UURM");

            migrationBuilder.DropTable(
                name: "VisitiorCounter");

            migrationBuilder.DropTable(
                name: "PlanCalendars");

            migrationBuilder.DropTable(
                name: "NewsItems");

            migrationBuilder.DropTable(
                name: "MenuItems");
        }
    }
}
