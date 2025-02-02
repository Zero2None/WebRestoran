using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebRestoran.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "Ingredients",
                columns: table => new
                {
                    IngredientId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IngredientName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ingredients", x => x.IngredientId);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    OrderId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TotalAmmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    OrderDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.OrderId);
                    table.ForeignKey(
                        name: "FK_Orders_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Food",
                columns: table => new
                {
                    FoodId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FoodName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageThumbnailUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    Stock = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Food", x => x.FoodId);
                    table.ForeignKey(
                        name: "FK_Food_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FoodIngredients",
                columns: table => new
                {
                    FoodId = table.Column<int>(type: "int", nullable: false),
                    IngredientId = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FoodIngredients", x => new { x.FoodId, x.IngredientId });
                    table.ForeignKey(
                        name: "FK_FoodIngredients_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "CategoryId");
                    table.ForeignKey(
                        name: "FK_FoodIngredients_Food_FoodId",
                        column: x => x.FoodId,
                        principalTable: "Food",
                        principalColumn: "FoodId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FoodIngredients_Ingredients_IngredientId",
                        column: x => x.IngredientId,
                        principalTable: "Ingredients",
                        principalColumn: "IngredientId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderItems",
                columns: table => new
                {
                    OrderItemId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    FoodId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItems", x => x.OrderItemId);
                    table.ForeignKey(
                        name: "FK_OrderItems_Food_FoodId",
                        column: x => x.FoodId,
                        principalTable: "Food",
                        principalColumn: "FoodId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderItems_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "OrderId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "CategoryName" },
                values: new object[,]
                {
                    { 1, "Predjelo" },
                    { 2, "Glavno jelo" },
                    { 3, "Juha" },
                    { 4, "Salata" },
                    { 5, "Desert" },
                    { 6, "Piće" }
                });

            migrationBuilder.InsertData(
                table: "Ingredients",
                columns: new[] { "IngredientId", "IngredientName" },
                values: new object[,]
                {
                    { 1, "Piletina" },
                    { 2, "Junetina" },
                    { 3, "Svinjetina" },
                    { 4, "Morski plodovi" },
                    { 5, "Tofu" },
                    { 6, "Povrće" },
                    { 7, "Riža" },
                    { 8, "Tjestenina" },
                    { 9, "Stakleni rezanci" }
                });

            migrationBuilder.InsertData(
                table: "Food",
                columns: new[] { "FoodId", "CategoryId", "Description", "FoodName", "ImageThumbnailUrl", "ImageUrl", "Price", "Stock" },
                values: new object[,]
                {
                    { 1, 1, "Ukusni wok sa Piletinom i Rižom", "Wok Piletina Riža", null, null, 10.3m, 37 },
                    { 2, 1, "Ukusni wok sa Piletinom i Tjesteninom", "Wok Piletina Tjestenina", null, null, 10.6m, 43 },
                    { 3, 1, "Ukusni wok sa Piletinom i Staklenim rezancima", "Wok Piletina Stakleni rezanci", null, null, 10.9m, 53 },
                    { 4, 1, "Ukusni wok sa Junetinom i Rižom", "Wok Junetina Riža", null, null, 12.5m, 25 },
                    { 5, 1, "Ukusni wok sa Junetinom i Tjesteninom", "Wok Junetina Tjestenina", null, null, 12.9m, 38 },
                    { 6, 1, "Ukusni wok sa Junetinom i Staklenim rezancima", "Wok Junetina Stakleni rezanci", null, null, 13.1m, 55 },
                    { 7, 1, "Ukusni wok sa Svinjetinom i Rižom", "Wok Svinjetina Riža", null, null, 10.5m, 37 },
                    { 8, 1, "Ukusni wok sa Svinjetinom i Tjesteninom", "Wok Svinjetina Tjestenina", null, null, 10.7m, 45 },
                    { 9, 1, "Ukusni wok sa Svinjetinom i Staklenim rezancima", "Wok Svinjetina Stakleni rezanci", null, null, 11.5m, 28 },
                    { 10, 1, "Ukusni wok sa Morskim plodovima i Rižom", "Wok Morski plodovi Riža", null, null, 13.5m, 42 },
                    { 11, 1, "Ukusni wok sa Morskim plodovima i Tjesteninom", "Wok Morski plodovi Tjestenina", null, null, 13.7m, 37 },
                    { 12, 1, "Ukusni wok sa Morskim plodovima i Staklenim rezancima", "Wok Morski plodovi Stakleni rezanci", null, null, 13.9m, 34 },
                    { 13, 1, "Ukusni wok sa Tofu i Rižom", "Wok Tofu Riža", null, null, 10.5m, 28 },
                    { 14, 1, "Ukusni wok sa Tofu i Tjesteninom", "Wok Tofu Tjestenina", null, null, 10.3m, 23 },
                    { 15, 1, "Ukusni wok sa Tofu i Staklenim rezancima", "Wok Tofu Stakleni rezanci", null, null, 10.8m, 36 },
                    { 16, 1, "Ukusni wok sa Povrćem i Rižom", "Wok Povrće Riža", null, null, 8.5m, 17 },
                    { 17, 1, "Ukusni wok sa Povrćem i Tjesteninom", "Wok Povrće Tjestenina", null, null, 8.5m, 43 },
                    { 18, 1, "Ukusni wok sa Povrćem i Staklenim rezancima", "Wok Povrće Stakleni rezanci", null, null, 8.5m, 36 }
                });

            migrationBuilder.InsertData(
                table: "FoodIngredients",
                columns: new[] { "FoodId", "IngredientId", "CategoryId" },
                values: new object[,]
                {
                    { 1, 1, null },
                    { 1, 7, null },
                    { 2, 1, null },
                    { 2, 8, null },
                    { 3, 1, null },
                    { 3, 9, null },
                    { 4, 2, null },
                    { 4, 7, null },
                    { 5, 2, null },
                    { 5, 8, null },
                    { 6, 2, null },
                    { 6, 9, null },
                    { 7, 3, null },
                    { 7, 7, null },
                    { 8, 3, null },
                    { 8, 8, null },
                    { 9, 3, null },
                    { 9, 9, null },
                    { 10, 4, null },
                    { 10, 7, null },
                    { 11, 4, null },
                    { 11, 8, null },
                    { 12, 4, null },
                    { 12, 9, null },
                    { 13, 5, null },
                    { 13, 7, null },
                    { 14, 5, null },
                    { 14, 8, null },
                    { 15, 5, null },
                    { 15, 9, null },
                    { 16, 6, null },
                    { 16, 7, null },
                    { 17, 6, null },
                    { 17, 8, null },
                    { 18, 6, null },
                    { 18, 9, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Food_CategoryId",
                table: "Food",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_FoodIngredients_CategoryId",
                table: "FoodIngredients",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_FoodIngredients_IngredientId",
                table: "FoodIngredients",
                column: "IngredientId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_FoodId",
                table: "OrderItems",
                column: "FoodId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_OrderId",
                table: "OrderItems",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_UserId",
                table: "Orders",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FoodIngredients");

            migrationBuilder.DropTable(
                name: "OrderItems");

            migrationBuilder.DropTable(
                name: "Ingredients");

            migrationBuilder.DropTable(
                name: "Food");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
