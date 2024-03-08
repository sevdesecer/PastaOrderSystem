using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApi.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Beverage",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    Price = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Beverage", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ExtraIngredient",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    Price = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExtraIngredient", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CustomerName = table.Column<string>(type: "text", nullable: false),
                    CustomerAddress = table.Column<string>(type: "text", nullable: false),
                    TotalPrice = table.Column<int>(type: "integer", nullable: false),
                    DateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pasta",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    Price = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pasta", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Junction",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    PastaId = table.Column<Guid>(type: "uuid", nullable: true),
                    BeverageId = table.Column<Guid>(type: "uuid", nullable: true),
                    OrderId = table.Column<Guid>(type: "uuid", nullable: true),
                    ExtraIngredientId = table.Column<Guid>(type: "uuid", nullable: true),
                    PastaNumber = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Junction", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Junction_Beverage_BeverageId",
                        column: x => x.BeverageId,
                        principalTable: "Beverage",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Junction_ExtraIngredient_ExtraIngredientId",
                        column: x => x.ExtraIngredientId,
                        principalTable: "ExtraIngredient",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Junction_Order_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Order",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Junction_Pasta_PastaId",
                        column: x => x.PastaId,
                        principalTable: "Pasta",
                        principalColumn: "Id");
                });

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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Junction");

            migrationBuilder.DropTable(
                name: "Beverage");

            migrationBuilder.DropTable(
                name: "ExtraIngredient");

            migrationBuilder.DropTable(
                name: "Order");

            migrationBuilder.DropTable(
                name: "Pasta");
        }
    }
}
