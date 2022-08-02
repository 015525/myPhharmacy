using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace myPharmacy.Migrations
{
    public partial class addDrugHistoryyToDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "drugs",
                columns: table => new
                {
                    drug_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    drug_name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_drugs", x => x.drug_id);
                });

            migrationBuilder.CreateTable(
                name: "history",
                columns: table => new
                {
                    his_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    drug_id = table.Column<int>(type: "int", nullable: false),
                    comming_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    production_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    expirey_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    quantity = table.Column<int>(type: "int", nullable: false),
                    unit = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    expired = table.Column<bool>(type: "bit", nullable: false),
                    finished = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_history", x => x.his_id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "drugs");

            migrationBuilder.DropTable(
                name: "history");
        }
    }
}
