using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CourseCreator.Datalayer.Migrations
{
    public partial class mig_update_db_2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Parent",
                table: "CourseGroups");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Parent",
                table: "CourseGroups",
                type: "int",
                nullable: true);
        }
    }
}
