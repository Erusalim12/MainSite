using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Application.Dal.Migrations
{
    public partial class feedBackTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: "278a8ff8-b320-439b-99d6-07cf4823672d");

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: "2ce2cea4-68de-4ef4-8a2f-5fc87588e32a");

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: "5387d6fe-e1fb-4258-accb-1e1282a2fe8b");

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: "9a5db188-e4ec-40df-aa8f-815241c3bd91");

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: "a81e183b-16c5-4949-87ae-d4af13525f48");

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: "d26de467-4043-446e-8f02-ec45283fa2fe");

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: "d4b94b1f-0556-4426-9b8c-e2246063dea4");

            migrationBuilder.CreateTable(
                name: "Questions",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CustomerId = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Questions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Answers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    QuestionId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    SenderName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsAdmin = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Answers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Answers_Questions_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "Questions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Settings",
                columns: new[] { "Id", "Name", "Value" },
                values: new object[,]
                {
                    { "6405c496-82ff-4152-ba83-426d80d6499d", "StoreFilesInDb", "false" },
                    { "b80a0b07-2891-49c5-a339-8ed94aaa5555", "Application.Icon", "/images/layout_icons/header.png" },
                    { "f32925c0-7282-44e4-b9b1-3ce0478c081e", "Application.Name", "" },
                    { "258b8653-6895-4ab0-bfc2-fede455bed45", "Application.Copy", "" },
                    { "baf8880f-6c9e-4234-b937-c203559de6d3", "BirthdayPath", "http://localhost:50510/api/People/Birthdate?skip=0&take=10" },
                    { "de659cd8-d68e-429e-88bd-1c9935cec9e7", "Application.Header", "Main_Application" },
                    { "7a313309-bdab-41cc-a2b6-a25c9c5de666", "Page.PageSize", "3" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Answers_QuestionId",
                table: "Answers",
                column: "QuestionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Answers");

            migrationBuilder.DropTable(
                name: "Questions");

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: "258b8653-6895-4ab0-bfc2-fede455bed45");

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: "6405c496-82ff-4152-ba83-426d80d6499d");

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: "7a313309-bdab-41cc-a2b6-a25c9c5de666");

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: "b80a0b07-2891-49c5-a339-8ed94aaa5555");

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: "baf8880f-6c9e-4234-b937-c203559de6d3");

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: "de659cd8-d68e-429e-88bd-1c9935cec9e7");

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: "f32925c0-7282-44e4-b9b1-3ce0478c081e");

            migrationBuilder.InsertData(
                table: "Settings",
                columns: new[] { "Id", "Name", "Value" },
                values: new object[,]
                {
                    { "278a8ff8-b320-439b-99d6-07cf4823672d", "StoreFilesInDb", "false" },
                    { "d26de467-4043-446e-8f02-ec45283fa2fe", "Application.Icon", "/images/layout_icons/header.png" },
                    { "2ce2cea4-68de-4ef4-8a2f-5fc87588e32a", "Application.Name", "" },
                    { "d4b94b1f-0556-4426-9b8c-e2246063dea4", "Application.Copy", "" },
                    { "9a5db188-e4ec-40df-aa8f-815241c3bd91", "BirthdayPath", "http://localhost:50510/api/People/Birthdate?skip=0&take=10" },
                    { "a81e183b-16c5-4949-87ae-d4af13525f48", "Application.Header", "Main_Application" },
                    { "5387d6fe-e1fb-4258-accb-1e1282a2fe8b", "Page.PageSize", "3" }
                });
        }
    }
}
