using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PastaOrderSystem.Migrations
{
    /// <inheritdoc />
    public partial class second : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Junction_BeverageId",
                table: "Junction",
                column: "BeverageId");

            migrationBuilder.CreateIndex(
                name: "IX_Junction_ExtraIngredientId",
                table: "Junction",
                column: "ExtraIngredientId");

            migrationBuilder.CreateIndex(
                name: "IX_Junction_OrderId",
                table: "Junction",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Junction_PastaId",
                table: "Junction",
                column: "PastaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Junction_Beverage_BeverageId",
                table: "Junction",
                column: "BeverageId",
                principalTable: "Beverage",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Junction_ExtraIngredient_ExtraIngredientId",
                table: "Junction",
                column: "ExtraIngredientId",
                principalTable: "ExtraIngredient",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Junction_Order_OrderId",
                table: "Junction",
                column: "OrderId",
                principalTable: "Order",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Junction_Pasta_PastaId",
                table: "Junction",
                column: "PastaId",
                principalTable: "Pasta",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Junction_Beverage_BeverageId",
                table: "Junction");

            migrationBuilder.DropForeignKey(
                name: "FK_Junction_ExtraIngredient_ExtraIngredientId",
                table: "Junction");

            migrationBuilder.DropForeignKey(
                name: "FK_Junction_Order_OrderId",
                table: "Junction");

            migrationBuilder.DropForeignKey(
                name: "FK_Junction_Pasta_PastaId",
                table: "Junction");

            migrationBuilder.DropIndex(
                name: "IX_Junction_BeverageId",
                table: "Junction");

            migrationBuilder.DropIndex(
                name: "IX_Junction_ExtraIngredientId",
                table: "Junction");

            migrationBuilder.DropIndex(
                name: "IX_Junction_OrderId",
                table: "Junction");

            migrationBuilder.DropIndex(
                name: "IX_Junction_PastaId",
                table: "Junction");
        }
    }
}
