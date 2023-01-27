using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class ModifiedUserEntityAndGameEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EndScore",
                table: "Games");

            migrationBuilder.AddColumn<string>(
                name: "CompanyBranch",
                table: "Users",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Team1Score",
                table: "Games",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Team2Score",
                table: "Games",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CompanyBranch",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Team1Score",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "Team2Score",
                table: "Games");

            migrationBuilder.AddColumn<string>(
                name: "EndScore",
                table: "Games",
                type: "TEXT",
                nullable: true);
        }
    }
}
