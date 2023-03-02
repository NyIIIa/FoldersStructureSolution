using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FoldersStructure_Client.Migrations
{
    /// <inheritdoc />
    public partial class InnitDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Folders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    ParentFolderName = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Folders", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Folders",
                columns: new[] { "Id", "Name", "ParentFolderName" },
                values: new object[,]
                {
                    { 1, "Creating Digital Images", "" },
                    { 2, "Resources", "Creating Digital Images" },
                    { 3, "Evidence", "Creating Digital Images" },
                    { 4, "Graphic Products", "Creating Digital Images" },
                    { 5, "Primary Sources", "Resources" },
                    { 6, "Secondary Sources", "Resources" },
                    { 7, "Process", "Graphic Products" },
                    { 8, "Final Product", "Graphic Products" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Folders");
        }
    }
}
