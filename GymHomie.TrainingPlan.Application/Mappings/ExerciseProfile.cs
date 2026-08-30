using AutoMapper;
using GymHomie.TrainingPlan.Application.Responses.Exercise;
using GymHomie.TrainingPlan.Domain.Entities;

namespace GymHomie.TrainingPlan.Application.Mappings
{
    internal class ExerciseProfile : Profile
    {
        public ExerciseProfile()
        {
            CreateMap<ExerciseDb, GetAllExercisesResponse>()
                .ForMember(dest => dest.Id, opts => opts.MapFrom(src => src.Id))
                .ForMember(dest => dest.Name, opts => opts.MapFrom(src => src.Name));
        }
    }
}
