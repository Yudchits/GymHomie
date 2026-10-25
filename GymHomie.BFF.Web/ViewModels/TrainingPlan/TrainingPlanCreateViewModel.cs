using GymHomie.TrainingPlan.Application.Responses.Exercise;
using System.Collections.Generic;

namespace GymHomie.BFF.Web.ViewModels.TrainingPlan
{
    public record TrainingPlanCreateViewModel
    {
        public string Title { get; set; } = null!;
        public string? Notes { get; set; }
        public ICollection<GetAllExercisesResponse> Exercises = new List<GetAllExercisesResponse>();
        public ICollection<ExerciseSetCreateViewModel> Sets { get; set; } = new List<ExerciseSetCreateViewModel>();
    }
}
