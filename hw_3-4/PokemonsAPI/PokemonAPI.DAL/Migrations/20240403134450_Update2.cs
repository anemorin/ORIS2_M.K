using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TestEfCore.Migrations
{
    /// <inheritdoc />
    public partial class Update2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MovesPokemon");

            migrationBuilder.AddColumn<Guid>(
                name: "PokemonId",
                table: "Moves",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Moves_PokemonId",
                table: "Moves",
                column: "PokemonId");

            migrationBuilder.AddForeignKey(
                name: "FK_Moves_Pokemons_PokemonId",
                table: "Moves",
                column: "PokemonId",
                principalTable: "Pokemons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Moves_Pokemons_PokemonId",
                table: "Moves");

            migrationBuilder.DropIndex(
                name: "IX_Moves_PokemonId",
                table: "Moves");

            migrationBuilder.DropColumn(
                name: "PokemonId",
                table: "Moves");

            migrationBuilder.CreateTable(
                name: "MovesPokemon",
                columns: table => new
                {
                    MovesId = table.Column<Guid>(type: "uuid", nullable: false),
                    PokemonsId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovesPokemon", x => new { x.MovesId, x.PokemonsId });
                    table.ForeignKey(
                        name: "FK_MovesPokemon_Moves_MovesId",
                        column: x => x.MovesId,
                        principalTable: "Moves",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MovesPokemon_Pokemons_PokemonsId",
                        column: x => x.PokemonsId,
                        principalTable: "Pokemons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MovesPokemon_PokemonsId",
                table: "MovesPokemon",
                column: "PokemonsId");
        }
    }
}
