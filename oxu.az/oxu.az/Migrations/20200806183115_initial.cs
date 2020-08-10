using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace oxu.az.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "News",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(maxLength: 100, nullable: false),
                    CategoryId = table.Column<int>(nullable: false),
                    FileName = table.Column<string>(maxLength: 100, nullable: false),
                    Content = table.Column<string>(nullable: false),
                    Like = table.Column<int>(nullable: false),
                    Unlike = table.Column<int>(nullable: false),
                    View = table.Column<int>(nullable: false),
                    CreationTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_News", x => x.Id);
                    table.ForeignKey(
                        name: "FK_News_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Baş Səhifə" },
                    { 15, "Müsahibə" },
                    { 14, "Maraqlı" },
                    { 13, "Turizm" },
                    { 12, "İKT" },
                    { 11, "Avto-Moto" },
                    { 10, "Dünya" },
                    { 16, "Baku TV" },
                    { 9, "Mədəniyyət" },
                    { 7, "İdman" },
                    { 6, "Müharibə" },
                    { 5, "Şou-Biznes" },
                    { 4, "Cəmiyyət" },
                    { 3, "İqtisadiyyat" },
                    { 2, "Siyasət" },
                    { 8, "Kriminal" },
                    { 17, "Cinema Plus" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_News_CategoryId",
                table: "News",
                column: "CategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "News");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
