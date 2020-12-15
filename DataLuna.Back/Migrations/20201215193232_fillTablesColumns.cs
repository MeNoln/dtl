using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataLuna.Back.Migrations
{
    public partial class fillTablesColumns : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "MatchDate",
                table: "FinishedMatches",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<long>(
                name: "TeamAId",
                table: "FinishedMatches",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "TeamBId",
                table: "FinishedMatches",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<DateTime>(
                name: "EventDate",
                table: "Events",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<long>(
                name: "TeamAId",
                table: "Events",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "TeamBId",
                table: "Events",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<string>(
                name: "DemoData",
                table: "Demos",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "FinishedMatchId",
                table: "Demos",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_FinishedMatches_TeamAId",
                table: "FinishedMatches",
                column: "TeamAId");

            migrationBuilder.CreateIndex(
                name: "IX_FinishedMatches_TeamBId",
                table: "FinishedMatches",
                column: "TeamBId");

            migrationBuilder.CreateIndex(
                name: "IX_Events_TeamAId",
                table: "Events",
                column: "TeamAId");

            migrationBuilder.CreateIndex(
                name: "IX_Events_TeamBId",
                table: "Events",
                column: "TeamBId");

            migrationBuilder.CreateIndex(
                name: "IX_Demos_FinishedMatchId",
                table: "Demos",
                column: "FinishedMatchId");

            migrationBuilder.AddForeignKey(
                name: "FK_Demos_FinishedMatches_FinishedMatchId",
                table: "Demos",
                column: "FinishedMatchId",
                principalTable: "FinishedMatches",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Events_Teams_TeamAId",
                table: "Events",
                column: "TeamAId",
                principalTable: "Teams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Events_Teams_TeamBId",
                table: "Events",
                column: "TeamBId",
                principalTable: "Teams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FinishedMatches_Teams_TeamAId",
                table: "FinishedMatches",
                column: "TeamAId",
                principalTable: "Teams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FinishedMatches_Teams_TeamBId",
                table: "FinishedMatches",
                column: "TeamBId",
                principalTable: "Teams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Demos_FinishedMatches_FinishedMatchId",
                table: "Demos");

            migrationBuilder.DropForeignKey(
                name: "FK_Events_Teams_TeamAId",
                table: "Events");

            migrationBuilder.DropForeignKey(
                name: "FK_Events_Teams_TeamBId",
                table: "Events");

            migrationBuilder.DropForeignKey(
                name: "FK_FinishedMatches_Teams_TeamAId",
                table: "FinishedMatches");

            migrationBuilder.DropForeignKey(
                name: "FK_FinishedMatches_Teams_TeamBId",
                table: "FinishedMatches");

            migrationBuilder.DropIndex(
                name: "IX_FinishedMatches_TeamAId",
                table: "FinishedMatches");

            migrationBuilder.DropIndex(
                name: "IX_FinishedMatches_TeamBId",
                table: "FinishedMatches");

            migrationBuilder.DropIndex(
                name: "IX_Events_TeamAId",
                table: "Events");

            migrationBuilder.DropIndex(
                name: "IX_Events_TeamBId",
                table: "Events");

            migrationBuilder.DropIndex(
                name: "IX_Demos_FinishedMatchId",
                table: "Demos");

            migrationBuilder.DropColumn(
                name: "MatchDate",
                table: "FinishedMatches");

            migrationBuilder.DropColumn(
                name: "TeamAId",
                table: "FinishedMatches");

            migrationBuilder.DropColumn(
                name: "TeamBId",
                table: "FinishedMatches");

            migrationBuilder.DropColumn(
                name: "EventDate",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "TeamAId",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "TeamBId",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "DemoData",
                table: "Demos");

            migrationBuilder.DropColumn(
                name: "FinishedMatchId",
                table: "Demos");
        }
    }
}
