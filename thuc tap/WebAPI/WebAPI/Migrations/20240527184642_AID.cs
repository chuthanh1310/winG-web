using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAPI.Migrations
{
    /// <inheritdoc />
    public partial class AID : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Singles_Artists_ArtistId",
                table: "Singles");

            migrationBuilder.RenameColumn(
                name: "ArtistId",
                table: "Singles",
                newName: "ArtistID");

            migrationBuilder.RenameIndex(
                name: "IX_Singles_ArtistId",
                table: "Singles",
                newName: "IX_Singles_ArtistID");

            migrationBuilder.AddForeignKey(
                name: "FK_Singles_Artists_ArtistID",
                table: "Singles",
                column: "ArtistID",
                principalTable: "Artists",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Singles_Artists_ArtistID",
                table: "Singles");

            migrationBuilder.RenameColumn(
                name: "ArtistID",
                table: "Singles",
                newName: "ArtistId");

            migrationBuilder.RenameIndex(
                name: "IX_Singles_ArtistID",
                table: "Singles",
                newName: "IX_Singles_ArtistId");

            migrationBuilder.AddForeignKey(
                name: "FK_Singles_Artists_ArtistId",
                table: "Singles",
                column: "ArtistId",
                principalTable: "Artists",
                principalColumn: "Id");
        }
    }
}
