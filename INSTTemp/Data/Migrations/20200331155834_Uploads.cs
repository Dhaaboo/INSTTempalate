using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace INSTTemp.Data.Migrations
{
    public partial class Uploads : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Uploads",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    lectureName = table.Column<string>(maxLength: 100, nullable: false),
                    lectureNumber = table.Column<string>(maxLength: 100, nullable: false),
                    FilePath = table.Column<string>(maxLength: 100, nullable: true),
                    FileSize = table.Column<long>(nullable: false),
                    DataDoc = table.Column<byte[]>(nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Uploads", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Uploads");
        }
    }
}
