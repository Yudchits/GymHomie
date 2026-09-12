using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace GymHomie.TrainingPlan.Data.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "training_plan");

            migrationBuilder.CreateTable(
                name: "exercise_combined_sets",
                schema: "training_plan",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    rounds = table.Column<int>(type: "integer", nullable: false),
                    rest_time_seconds = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_exercise_combined_sets", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "icons",
                schema: "training_plan",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_icons", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "training_plans",
                schema: "training_plan",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    title = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: false),
                    notes = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_training_plans", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "exercises",
                schema: "training_plan",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: false),
                    icon_id = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_exercises", x => x.id);
                    table.ForeignKey(
                        name: "fk_exercises_icon_db_icon_id",
                        column: x => x.icon_id,
                        principalSchema: "training_plan",
                        principalTable: "icons",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "training_sessions",
                schema: "training_plan",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    plan_id = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_training_sessions", x => x.id);
                    table.ForeignKey(
                        name: "fk_training_sessions_training_plans_plan_id",
                        column: x => x.plan_id,
                        principalSchema: "training_plan",
                        principalTable: "training_plans",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "exercise_sets",
                schema: "training_plan",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    exercise_id = table.Column<long>(type: "bigint", nullable: false),
                    sets = table.Column<int>(type: "integer", nullable: false),
                    reps = table.Column<int>(type: "integer", nullable: false),
                    weight = table.Column<decimal>(type: "numeric(8,2)", precision: 8, scale: 2, nullable: false),
                    rest_time_seconds = table.Column<int>(type: "integer", nullable: false),
                    combined_set_id = table.Column<long>(type: "bigint", nullable: true),
                    plan_id = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_exercise_sets", x => x.id);
                    table.ForeignKey(
                        name: "fk_exercise_sets_exercise_combined_sets_combined_set_id",
                        column: x => x.combined_set_id,
                        principalSchema: "training_plan",
                        principalTable: "exercise_combined_sets",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_exercise_sets_exercises_exercise_id",
                        column: x => x.exercise_id,
                        principalSchema: "training_plan",
                        principalTable: "exercises",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_exercise_sets_training_plans_plan_id",
                        column: x => x.plan_id,
                        principalSchema: "training_plan",
                        principalTable: "training_plans",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_exercise_sets_combined_set_id",
                schema: "training_plan",
                table: "exercise_sets",
                column: "combined_set_id");

            migrationBuilder.CreateIndex(
                name: "ix_exercise_sets_exercise_id",
                schema: "training_plan",
                table: "exercise_sets",
                column: "exercise_id");

            migrationBuilder.CreateIndex(
                name: "ix_exercise_sets_plan_id",
                schema: "training_plan",
                table: "exercise_sets",
                column: "plan_id");

            migrationBuilder.CreateIndex(
                name: "ix_exercises_icon_id",
                schema: "training_plan",
                table: "exercises",
                column: "icon_id");

            migrationBuilder.CreateIndex(
                name: "ix_exercises_name",
                schema: "training_plan",
                table: "exercises",
                column: "name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_icons_name",
                schema: "training_plan",
                table: "icons",
                column: "name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_training_plans_title",
                schema: "training_plan",
                table: "training_plans",
                column: "title",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_training_sessions_plan_id",
                schema: "training_plan",
                table: "training_sessions",
                column: "plan_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "exercise_sets",
                schema: "training_plan");

            migrationBuilder.DropTable(
                name: "training_sessions",
                schema: "training_plan");

            migrationBuilder.DropTable(
                name: "exercise_combined_sets",
                schema: "training_plan");

            migrationBuilder.DropTable(
                name: "exercises",
                schema: "training_plan");

            migrationBuilder.DropTable(
                name: "training_plans",
                schema: "training_plan");

            migrationBuilder.DropTable(
                name: "icons",
                schema: "training_plan");
        }
    }
}
