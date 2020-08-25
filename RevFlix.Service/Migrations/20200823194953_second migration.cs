using Microsoft.EntityFrameworkCore.Migrations;

namespace RevFlix.Service.Migrations
{
    public partial class secondmigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserGenre_Genre_GenreId",
                table: "UserGenre");

            migrationBuilder.DropForeignKey(
                name: "FK_UserMovie_Movie_MovieId",
                table: "UserMovie");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "UserMovie");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "UserGenre");

            migrationBuilder.AlterColumn<int>(
                name: "MovieId",
                table: "UserMovie",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "UserProfileId",
                table: "UserMovie",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "GenreId",
                table: "UserGenre",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_UserMovie_UserProfileId",
                table: "UserMovie",
                column: "UserProfileId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserGenre_Genre_GenreId",
                table: "UserGenre",
                column: "GenreId",
                principalTable: "Genre",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserMovie_Movie_MovieId",
                table: "UserMovie",
                column: "MovieId",
                principalTable: "Movie",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserMovie_UserProfile_UserProfileId",
                table: "UserMovie",
                column: "UserProfileId",
                principalTable: "UserProfile",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserGenre_Genre_GenreId",
                table: "UserGenre");

            migrationBuilder.DropForeignKey(
                name: "FK_UserMovie_Movie_MovieId",
                table: "UserMovie");

            migrationBuilder.DropForeignKey(
                name: "FK_UserMovie_UserProfile_UserProfileId",
                table: "UserMovie");

            migrationBuilder.DropIndex(
                name: "IX_UserMovie_UserProfileId",
                table: "UserMovie");

            migrationBuilder.DropColumn(
                name: "UserProfileId",
                table: "UserMovie");

            migrationBuilder.AlterColumn<int>(
                name: "MovieId",
                table: "UserMovie",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "UserMovie",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "GenreId",
                table: "UserGenre",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "UserGenre",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_UserGenre_Genre_GenreId",
                table: "UserGenre",
                column: "GenreId",
                principalTable: "Genre",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserMovie_Movie_MovieId",
                table: "UserMovie",
                column: "MovieId",
                principalTable: "Movie",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
