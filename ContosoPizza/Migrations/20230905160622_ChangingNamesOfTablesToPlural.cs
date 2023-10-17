using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ContosoPizza.Migrations
{
    /// <inheritdoc />
    public partial class ChangingNamesOfTablesToPlural : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pizzas_Sauce_SauceId",
                table: "Pizzas");

            migrationBuilder.DropForeignKey(
                name: "FK_PizzaTopping_Topping_ToppingsId",
                table: "PizzaTopping");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Topping",
                table: "Topping");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Sauce",
                table: "Sauce");

            migrationBuilder.RenameTable(
                name: "Topping",
                newName: "Toppings");

            migrationBuilder.RenameTable(
                name: "Sauce",
                newName: "Sauces");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Toppings",
                table: "Toppings",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Sauces",
                table: "Sauces",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Pizzas_Sauces_SauceId",
                table: "Pizzas",
                column: "SauceId",
                principalTable: "Sauces",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PizzaTopping_Toppings_ToppingsId",
                table: "PizzaTopping",
                column: "ToppingsId",
                principalTable: "Toppings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pizzas_Sauces_SauceId",
                table: "Pizzas");

            migrationBuilder.DropForeignKey(
                name: "FK_PizzaTopping_Toppings_ToppingsId",
                table: "PizzaTopping");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Toppings",
                table: "Toppings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Sauces",
                table: "Sauces");

            migrationBuilder.RenameTable(
                name: "Toppings",
                newName: "Topping");

            migrationBuilder.RenameTable(
                name: "Sauces",
                newName: "Sauce");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Topping",
                table: "Topping",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Sauce",
                table: "Sauce",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Pizzas_Sauce_SauceId",
                table: "Pizzas",
                column: "SauceId",
                principalTable: "Sauce",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PizzaTopping_Topping_ToppingsId",
                table: "PizzaTopping",
                column: "ToppingsId",
                principalTable: "Topping",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
