using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace DataLuna.Back.Migrations
{
    public partial class dbchanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Demos_FinishedMatches_FinishedMatchId",
                table: "Demos");

            migrationBuilder.DropTable(
                name: "FinishedMatches");

            migrationBuilder.DropIndex(
                name: "IX_Demos_FinishedMatchId",
                table: "Demos");

            migrationBuilder.DropColumn(
                name: "FinishedMatchId",
                table: "Demos");

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Events",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<long>(
                name: "TeamAId",
                table: "Demos",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "TeamBId",
                table: "Demos",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_Demos_TeamAId",
                table: "Demos",
                column: "TeamAId");

            migrationBuilder.CreateIndex(
                name: "IX_Demos_TeamBId",
                table: "Demos",
                column: "TeamBId");

            migrationBuilder.AddForeignKey(
                name: "FK_Demos_Teams_TeamAId",
                table: "Demos",
                column: "TeamAId",
                principalTable: "Teams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Demos_Teams_TeamBId",
                table: "Demos",
                column: "TeamBId",
                principalTable: "Teams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Demos_Teams_TeamAId",
                table: "Demos");

            migrationBuilder.DropForeignKey(
                name: "FK_Demos_Teams_TeamBId",
                table: "Demos");

            migrationBuilder.DropIndex(
                name: "IX_Demos_TeamAId",
                table: "Demos");

            migrationBuilder.DropIndex(
                name: "IX_Demos_TeamBId",
                table: "Demos");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "TeamAId",
                table: "Demos");

            migrationBuilder.DropColumn(
                name: "TeamBId",
                table: "Demos");

            migrationBuilder.AddColumn<long>(
                name: "FinishedMatchId",
                table: "Demos",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateTable(
                name: "FinishedMatches",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    MatchDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    TeamAId = table.Column<long>(type: "bigint", nullable: false),
                    TeamBId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FinishedMatches", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FinishedMatches_Teams_TeamAId",
                        column: x => x.TeamAId,
                        principalTable: "Teams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FinishedMatches_Teams_TeamBId",
                        column: x => x.TeamBId,
                        principalTable: "Teams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Demos_FinishedMatchId",
                table: "Demos",
                column: "FinishedMatchId");

            migrationBuilder.CreateIndex(
                name: "IX_FinishedMatches_TeamAId",
                table: "FinishedMatches",
                column: "TeamAId");

            migrationBuilder.CreateIndex(
                name: "IX_FinishedMatches_TeamBId",
                table: "FinishedMatches",
                column: "TeamBId");

            migrationBuilder.AddForeignKey(
                name: "FK_Demos_FinishedMatches_FinishedMatchId",
                table: "Demos",
                column: "FinishedMatchId",
                principalTable: "FinishedMatches",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
