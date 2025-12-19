using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LibraryManagementSystem.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    Author = table.Column<string>(type: "TEXT", nullable: false),
                    Price = table.Column<double>(type: "REAL", nullable: false),
                    Likes = table.Column<int>(type: "INTEGER", nullable: false),
                    Review = table.Column<string>(type: "TEXT", nullable: false),
                    CategoryId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Books_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "ID", "Author", "CategoryId", "Description", "Likes", "Price", "Review", "Title" },
                values: new object[,]
                {
                    { 1, "Author A1", 1, "First action book", 10, 100.0, "Sample Review 1", "Action Book 1" },
                    { 2, "Author A2", 1, "Second action book", 15, 120.0, "Sample Review 2", "Action Book 2" },
                    { 3, "Author A3", 1, "Third action book", 20, 150.0, "Sample Review 3", "Action Book 3" },
                    { 4, "Author S1", 2, "First scifi book", 12, 230.0, "Sample review 1", "SciFi Book 1" },
                    { 5, "Author S2", 2, "Second scifi book", 18, 230.0, "Sample review 3", "SciFi Book 2" },
                    { 6, "Author S3", 2, "Third scifi book", 22, 230.0, "Sample review 4", "SciFi Book 3" },
                    { 7, "Author N1", 3, "First non fiction book", 8, 450.5, "Sample review book 1", "Non Fiction Book 1" },
                    { 8, "Author N2", 3, "Second non fiction book", 14, 600.0, "Sample review book 2", "Non Fiction Book 2" },
                    { 9, "Author N3", 3, "Third non fiction book", 19, 580.0, "Sample review book 3", "Non Fiction Book 3" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Books_CategoryId",
                table: "Books",
                column: "CategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Books");
        }
    }
}
