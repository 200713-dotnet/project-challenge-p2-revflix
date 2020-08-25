using Microsoft.EntityFrameworkCore.Migrations;

namespace RevFlix.Service.Migrations
{
    public partial class thirdmigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Movie_UserProfile_UserProfileId",
                table: "Movie");

            migrationBuilder.DropIndex(
                name: "IX_Movie_UserProfileId",
                table: "Movie");

            migrationBuilder.DropColumn(
                name: "UserProfileId",
                table: "Movie");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserProfileId",
                table: "Movie",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Movie_UserProfileId",
                table: "Movie",
                column: "UserProfileId");

            migrationBuilder.AddForeignKey(
                name: "FK_Movie_UserProfile_UserProfileId",
                table: "Movie",
                column: "UserProfileId",
                principalTable: "UserProfile",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
