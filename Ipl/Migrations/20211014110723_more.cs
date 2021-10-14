using Microsoft.EntityFrameworkCore.Migrations;

namespace Ipl.Migrations
{
    public partial class more : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductTypes_Categories_CategoryId",
                table: "ProductTypes");

            migrationBuilder.RenameColumn(
                name: "Prise",
                table: "ProductTypes",
                newName: "Price");

            migrationBuilder.AlterColumn<int>(
                name: "CategoryId",
                table: "ProductTypes",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductTypes_Categories_CategoryId",
                table: "ProductTypes",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "CategoryId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductTypes_Categories_CategoryId",
                table: "ProductTypes");

            migrationBuilder.RenameColumn(
                name: "Price",
                table: "ProductTypes",
                newName: "Prise");

            migrationBuilder.AlterColumn<int>(
                name: "CategoryId",
                table: "ProductTypes",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductTypes_Categories_CategoryId",
                table: "ProductTypes",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "CategoryId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
