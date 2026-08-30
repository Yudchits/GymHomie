using GymHomie.TrainingPlan.Application.Responses.Exercise;
using MediatR;
using System.Collections.Generic;

namespace GymHomie.TrainingPlan.Application.Feature.Exercise.GetAll
{
    public record GetAllExercisesRequest : IRequest<ICollection<GetAllExercisesResponse>>
    {
    }
}
