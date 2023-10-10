using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Marlin.sqlite.Migrations
{
    /// <inheritdoc />
    public partial class retrobonus : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            

            migrationBuilder.CreateTable(
                name: "RetroBonusDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RetroBonusID = table.Column<string>(type: "text", nullable: false),
                    Barcode = table.Column<string>(type: "text", nullable: false),
                    MinimalPercent = table.Column<decimal>(type: "numeric", nullable: true),
                    PlanPercent = table.Column<decimal>(type: "numeric", nullable: true),
                    ManufacturerPercent = table.Column<decimal>(type: "numeric", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RetroBonusDetails", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RetroBonusHeaders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    AccountID = table.Column<string>(type: "text", nullable: false),
                    RetroBonusID = table.Column<string>(type: "text", nullable: false),
                    DocumentNo = table.Column<string>(type: "text", nullable: false),
                    SupplierID = table.Column<string>(type: "text", nullable: false),
                    StartDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    EndDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Status = table.Column<string>(type: "text", nullable: false),
                    Condition = table.Column<string>(type: "text", nullable: false),
                    IsMarketing = table.Column<bool>(type: "boolean", nullable: false),
                    FundedByManufacturer = table.Column<bool>(type: "boolean", nullable: false),
                    MinimalPercent = table.Column<decimal>(type: "numeric", nullable: true),
                    PlanAmount = table.Column<decimal>(type: "numeric", nullable: true),
                    PlanPercent = table.Column<decimal>(type: "numeric", nullable: true),
                    ManufacturerPercent = table.Column<decimal>(type: "numeric", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RetroBonusHeaders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RetroBonusPlanRanges",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RetroBonusID = table.Column<string>(type: "text", nullable: false),
                    RangeNo = table.Column<string>(type: "text", nullable: true),
                    RangeName = table.Column<string>(type: "text", nullable: true),
                    RangePercent = table.Column<decimal>(type: "numeric", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RetroBonusPlanRanges", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RetroBonusDetails");

            migrationBuilder.DropTable(
                name: "RetroBonusHeaders");

            migrationBuilder.DropTable(
                name: "RetroBonusPlanRanges");

           
        }
    }
}
