using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class SimplifiedDBArchitecture : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bets_Games_GameEntityId",
                table: "Bets");

            migrationBuilder.DropTable(
                name: "CompanyMembers");

            migrationBuilder.DropIndex(
                name: "IX_Bets_GameEntityId",
                table: "Bets");

            migrationBuilder.DropColumn(
                name: "TeamOutcome",
                table: "Bets");

            migrationBuilder.RenameColumn(
                name: "CompanyBranch",
                table: "Users",
                newName: "Branch");

            migrationBuilder.RenameColumn(
                name: "GameEntityId",
                table: "Bets",
                newName: "PredictedOutcome");

            migrationBuilder.AddColumn<int>(
                name: "CompanyEntityId",
                table: "Users",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CompanyRole",
                table: "Users",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Users_CompanyEntityId",
                table: "Users",
                column: "CompanyEntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Companies_CompanyEntityId",
                table: "Users",
                column: "CompanyEntityId",
                principalTable: "Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Companies_CompanyEntityId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_CompanyEntityId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "CompanyEntityId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "CompanyRole",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "Branch",
                table: "Users",
                newName: "CompanyBranch");

            migrationBuilder.RenameColumn(
                name: "PredictedOutcome",
                table: "Bets",
                newName: "GameEntityId");

            migrationBuilder.AddColumn<string>(
                name: "TeamOutcome",
                table: "Bets",
                type: "TEXT",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "CompanyMembers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CompanyEntityId = table.Column<int>(type: "INTEGER", nullable: false),
                    UserEntityId = table.Column<int>(type: "INTEGER", nullable: false),
                    Role = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyMembers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CompanyMembers_Companies_CompanyEntityId",
                        column: x => x.CompanyEntityId,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CompanyMembers_Users_UserEntityId",
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
                name: "IX_CompanyMembers_CompanyEntityId",
                table: "CompanyMembers",
                column: "CompanyEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyMembers_UserEntityId",
                table: "CompanyMembers",
                column: "UserEntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bets_Games_GameEntityId",
                table: "Bets",
                column: "GameEntityId",
                principalTable: "Games",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
