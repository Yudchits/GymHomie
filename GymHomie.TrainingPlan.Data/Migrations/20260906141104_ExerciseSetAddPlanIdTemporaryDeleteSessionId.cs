using Microsoft.EntityFrameworkCore.Migrations;

namespace GymHomie.TrainingPlan.Data.Migrations
{
    public partial class ExerciseSetAddPlanIdTemporaryDeleteSessionId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExerciseSets_TrainingSessions_SessionId",
                table: "ExerciseSets");

            migrationBuilder.RenameColumn(
                name: "SessionId",
                table: "ExerciseSets",
                newName: "PlanId");

            migrationBuilder.RenameIndex(
                name: "IX_ExerciseSets_SessionId",
                table: "ExerciseSets",
                newName: "IX_ExerciseSets_PlanId");

            migrationBuilder.AddForeignKey(
                name: "FK_ExerciseSets_TrainingPlans_PlanId",
                table: "ExerciseSets",
                column: "PlanId",
                principalTable: "TrainingPlans",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExerciseSets_TrainingPlans_PlanId",
                table: "ExerciseSets");

            migrationBuilder.RenameColumn(
                name: "PlanId",
                table: "ExerciseSets",
                newName: "SessionId");

            migrationBuilder.RenameIndex(
                name: "IX_ExerciseSets_PlanId",
                table: "ExerciseSets",
                newName: "IX_ExerciseSets_SessionId");

            migrationBuilder.AddForeignKey(
                name: "FK_ExerciseSets_TrainingSessions_SessionId",
                table: "ExerciseSets",
                column: "SessionId",
                principalTable: "TrainingSessions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
