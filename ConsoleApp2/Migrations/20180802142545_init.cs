using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ConsoleApp2.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    idField = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    urlField = table.Column<string>(nullable: true),
                    priceField = table.Column<double>(nullable: false),
                    oldpriceField = table.Column<double>(nullable: false),
                    currencyIdField = table.Column<string>(nullable: true),
                    categoryIdField = table.Column<int>(nullable: false),
                    storeField = table.Column<bool>(nullable: false),
                    pickupField = table.Column<bool>(nullable: false),
                    deliveryField = table.Column<bool>(nullable: false),
                    local_delivery_costField = table.Column<long>(nullable: false),
                    authorField = table.Column<string>(nullable: true),
                    nameField = table.Column<string>(nullable: true),
                    publisherField = table.Column<string>(nullable: true),
                    seriesField = table.Column<string>(nullable: true),
                    yearField = table.Column<string>(nullable: true),
                    iSBNField = table.Column<string>(nullable: true),
                    languageField = table.Column<string>(nullable: true),
                    bindingField = table.Column<string>(nullable: true),
                    page_extentField = table.Column<string>(nullable: true),
                    descriptionField = table.Column<string>(nullable: true),
                    sales_notesField = table.Column<string>(nullable: true),
                    manufacturer_warrantyField = table.Column<bool>(nullable: false),
                    barcodeField = table.Column<decimal>(nullable: false),
                    weightField = table.Column<decimal>(nullable: false),
                    dimensionsField = table.Column<string>(nullable: true),
                    availableField = table.Column<bool>(nullable: false),
                    typeField = table.Column<string>(nullable: true),
                    group_idField = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.idField);
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
                    BookidField = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Params", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Params_Books_BookidField",
                        column: x => x.BookidField,
                        principalTable: "Books",
                        principalColumn: "idField",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Pictures",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    pictureUrl = table.Column<string>(nullable: true),
                    BookidField = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pictures", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pictures_Books_BookidField",
                        column: x => x.BookidField,
                        principalTable: "Books",
                        principalColumn: "idField",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Params_BookidField",
                table: "Params",
                column: "BookidField");

            migrationBuilder.CreateIndex(
                name: "IX_Pictures_BookidField",
                table: "Pictures",
                column: "BookidField");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Params");

            migrationBuilder.DropTable(
                name: "Pictures");

            migrationBuilder.DropTable(
                name: "Books");
        }
    }
}
