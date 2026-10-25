namespace GymHomie.BFF.Web.ViewModels.TrainingPlan
{
    public record ExerciseSetCreateViewModel
    {
        public long ExerciseId { get; set; }
        public int Sets { get; set; }
        public int Reps { get; set; }
        public decimal Weight { get; set; }
        public int RestTimeSeconds { get; set; }
    }
}
