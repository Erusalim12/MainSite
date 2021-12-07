using Microsoft.EntityFrameworkCore.Migrations;

namespace Application.Dal.Migrations
{
    public partial class g1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: "019c5e18-eab9-4011-952d-6c3848c60c58");

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: "2e700301-c2a5-4244-9608-24af05269691");

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: "41b9ffdf-e93f-4ad1-bffe-c010ba2f397e");

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: "5f8ebbba-c558-4903-ac57-07e44044b808");

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: "7d5d8b03-1d99-491d-95fb-f0cccb3c73db");

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: "8b0a3312-17c5-40a5-b26c-41293f11d890");

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: "d868b2fd-2a72-45f7-a7ad-8b5366c953cb");

            migrationBuilder.AddColumn<int>(
                name: "TotalDailyCount",
                table: "VisitiorCounter",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TotalNotUniqueCount",
                table: "VisitiorCounter",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "Settings",
                columns: new[] { "Id", "Name", "Value" },
                values: new object[,]
                {
                    { "745ae46d-dbc4-4184-970a-186d46d3ddce", "StoreFilesInDb", "false" },
                    { "81d911ac-2d16-47ce-9278-b176e4e4a8d8", "Application.Icon", "/images/layout_icons/header.png" },
                    { "769f6ba4-483f-4b90-ba6a-b6150df72299", "Application.Name", "" },
                    { "2a56db7b-3d7d-4ffa-8356-7f02e9856ebe", "Application.Copy", "" },
                    { "b3fd8208-b087-4a17-9a80-19644f9398ec", "BirthdayPath", "http://localhost:50510/api/People/Birthdate?skip=0&take=10" },
                    { "6c13f9e1-2b9c-44a8-ba6a-217754d2505f", "Application.Header", "Main_Application" },
                    { "b2d83e42-ea66-4805-a99a-a23c16201dfa", "Page.PageSize", "3" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: "2a56db7b-3d7d-4ffa-8356-7f02e9856ebe");

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: "6c13f9e1-2b9c-44a8-ba6a-217754d2505f");

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: "745ae46d-dbc4-4184-970a-186d46d3ddce");

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: "769f6ba4-483f-4b90-ba6a-b6150df72299");

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: "81d911ac-2d16-47ce-9278-b176e4e4a8d8");

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: "b2d83e42-ea66-4805-a99a-a23c16201dfa");

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: "b3fd8208-b087-4a17-9a80-19644f9398ec");

            migrationBuilder.DropColumn(
                name: "TotalDailyCount",
                table: "VisitiorCounter");

            migrationBuilder.DropColumn(
                name: "TotalNotUniqueCount",
                table: "VisitiorCounter");

            migrationBuilder.InsertData(
                table: "Settings",
                columns: new[] { "Id", "Name", "Value" },
                values: new object[,]
                {
                    { "41b9ffdf-e93f-4ad1-bffe-c010ba2f397e", "StoreFilesInDb", "false" },
                    { "8b0a3312-17c5-40a5-b26c-41293f11d890", "Application.Icon", "/images/layout_icons/header.png" },
                    { "7d5d8b03-1d99-491d-95fb-f0cccb3c73db", "Application.Name", "" },
                    { "2e700301-c2a5-4244-9608-24af05269691", "Application.Copy", "" },
                    { "5f8ebbba-c558-4903-ac57-07e44044b808", "BirthdayPath", "http://localhost:50510/api/People/Birthdate?skip=0&take=10" },
                    { "d868b2fd-2a72-45f7-a7ad-8b5366c953cb", "Application.Header", "Main_Application" },
                    { "019c5e18-eab9-4011-952d-6c3848c60c58", "Page.PageSize", "3" }
                });
        }
    }
}
