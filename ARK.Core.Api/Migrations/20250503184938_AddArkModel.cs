using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ARK.Core.Api.Migrations
{
    /// <inheritdoc />
    public partial class AddArkModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Arks",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Date = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    Act = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Arks", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Arks");
        }
    }
}
