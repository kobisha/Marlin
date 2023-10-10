using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Marlin.sqlite.Migrations
{
    /// <inheritdoc />
    public partial class iinv : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            

            migrationBuilder.AddColumn<int>(
                name: "InvoiceHeaderID1",
                table: "InvoiceDetails",
                type: "integer",
                nullable: true);

           

            

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceDetails_InvoiceHeaderID1",
                table: "InvoiceDetails",
                column: "InvoiceHeaderID1");

            migrationBuilder.AddForeignKey(
                name: "FK_InvoiceDetails_InvoiceHeaders_InvoiceHeaderID1",
                table: "InvoiceDetails",
                column: "InvoiceHeaderID1",
                principalTable: "InvoiceHeaders",
                principalColumn: "ID");

           
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InvoiceDetails_InvoiceHeaders_InvoiceHeaderID1",
                table: "InvoiceDetails");

            

            

            migrationBuilder.DropIndex(
                name: "IX_InvoiceDetails_InvoiceHeaderID1",
                table: "InvoiceDetails");

            migrationBuilder.DropColumn(
                name: "InvoiceHeaderID1",
                table: "InvoiceDetails");

            
        }
    }
}
