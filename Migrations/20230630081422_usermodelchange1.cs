using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Marlin.sqlite.Migrations
{
    /// <inheritdoc />
    public partial class usermodelchange1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
             name: "Users",
             columns: table => new
             {
                 id = table.Column<int>(nullable: false)
                     .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                 AccountID = table.Column<string>(nullable: true),
                 UserID = table.Column<int>(nullable: false, defaultValue: 1000),
                 FirstName = table.Column<string>(nullable: true),
                 LastName = table.Column<string>(nullable: true),
                 ContactNumber = table.Column<string>(nullable: true),
                 Email = table.Column<string>(nullable: true),
                 Description = table.Column<string>(nullable: true),
                 PositionInCompany = table.Column<string>(nullable: true),
                 Password = table.Column<string>(nullable: true)
             },
             constraints: table =>
             {
                 table.PrimaryKey("PK_Users", x => x.id);
             });

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
