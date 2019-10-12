using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LibraryProject.Migrations
{
    public partial class AllTablesAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BookInfos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    title = table.Column<string>(nullable: true),
                    author = table.Column<string>(nullable: true),
                    edition = table.Column<string>(nullable: true),
                    barcode = table.Column<string>(nullable: true),
                    copyCount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookInfos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StudentInfos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(nullable: true),
                    fineAmount = table.Column<float>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentInfos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "IssueBooks",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentID = table.Column<int>(nullable: false),
                    bookId = table.Column<int>(nullable: false),
                    bookBarcode = table.Column<string>(nullable: true),
                    issueDate = table.Column<DateTime>(nullable: false),
                    returnDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IssueBooks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IssueBooks_StudentInfos_StudentID",
                        column: x => x.StudentID,
                        principalTable: "StudentInfos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IssueBooks_BookInfos_bookId",
                        column: x => x.bookId,
                        principalTable: "BookInfos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_IssueBooks_StudentID",
                table: "IssueBooks",
                column: "StudentID");

            migrationBuilder.CreateIndex(
                name: "IX_IssueBooks_bookId",
                table: "IssueBooks",
                column: "bookId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IssueBooks");

            migrationBuilder.DropTable(
                name: "StudentInfos");

            migrationBuilder.DropTable(
                name: "BookInfos");
        }
    }
}
