using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _603_Dynamic_Web_Tech_Assessment_1___JBC.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddMovieIdToCast : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "MoveId",
                table: "Casts",
                newName: "MovieId");

            migrationBuilder.CreateIndex(
                name: "IX_Casts_MovieId",
                table: "Casts",
                column: "MovieId");

            migrationBuilder.AddForeignKey(
                name: "FK_Casts_Movies_MovieId",
                table: "Casts",
                column: "MovieId",
                principalTable: "Movies",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Casts_Movies_MovieId",
                table: "Casts");

            migrationBuilder.DropIndex(
                name: "IX_Casts_MovieId",
                table: "Casts");

            migrationBuilder.RenameColumn(
                name: "MovieId",
                table: "Casts",
                newName: "MoveId");
        }
    }
}
