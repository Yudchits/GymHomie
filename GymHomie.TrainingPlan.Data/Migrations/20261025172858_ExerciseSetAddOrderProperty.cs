using Microsoft.EntityFrameworkCore.Migrations;

namespace GymHomie.TrainingPlan.Data.Migrations
{
    public partial class ExerciseSetAddOrderProperty : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "order",
                schema: "training_plan",
                table: "exercise_sets",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "order",
                schema: "training_plan",
                table: "exercise_sets");
        }
    }
}
