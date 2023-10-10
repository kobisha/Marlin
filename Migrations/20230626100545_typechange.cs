using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Marlin.sqlite.Migrations
{
    /// <inheritdoc />
    public partial class typechange : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
    name: "Date",
    table: "OrderStatusHistory",
    type: "timestamp",
    nullable: false,
    oldClrType: typeof(DateTime),
    oldType: "timestamp with time zone");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
        name: "Date",
        table: "OrderStatusHistory",
        type: "timestamp with time zone",
        nullable: false,
        oldClrType: typeof(DateTime),
        oldType: "timestamp");
        }
    }
}
