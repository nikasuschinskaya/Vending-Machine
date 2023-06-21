using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VendingMachine.DAL.Migrations
{
    /// <inheritdoc />
    public partial class AddStateAtEntities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DrinkState",
                table: "Drinks",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CoinState",
                table: "Coins",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DrinkState",
                table: "Drinks");

            migrationBuilder.DropColumn(
                name: "CoinState",
                table: "Coins");
        }
    }
}
