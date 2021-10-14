using Microsoft.EntityFrameworkCore.Migrations;

namespace Ipl.Migrations
{
    public partial class newTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Offers",
                columns: table => new
                {
                    OfferId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(type: "TEXT", nullable: true),
                    Percentage = table.Column<byte>(type: "INTEGER", nullable: false),
                    Reason = table.Column<string>(type: "TEXT", nullable: true),
                    Active = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Offers", x => x.OfferId);
                });

            migrationBuilder.CreateTable(
                name: "OfferProductType",
                columns: table => new
                {
                    OfferId = table.Column<int>(type: "INTEGER", nullable: false),
                    ProductTypeId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OfferProductType", x => new { x.OfferId, x.ProductTypeId });
                    table.ForeignKey(
                        name: "FK_OfferProductType_Offers_OfferId",
                        column: x => x.OfferId,
                        principalTable: "Offers",
                        principalColumn: "OfferId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OfferProductType_ProductTypes_ProductTypeId",
                        column: x => x.ProductTypeId,
                        principalTable: "ProductTypes",
                        principalColumn: "ProductTypeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OfferProductType_ProductTypeId",
                table: "OfferProductType",
                column: "ProductTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OfferProductType");

            migrationBuilder.DropTable(
                name: "Offers");
        }
    }
}
