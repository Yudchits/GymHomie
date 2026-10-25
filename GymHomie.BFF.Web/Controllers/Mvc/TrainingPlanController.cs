using GymHomie.BFF.Web.Controllers.Abstractions;
using GymHomie.BFF.Web.ViewModels.TrainingPlan;
using GymHomie.TrainingPlan.Application.Feature.Exercise.GetAll;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace GymHomie.BFF.Web.Controllers
{
    public class TrainingPlanController : BaseMvcController
    {
        private readonly IMediator _mediator;

        public TrainingPlanController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var exercises = await _mediator.Send(new GetAllExercisesRequest());
            var model = new TrainingPlanCreateViewModel
            {
                Exercises = exercises
            };

            return HandleViewResponse(viewName: "Create", title: "Конструктор тренировки", model: model);
        }
    }
}
