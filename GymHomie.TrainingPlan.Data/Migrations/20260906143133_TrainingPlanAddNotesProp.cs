using Microsoft.EntityFrameworkCore.Migrations;

namespace GymHomie.TrainingPlan.Data.Migrations
{
    public partial class TrainingPlanAddNotesProp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Notes",
                table: "TrainingPlans",
                type: "nvarchar(64)",
                maxLength: 64,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Notes",
                table: "TrainingPlans");
        }
    }
}
