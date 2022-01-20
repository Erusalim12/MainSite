using Microsoft.EntityFrameworkCore.Migrations;

namespace Application.Dal.Migrations
{
    public partial class cmage_1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: "1e75e157-6fc6-4cd5-b583-e401a61ca9b7");

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: "4ac5c864-8d59-4b6a-97b7-7ed749458326");

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: "783bb945-a4f2-4911-a270-05217a58fafd");

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: "7bd75f28-05b5-438d-a816-dd99b9250e90");

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: "873f2721-de42-466a-be4a-de0c7d0d20ec");

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: "d9a22e30-44fa-4d31-abe5-8708fc7534a4");

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: "f8091314-3ada-4b88-bdb6-0e424a51c1bd");

            migrationBuilder.InsertData(
                table: "Settings",
                columns: new[] { "Id", "Name", "Value" },
                values: new object[,]
                {
                    { "f2562fff-ba63-40fb-9173-dbe37eb3a13d", "StoreFilesInDb", "false" },
                    { "965b8766-25e0-4251-b633-672bd2b4a6fe", "Application.Icon", "/images/layout_icons/header.png" },
                    { "62e64547-4120-416f-bcc6-95dc6c5c8b7a", "Application.Name", "" },
                    { "3858aeac-cdc6-4164-be70-cb5eacdc6c60", "Application.Copy", "" },
                    { "5f48f870-2e2c-440e-8575-d9299288034d", "BirthdayPath", "http://localhost:50510/api/People/Birthdate?skip=0&take=10" },
                    { "a0eecbd6-2170-4252-a4bf-6ef91e5ce67c", "Application.Header", "Main_Application" },
                    { "ac03e73e-050d-42f3-8c65-547b4bf219f5", "Page.PageSize", "3" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: "3858aeac-cdc6-4164-be70-cb5eacdc6c60");

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: "5f48f870-2e2c-440e-8575-d9299288034d");

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: "62e64547-4120-416f-bcc6-95dc6c5c8b7a");

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: "965b8766-25e0-4251-b633-672bd2b4a6fe");

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: "a0eecbd6-2170-4252-a4bf-6ef91e5ce67c");

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: "ac03e73e-050d-42f3-8c65-547b4bf219f5");

            migrationBuilder.DeleteData(
                table: "Settings",
                keyColumn: "Id",
                keyValue: "f2562fff-ba63-40fb-9173-dbe37eb3a13d");

            migrationBuilder.InsertData(
                table: "Settings",
                columns: new[] { "Id", "Name", "Value" },
                values: new object[,]
                {
                    { "873f2721-de42-466a-be4a-de0c7d0d20ec", "StoreFilesInDb", "false" },
                    { "1e75e157-6fc6-4cd5-b583-e401a61ca9b7", "Application.Icon", "/images/layout_icons/header.png" },
                    { "4ac5c864-8d59-4b6a-97b7-7ed749458326", "Application.Name", "" },
                    { "783bb945-a4f2-4911-a270-05217a58fafd", "Application.Copy", "" },
                    { "d9a22e30-44fa-4d31-abe5-8708fc7534a4", "BirthdayPath", "http://localhost:50510/api/People/Birthdate?skip=0&take=10" },
                    { "7bd75f28-05b5-438d-a816-dd99b9250e90", "Application.Header", "Main_Application" },
                    { "f8091314-3ada-4b88-bdb6-0e424a51c1bd", "Page.PageSize", "3" }
                });
        }
    }
}
