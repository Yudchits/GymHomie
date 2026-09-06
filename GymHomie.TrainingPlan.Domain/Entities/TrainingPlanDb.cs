using GymHomie.TrainingPlan.Domain.Primitives;
using System.Collections.Generic;

namespace GymHomie.TrainingPlan.Domain.Entities
{
    public class TrainingPlanDb : Entity
    {
        public string Title { get; private set; } = null!;
        public string? Notes { get; private set; }
        public virtual ICollection<ExerciseSetDb> Sets { get; private set; } = new List<ExerciseSetDb>();
        public virtual ICollection<TrainingSessionDb> Sessions { get; private set; } = new List<TrainingSessionDb>();

        //EF core
        protected TrainingPlanDb() { }

        private TrainingPlanDb(long id, string title, string? notes) : base(id)
        {
            Title = title;
            Notes = notes;
        }

        public static TrainingPlanDb Create(string title, string notes)
        {
            return new(id: 0, title: title, notes: notes);
        }
    }
}
