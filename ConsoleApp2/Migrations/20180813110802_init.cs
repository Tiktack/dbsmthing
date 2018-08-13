using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ConsoleApp2.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Authors",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Authors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Languages",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Languages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Publishers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Publishers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sales_Notes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sales_Notes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Series",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Series", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    url = table.Column<string>(nullable: true),
                    price = table.Column<double>(nullable: false),
                    oldprice = table.Column<double>(nullable: false),
                    currencyId = table.Column<string>(nullable: true),
                    categoryId = table.Column<int>(nullable: false),
                    store = table.Column<bool>(nullable: false),
                    pickup = table.Column<bool>(nullable: false),
                    delivery = table.Column<bool>(nullable: false),
                    local_delivery_cost = table.Column<long>(nullable: false),
                    AuthorId = table.Column<int>(nullable: false),
                    name = table.Column<string>(nullable: true),
                    publisherId = table.Column<int>(nullable: true),
                    seriesId = table.Column<int>(nullable: true),
                    year = table.Column<string>(nullable: true),
                    iSBN = table.Column<string>(nullable: true),
                    languageId = table.Column<int>(nullable: true),
                    binding = table.Column<string>(nullable: true),
                    page_extent = table.Column<string>(nullable: true),
                    description = table.Column<string>(nullable: true),
                    sales_notesId = table.Column<int>(nullable: true),
                    manufacturer_warranty = table.Column<bool>(nullable: false),
                    barcode = table.Column<decimal>(nullable: false),
                    weight = table.Column<decimal>(nullable: false),
                    dimensions = table.Column<string>(maxLength: 70, nullable: true),
                    available = table.Column<bool>(nullable: false),
                    type = table.Column<string>(maxLength: 70, nullable: true),
                    group_id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.id);
                    table.ForeignKey(
                        name: "FK_Books_Languages_languageId",
                        column: x => x.languageId,
                        principalTable: "Languages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Books_Publishers_publisherId",
                        column: x => x.publisherId,
                        principalTable: "Publishers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Books_Sales_Notes_sales_notesId",
                        column: x => x.sales_notesId,
                        principalTable: "Sales_Notes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Books_Series_seriesId",
                        column: x => x.seriesId,
                        principalTable: "Series",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Params",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    paramName = table.Column<string>(nullable: true),
                    paramUnit = table.Column<string>(nullable: true),
                    paramValue = table.Column<string>(nullable: true),
                    Bookid = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Params", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Params_Books_Bookid",
                        column: x => x.Bookid,
                        principalTable: "Books",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Pictures",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    pictureUrl = table.Column<string>(nullable: true),
                    Bookid = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pictures", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pictures_Books_Bookid",
                        column: x => x.Bookid,
                        principalTable: "Books",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Books_languageId",
                table: "Books",
                column: "languageId");

            migrationBuilder.CreateIndex(
                name: "IX_Books_publisherId",
                table: "Books",
                column: "publisherId");

            migrationBuilder.CreateIndex(
                name: "IX_Books_sales_notesId",
                table: "Books",
                column: "sales_notesId");

            migrationBuilder.CreateIndex(
                name: "IX_Books_seriesId",
                table: "Books",
                column: "seriesId");

            migrationBuilder.CreateIndex(
                name: "IX_Params_Bookid",
                table: "Params",
                column: "Bookid");

            migrationBuilder.CreateIndex(
                name: "IX_Pictures_Bookid",
                table: "Pictures",
                column: "Bookid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Authors");

            migrationBuilder.DropTable(
                name: "Params");

            migrationBuilder.DropTable(
                name: "Pictures");

            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "Languages");

            migrationBuilder.DropTable(
                name: "Publishers");

            migrationBuilder.DropTable(
                name: "Sales_Notes");

            migrationBuilder.DropTable(
                name: "Series");
        }
    }
}
