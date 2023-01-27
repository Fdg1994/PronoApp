using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddedBetEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PlayingTeams",
                table: "Games",
                newName: "Team2");

            migrationBuilder.AddColumn<string>(
                name: "Team1",
                table: "Games",
                type: "TEXT",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Bets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    OpenBetTime = table.Column<DateTime>(type: "TEXT", nullable: false),
                    CloseBetTime = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Status = table.Column<int>(type: "INTEGER", nullable: false),
                    BetAmount = table.Column<int>(type: "INTEGER", nullable: false),
                    TeamOutcome = table.Column<string>(type: "TEXT", nullable: true),
                    UserEntityId = table.Column<int>(type: "INTEGER", nullable: false),
                    GameEntityId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bets_Games_GameEntityId",
                        column: x => x.GameEntityId,
                        principalTable: "Games",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Bets_Users_UserEntityId",
                        column: x => x.UserEntityId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bets_GameEntityId",
                table: "Bets",
                column: "GameEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_Bets_UserEntityId",
                table: "Bets",
                column: "UserEntityId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bets");

            migrationBuilder.DropColumn(
                name: "Team1",
                table: "Games");

            migrationBuilder.RenameColumn(
                name: "Team2",
                table: "Games",
                newName: "PlayingTeams");
        }
    }
}
