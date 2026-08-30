using Microsoft.EntityFrameworkCore.Migrations;

namespace GymHomie.TrainingPlan.Data.Migrations
{
    public partial class ExerciseSetAddSets : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Sets",
                table: "ExerciseSets",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Sets",
                table: "ExerciseSets");
        }
    }
}
