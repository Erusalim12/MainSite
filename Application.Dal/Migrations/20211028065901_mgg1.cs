using Microsoft.EntityFrameworkCore.Migrations;

namespace Application.Dal.Migrations
{
    public partial class mgg1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.RenameColumn(
                name: "AutorFio",
                table: "NewsItems",
                newName: "AuthorFio");


            migrationBuilder.AddColumn<string>(
                name: "LastChangeAuthorId",
                table: "NewsItems",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AuthorId",
                table: "NewsItems",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Settings",
                columns: new[] { "Id", "Name", "Value" },
                values: new object[,]
                {
                    { "494c9101-ed51-4759-9eeb-3d8a162fd46a", "StoreFilesInDb", "false" },
                    { "6fa94d80-813e-42ce-a105-6c732916e155", "Application.Icon", "/images/layout_icons/header.png" },
                    { "ecfac765-3e27-4947-998d-df044267811d", "Application.Name", "" },
                    { "6ddcf279-3609-4bde-8b1a-03071010a788", "Application.Copy", "" },
                    { "fec5e22e-3daa-4aa8-ba49-9437c93d401e", "BirthdayPath", "http://localhost:50510/api/People/Birthdate?skip=0&take=10" },
                    { "c8cbd4bb-806c-4795-8faf-f73c96457ba2", "Application.Header", "Main_Application" },
                    { "dbfaca9d-c8d4-4851-9ec8-4f9ea07028c3", "Page.PageSize", "3" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: "494c9101-ed51-4759-9eeb-3d8a162fd46a");

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: "6ddcf279-3609-4bde-8b1a-03071010a788");

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: "6fa94d80-813e-42ce-a105-6c732916e155");

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: "c8cbd4bb-806c-4795-8faf-f73c96457ba2");

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: "dbfaca9d-c8d4-4851-9ec8-4f9ea07028c3");

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: "ecfac765-3e27-4947-998d-df044267811d");

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: "fec5e22e-3daa-4aa8-ba49-9437c93d401e");



            migrationBuilder.DropColumn(
                name: "AuthorId",
                table: "NewsItems");

            migrationBuilder.DropColumn(
                name: "LastChangeAuthorId",
                table: "NewsItems");

            migrationBuilder.RenameColumn(
                name: "AuthorFio",
                table: "NewsItems",
                newName: "AutorFio");

            migrationBuilder.RenameColumn(
                name: "LastChangeAuthor",
                table: "NewsItems",
                newName: "LastChangeAuthorFio");

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
        }
    }
}
