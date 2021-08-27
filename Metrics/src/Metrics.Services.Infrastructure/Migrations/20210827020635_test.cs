using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Metrics.Services.Infrastructure.Migrations
{
    public partial class test : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "INGESTION",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ID_USER = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SEQ_NUM = table.Column<long>(type: "bigint", nullable: false),
                    PICKED_LAYERS = table.Column<int>(type: "int", nullable: false),
                    ID_MACHINE = table.Column<int>(type: "int", nullable: false),
                    INIT_DATE = table.Column<long>(type: "bigint", maxLength: 11, nullable: false),
                    END_DATE = table.Column<long>(type: "bigint", maxLength: 11, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_INGESTION", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "INGESTION");
        }
    }
}
