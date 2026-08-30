using AutoMapper;
using GymHomie.TrainingPlan.Application.Responses.Exercise;
using GymHomie.TrainingPlan.Domain.Repositories;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace GymHomie.TrainingPlan.Application.Feature.Exercise.GetAll
{
    internal sealed class GetAllExercisesRequestHandler : IRequestHandler<GetAllExercisesRequest, ICollection<GetAllExercisesResponse>>
    {
        private readonly IExerciseRepository _exerciseRepository;
        private readonly IMapper _mapper;

        public GetAllExercisesRequestHandler(IExerciseRepository exerciseRepository, IMapper mapper)
        {
            _exerciseRepository = exerciseRepository;
            _mapper = mapper;
        }

        public async Task<ICollection<GetAllExercisesResponse>> Handle(GetAllExercisesRequest request, CancellationToken cancellationToken)
        {
            return await _exerciseRepository
                .GetAllAsync()
                .ContinueWith(result => _mapper.Map<ICollection<GetAllExercisesResponse>>(result.Result))
                .ConfigureAwait(false);
        }
    }
}
