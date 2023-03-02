using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FoldersStructure_Client.Migrations
{
    /// <inheritdoc />
    public partial class AddSourceColumnToFolderTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Source",
                table: "Folders",
                type: "TEXT",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Folders",
                keyColumn: "Id",
                keyValue: 1,
                column: "Source",
                value: "BaseScheme");

            migrationBuilder.UpdateData(
                table: "Folders",
                keyColumn: "Id",
                keyValue: 2,
                column: "Source",
                value: "BaseScheme");

            migrationBuilder.UpdateData(
                table: "Folders",
                keyColumn: "Id",
                keyValue: 3,
                column: "Source",
                value: "BaseScheme");

            migrationBuilder.UpdateData(
                table: "Folders",
                keyColumn: "Id",
                keyValue: 4,
                column: "Source",
                value: "BaseScheme");

            migrationBuilder.UpdateData(
                table: "Folders",
                keyColumn: "Id",
                keyValue: 5,
                column: "Source",
                value: "BaseScheme");

            migrationBuilder.UpdateData(
                table: "Folders",
                keyColumn: "Id",
                keyValue: 6,
                column: "Source",
                value: "BaseScheme");

            migrationBuilder.UpdateData(
                table: "Folders",
                keyColumn: "Id",
                keyValue: 7,
                column: "Source",
                value: "BaseScheme");

            migrationBuilder.UpdateData(
                table: "Folders",
                keyColumn: "Id",
                keyValue: 8,
                column: "Source",
                value: "BaseScheme");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Source",
                table: "Folders");
        }
    }
}
