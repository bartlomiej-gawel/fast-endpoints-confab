using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Confab.Modules.Conferences.Infrastructure.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "conferences_module");

            migrationBuilder.CreateTable(
                name: "hosts",
                schema: "conferences_module",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    description = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_hosts", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "conferences",
                schema: "conferences_module",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    host_id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    description = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: false),
                    location_city = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    location_street = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    participants_limit = table.Column<int>(type: "integer", nullable: false),
                    date_from = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    date_to = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_conferences", x => x.id);
                    table.ForeignKey(
                        name: "FK_conferences_hosts_host_id",
                        column: x => x.host_id,
                        principalSchema: "conferences_module",
                        principalTable: "hosts",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_conferences_host_id",
                schema: "conferences_module",
                table: "conferences",
                column: "host_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "conferences",
                schema: "conferences_module");

            migrationBuilder.DropTable(
                name: "hosts",
                schema: "conferences_module");
        }
    }
}
