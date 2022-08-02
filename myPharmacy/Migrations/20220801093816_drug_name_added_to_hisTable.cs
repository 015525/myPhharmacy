using Microsoft.EntityFrameworkCore.Migrations;

namespace myPharmacy.Migrations
{
    public partial class drug_name_added_to_hisTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "drug_name",
                table: "history",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "drug_name",
                table: "history");
        }
    }
}
