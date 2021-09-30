using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Maway.Data.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "attributes");

            migrationBuilder.CreateTable(
                name: "Customer",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Surname = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Extras",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Price = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Extras", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ItemTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(nullable: true),
                    Image = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ItemAttribute",
                schema: "attributes",
                columns: table => new
                {
                    Key = table.Column<string>(nullable: false),
                    Icon = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemAttribute", x => x.Key);
                });

            migrationBuilder.CreateTable(
                name: "ItemExtras",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ItemTypeId = table.Column<int>(nullable: false),
                    ExtrasId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemExtras", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ItemExtras_Extras_ExtrasId",
                        column: x => x.ExtrasId,
                        principalTable: "Extras",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ItemExtras_ItemTypes_ItemTypeId",
                        column: x => x.ItemTypeId,
                        principalTable: "ItemTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ItemPrice",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MinimumDays = table.Column<int>(nullable: false),
                    Price = table.Column<decimal>(nullable: false),
                    ItemTypeId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemPrice", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ItemPrice_ItemTypes_ItemTypeId",
                        column: x => x.ItemTypeId,
                        principalTable: "ItemTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ItemTypeId = table.Column<int>(nullable: false),
                    CompanyRegistryId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Items_ItemTypes_ItemTypeId",
                        column: x => x.ItemTypeId,
                        principalTable: "ItemTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ItemAttributes",
                schema: "attributes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ItemTypeId = table.Column<int>(nullable: false),
                    AttributeKey = table.Column<string>(nullable: true),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemAttributes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ItemAttributes_ItemAttribute_AttributeKey",
                        column: x => x.AttributeKey,
                        principalSchema: "attributes",
                        principalTable: "ItemAttribute",
                        principalColumn: "Key",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ItemAttributes_ItemTypes_ItemTypeId",
                        column: x => x.ItemTypeId,
                        principalTable: "ItemTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: false),
                    From = table.Column<DateTime>(nullable: false),
                    To = table.Column<DateTime>(nullable: false),
                    Price = table.Column<decimal>(nullable: false),
                    ItemId = table.Column<int>(nullable: true),
                    CustomerId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Order_Customer_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Order_Items_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Items",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OrderSupplements",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderId = table.Column<int>(nullable: false),
                    ExtrasId = table.Column<int>(nullable: false),
                    SupplementsId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderSupplements", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderSupplements_Order_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Order",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderSupplements_ItemExtras_SupplementsId",
                        column: x => x.SupplementsId,
                        principalTable: "ItemExtras",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "ItemTypes",
                columns: new[] { "Id", "Image", "Title" },
                values: new object[,]
                {
                    { 1, "someimage.png", "fiat 500" },
                    { 2, "someimage.png", "fiat tipo" },
                    { 3, "someimage.png", "leon" },
                    { 4, "someimage.png", "vespa" }
                });

            migrationBuilder.InsertData(
                schema: "attributes",
                table: "ItemAttribute",
                columns: new[] { "Key", "Icon" },
                values: new object[,]
                {
                    { "Gearbox", "cog" },
                    { "AirCondition", "snowflage" },
                    { "FuelType", "gaspump" },
                    { "Doors", "dooropen" }
                });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "CompanyRegistryId", "ItemTypeId" },
                values: new object[,]
                {
                    { 1, "KR123", 1 },
                    { 2, "KR124", 2 },
                    { 3, "KR125", 3 }
                });

            migrationBuilder.InsertData(
                schema: "attributes",
                table: "ItemAttributes",
                columns: new[] { "Id", "AttributeKey", "ItemTypeId", "Value" },
                values: new object[,]
                {
                    { 1, "Gearbox", 1, "Manual" },
                    { 2, "AirCondition", 1, "Air condition" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ItemExtras_ExtrasId",
                table: "ItemExtras",
                column: "ExtrasId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemExtras_ItemTypeId",
                table: "ItemExtras",
                column: "ItemTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemPrice_ItemTypeId",
                table: "ItemPrice",
                column: "ItemTypeId");

            migrationBuilder.CreateIndex(
                name: "Item_Registry_Id",
                table: "Items",
                column: "CompanyRegistryId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Items_ItemTypeId",
                table: "Items",
                column: "ItemTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_CustomerId",
                table: "Order",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_ItemId",
                table: "Order",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderSupplements_OrderId",
                table: "OrderSupplements",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderSupplements_SupplementsId",
                table: "OrderSupplements",
                column: "SupplementsId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemAttributes_AttributeKey",
                schema: "attributes",
                table: "ItemAttributes",
                column: "AttributeKey");

            migrationBuilder.CreateIndex(
                name: "Item_Attribute",
                schema: "attributes",
                table: "ItemAttributes",
                columns: new[] { "ItemTypeId", "AttributeKey" },
                unique: true,
                filter: "[AttributeKey] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ItemPrice");

            migrationBuilder.DropTable(
                name: "OrderSupplements");

            migrationBuilder.DropTable(
                name: "ItemAttributes",
                schema: "attributes");

            migrationBuilder.DropTable(
                name: "Order");

            migrationBuilder.DropTable(
                name: "ItemExtras");

            migrationBuilder.DropTable(
                name: "ItemAttribute",
                schema: "attributes");

            migrationBuilder.DropTable(
                name: "Customer");

            migrationBuilder.DropTable(
                name: "Items");

            migrationBuilder.DropTable(
                name: "Extras");

            migrationBuilder.DropTable(
                name: "ItemTypes");
        }
    }
}
