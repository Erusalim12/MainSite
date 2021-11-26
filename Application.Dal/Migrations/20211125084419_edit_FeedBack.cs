using Microsoft.EntityFrameworkCore.Migrations;

namespace Application.Dal.Migrations
{
    public partial class edit_FeedBack : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
           
            migrationBuilder.AddColumn<bool>(
                name: "IsVisit",
                table: "Answers",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsVisit",
                table: "Answers");

            
        }
    }
}
