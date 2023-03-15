using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddedGamePropToBetEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Games");

            migrationBuilder.RenameColumn(
                name: "EventName",
                table: "Events",
                newName: "Name");

            migrationBuilder.AddColumn<int>(
                name: "GameEntityId",
                table: "Bets",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Bets_GameEntityId",
                table: "Bets",
                column: "GameEntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bets_Games_GameEntityId",
                table: "Bets",
                column: "GameEntityId",
                principalTable: "Games",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bets_Games_GameEntityId",
                table: "Bets");

            migrationBuilder.DropIndex(
                name: "IX_Bets_GameEntityId",
                table: "Bets");

            migrationBuilder.DropColumn(
                name: "GameEntityId",
                table: "Bets");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Events",
                newName: "EventName");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Games",
                type: "TEXT",
                nullable: true);
        }
    }
}