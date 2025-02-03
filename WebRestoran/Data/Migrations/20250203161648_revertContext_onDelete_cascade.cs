using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebRestoran.Data.Migrations
{
    /// <inheritdoc />
    public partial class revertContext_onDelete_cascade : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FoodIngredients_Categories_CategoryId",
                table: "FoodIngredients");

            migrationBuilder.DropIndex(
                name: "IX_FoodIngredients_CategoryId",
                table: "FoodIngredients");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "FoodIngredients");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "FoodIngredients",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "FoodIngredients",
                keyColumns: new[] { "FoodId", "IngredientId" },
                keyValues: new object[] { 1, 1 },
                column: "CategoryId",
                value: null);

            migrationBuilder.UpdateData(
                table: "FoodIngredients",
                keyColumns: new[] { "FoodId", "IngredientId" },
                keyValues: new object[] { 1, 7 },
                column: "CategoryId",
                value: null);

            migrationBuilder.UpdateData(
                table: "FoodIngredients",
                keyColumns: new[] { "FoodId", "IngredientId" },
                keyValues: new object[] { 2, 1 },
                column: "CategoryId",
                value: null);

            migrationBuilder.UpdateData(
                table: "FoodIngredients",
                keyColumns: new[] { "FoodId", "IngredientId" },
                keyValues: new object[] { 2, 8 },
                column: "CategoryId",
                value: null);

            migrationBuilder.UpdateData(
                table: "FoodIngredients",
                keyColumns: new[] { "FoodId", "IngredientId" },
                keyValues: new object[] { 3, 1 },
                column: "CategoryId",
                value: null);

            migrationBuilder.UpdateData(
                table: "FoodIngredients",
                keyColumns: new[] { "FoodId", "IngredientId" },
                keyValues: new object[] { 3, 9 },
                column: "CategoryId",
                value: null);

            migrationBuilder.UpdateData(
                table: "FoodIngredients",
                keyColumns: new[] { "FoodId", "IngredientId" },
                keyValues: new object[] { 4, 2 },
                column: "CategoryId",
                value: null);

            migrationBuilder.UpdateData(
                table: "FoodIngredients",
                keyColumns: new[] { "FoodId", "IngredientId" },
                keyValues: new object[] { 4, 7 },
                column: "CategoryId",
                value: null);

            migrationBuilder.UpdateData(
                table: "FoodIngredients",
                keyColumns: new[] { "FoodId", "IngredientId" },
                keyValues: new object[] { 5, 2 },
                column: "CategoryId",
                value: null);

            migrationBuilder.UpdateData(
                table: "FoodIngredients",
                keyColumns: new[] { "FoodId", "IngredientId" },
                keyValues: new object[] { 5, 8 },
                column: "CategoryId",
                value: null);

            migrationBuilder.UpdateData(
                table: "FoodIngredients",
                keyColumns: new[] { "FoodId", "IngredientId" },
                keyValues: new object[] { 6, 2 },
                column: "CategoryId",
                value: null);

            migrationBuilder.UpdateData(
                table: "FoodIngredients",
                keyColumns: new[] { "FoodId", "IngredientId" },
                keyValues: new object[] { 6, 9 },
                column: "CategoryId",
                value: null);

            migrationBuilder.UpdateData(
                table: "FoodIngredients",
                keyColumns: new[] { "FoodId", "IngredientId" },
                keyValues: new object[] { 7, 3 },
                column: "CategoryId",
                value: null);

            migrationBuilder.UpdateData(
                table: "FoodIngredients",
                keyColumns: new[] { "FoodId", "IngredientId" },
                keyValues: new object[] { 7, 7 },
                column: "CategoryId",
                value: null);

            migrationBuilder.UpdateData(
                table: "FoodIngredients",
                keyColumns: new[] { "FoodId", "IngredientId" },
                keyValues: new object[] { 8, 3 },
                column: "CategoryId",
                value: null);

            migrationBuilder.UpdateData(
                table: "FoodIngredients",
                keyColumns: new[] { "FoodId", "IngredientId" },
                keyValues: new object[] { 8, 8 },
                column: "CategoryId",
                value: null);

            migrationBuilder.UpdateData(
                table: "FoodIngredients",
                keyColumns: new[] { "FoodId", "IngredientId" },
                keyValues: new object[] { 9, 3 },
                column: "CategoryId",
                value: null);

            migrationBuilder.UpdateData(
                table: "FoodIngredients",
                keyColumns: new[] { "FoodId", "IngredientId" },
                keyValues: new object[] { 9, 9 },
                column: "CategoryId",
                value: null);

            migrationBuilder.UpdateData(
                table: "FoodIngredients",
                keyColumns: new[] { "FoodId", "IngredientId" },
                keyValues: new object[] { 10, 4 },
                column: "CategoryId",
                value: null);

            migrationBuilder.UpdateData(
                table: "FoodIngredients",
                keyColumns: new[] { "FoodId", "IngredientId" },
                keyValues: new object[] { 10, 7 },
                column: "CategoryId",
                value: null);

            migrationBuilder.UpdateData(
                table: "FoodIngredients",
                keyColumns: new[] { "FoodId", "IngredientId" },
                keyValues: new object[] { 11, 4 },
                column: "CategoryId",
                value: null);

            migrationBuilder.UpdateData(
                table: "FoodIngredients",
                keyColumns: new[] { "FoodId", "IngredientId" },
                keyValues: new object[] { 11, 8 },
                column: "CategoryId",
                value: null);

            migrationBuilder.UpdateData(
                table: "FoodIngredients",
                keyColumns: new[] { "FoodId", "IngredientId" },
                keyValues: new object[] { 12, 4 },
                column: "CategoryId",
                value: null);

            migrationBuilder.UpdateData(
                table: "FoodIngredients",
                keyColumns: new[] { "FoodId", "IngredientId" },
                keyValues: new object[] { 12, 9 },
                column: "CategoryId",
                value: null);

            migrationBuilder.UpdateData(
                table: "FoodIngredients",
                keyColumns: new[] { "FoodId", "IngredientId" },
                keyValues: new object[] { 13, 5 },
                column: "CategoryId",
                value: null);

            migrationBuilder.UpdateData(
                table: "FoodIngredients",
                keyColumns: new[] { "FoodId", "IngredientId" },
                keyValues: new object[] { 13, 7 },
                column: "CategoryId",
                value: null);

            migrationBuilder.UpdateData(
                table: "FoodIngredients",
                keyColumns: new[] { "FoodId", "IngredientId" },
                keyValues: new object[] { 14, 5 },
                column: "CategoryId",
                value: null);

            migrationBuilder.UpdateData(
                table: "FoodIngredients",
                keyColumns: new[] { "FoodId", "IngredientId" },
                keyValues: new object[] { 14, 8 },
                column: "CategoryId",
                value: null);

            migrationBuilder.UpdateData(
                table: "FoodIngredients",
                keyColumns: new[] { "FoodId", "IngredientId" },
                keyValues: new object[] { 15, 5 },
                column: "CategoryId",
                value: null);

            migrationBuilder.UpdateData(
                table: "FoodIngredients",
                keyColumns: new[] { "FoodId", "IngredientId" },
                keyValues: new object[] { 15, 9 },
                column: "CategoryId",
                value: null);

            migrationBuilder.UpdateData(
                table: "FoodIngredients",
                keyColumns: new[] { "FoodId", "IngredientId" },
                keyValues: new object[] { 16, 6 },
                column: "CategoryId",
                value: null);

            migrationBuilder.UpdateData(
                table: "FoodIngredients",
                keyColumns: new[] { "FoodId", "IngredientId" },
                keyValues: new object[] { 16, 7 },
                column: "CategoryId",
                value: null);

            migrationBuilder.UpdateData(
                table: "FoodIngredients",
                keyColumns: new[] { "FoodId", "IngredientId" },
                keyValues: new object[] { 17, 6 },
                column: "CategoryId",
                value: null);

            migrationBuilder.UpdateData(
                table: "FoodIngredients",
                keyColumns: new[] { "FoodId", "IngredientId" },
                keyValues: new object[] { 17, 8 },
                column: "CategoryId",
                value: null);

            migrationBuilder.UpdateData(
                table: "FoodIngredients",
                keyColumns: new[] { "FoodId", "IngredientId" },
                keyValues: new object[] { 18, 6 },
                column: "CategoryId",
                value: null);

            migrationBuilder.UpdateData(
                table: "FoodIngredients",
                keyColumns: new[] { "FoodId", "IngredientId" },
                keyValues: new object[] { 18, 9 },
                column: "CategoryId",
                value: null);

            migrationBuilder.CreateIndex(
                name: "IX_FoodIngredients_CategoryId",
                table: "FoodIngredients",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_FoodIngredients_Categories_CategoryId",
                table: "FoodIngredients",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "CategoryId");
        }
    }
}
