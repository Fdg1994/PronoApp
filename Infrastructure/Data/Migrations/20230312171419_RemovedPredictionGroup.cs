using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class RemovedPredictionGroup : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PredictionGroups");

            migrationBuilder.AddColumn<int>(
                name: "CompanyEntityId",
                table: "Events",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "logoUrl",
                table: "Events",
                type: "TEXT",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Events_CompanyEntityId",
                table: "Events",
                column: "CompanyEntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Events_Companies_CompanyEntityId",
                table: "Events",
                column: "CompanyEntityId",
                principalTable: "Companies",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Events_Companies_CompanyEntityId",
                table: "Events");

            migrationBuilder.DropIndex(
                name: "IX_Events_CompanyEntityId",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "CompanyEntityId",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "logoUrl",
                table: "Events");

            migrationBuilder.CreateTable(
                name: "PredictionGroups",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CompanyEntityId = table.Column<int>(type: "INTEGER", nullable: false),
                    EventEntityId = table.Column<int>(type: "INTEGER", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    PredictionGroupPoints = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PredictionGroups", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PredictionGroups_Companies_CompanyEntityId",
                        column: x => x.CompanyEntityId,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PredictionGroups_Events_EventEntityId",
                        column: x => x.EventEntityId,
                        principalTable: "Events",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PredictionGroups_CompanyEntityId",
                table: "PredictionGroups",
                column: "CompanyEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_PredictionGroups_EventEntityId",
                table: "PredictionGroups",
                column: "EventEntityId");
        }
    }
}