using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Marlin.sqlite.Migrations
{
    /// <inheritdoc />
    public partial class ChangeColumnType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
     name: "Date",
     table: "OrderHeaders",
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
     table: "OrderHeaders",
     type: "timestamp with time zone",
     nullable: false,
     oldClrType: typeof(DateTime),
     oldType: "timestamp");

        }
    }
}
