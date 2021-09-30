using Microsoft.EntityFrameworkCore.Migrations;

namespace Maway.Data.Migrations
{
    public partial class initial2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItemPrice_ItemTypes_ItemTypeId",
                table: "ItemPrice");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ItemPrice",
                table: "ItemPrice");

            migrationBuilder.RenameTable(
                name: "ItemPrice",
                newName: "ItemTypePrices");

            migrationBuilder.RenameIndex(
                name: "IX_ItemPrice_ItemTypeId",
                table: "ItemTypePrices",
                newName: "IX_ItemTypePrices_ItemTypeId");

            migrationBuilder.AlterColumn<int>(
                name: "ItemTypeId",
                table: "ItemTypePrices",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ItemTypePrices",
                table: "ItemTypePrices",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ItemTypePrices_ItemTypes_ItemTypeId",
                table: "ItemTypePrices",
                column: "ItemTypeId",
                principalTable: "ItemTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItemTypePrices_ItemTypes_ItemTypeId",
                table: "ItemTypePrices");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ItemTypePrices",
                table: "ItemTypePrices");

            migrationBuilder.RenameTable(
                name: "ItemTypePrices",
                newName: "ItemPrice");

            migrationBuilder.RenameIndex(
                name: "IX_ItemTypePrices_ItemTypeId",
                table: "ItemPrice",
                newName: "IX_ItemPrice_ItemTypeId");

            migrationBuilder.AlterColumn<int>(
                name: "ItemTypeId",
                table: "ItemPrice",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddPrimaryKey(
                name: "PK_ItemPrice",
                table: "ItemPrice",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ItemPrice_ItemTypes_ItemTypeId",
                table: "ItemPrice",
                column: "ItemTypeId",
                principalTable: "ItemTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
