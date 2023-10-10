using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Marlin.sqlite.Migrations
{
    /// <inheritdoc />
    public partial class retrobonus2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RetroBonusHeaderId",
                table: "RetroBonusPlanRanges",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RetroBonusHeaderId",
                table: "RetroBonusDetails",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_RetroBonusPlanRanges_RetroBonusHeaderId",
                table: "RetroBonusPlanRanges",
                column: "RetroBonusHeaderId");

            migrationBuilder.CreateIndex(
                name: "IX_RetroBonusDetails_RetroBonusHeaderId",
                table: "RetroBonusDetails",
                column: "RetroBonusHeaderId");

            migrationBuilder.AddForeignKey(
                name: "FK_RetroBonusDetails_RetroBonusHeaders_RetroBonusHeaderId",
                table: "RetroBonusDetails",
                column: "RetroBonusHeaderId",
                principalTable: "RetroBonusHeaders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RetroBonusPlanRanges_RetroBonusHeaders_RetroBonusHeaderId",
                table: "RetroBonusPlanRanges",
                column: "RetroBonusHeaderId",
                principalTable: "RetroBonusHeaders",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RetroBonusDetails_RetroBonusHeaders_RetroBonusHeaderId",
                table: "RetroBonusDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_RetroBonusPlanRanges_RetroBonusHeaders_RetroBonusHeaderId",
                table: "RetroBonusPlanRanges");

            migrationBuilder.DropIndex(
                name: "IX_RetroBonusPlanRanges_RetroBonusHeaderId",
                table: "RetroBonusPlanRanges");

            migrationBuilder.DropIndex(
                name: "IX_RetroBonusDetails_RetroBonusHeaderId",
                table: "RetroBonusDetails");

            migrationBuilder.DropColumn(
                name: "RetroBonusHeaderId",
                table: "RetroBonusPlanRanges");

            migrationBuilder.DropColumn(
                name: "RetroBonusHeaderId",
                table: "RetroBonusDetails");
        }
    }
}
