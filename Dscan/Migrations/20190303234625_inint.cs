using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Dscan.Migrations
{
    public partial class inint : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DscanModel",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    Paste = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DscanModel", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DscanModel");
        }
    }
}
