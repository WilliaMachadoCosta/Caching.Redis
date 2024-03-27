using AutoMapper;
using Caching.Domain;
using Caching.Infra.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApi.Model;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("v1/todos")]
    public class ToDoController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IRepository _repository;

        public ToDoController(IMapper mapper, IRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        [HttpGet]
        [Route("")]
        public IActionResult GetAll()
        {
            var startTime = DateTime.Now;
            var todos = _repository.GetAll();
            var endTime = DateTime.Now;
            var elapsedTime = endTime - startTime;

            var resultWithElapsedTime = new ResultWithElapsedTime<IEnumerable<TaskItem>>
            {
                ElapsedTime = elapsedTime,
                Data = todos
            };

            return Ok(resultWithElapsedTime);
        }


        //[HttpGet]
        //[Route("v1/products/{id}")]
        //[ResponseCache(Duration = 15)]
        //public async Task<IActionResult> Get(int id)
        //{
        //    var product = await Task.Run(() => _repository.GetById(id));
        //    if (product == null)
        //        return NotFound(Result<TaskItemViewModel>.FailureResult("TaskItem not found."));

        //    var taskViewModel = _mapper.Map<TaskItemViewModel>(product);
        //    var elapsedTime = TimeSpan.FromMilliseconds();
        //    var successResult = Result<TaskItemViewModel>.SuccessResult(taskViewModel, elapsedTime);
        //    return Ok(successResult);
        //}

        public class ResultWithElapsedTime<T>
        {
            public TimeSpan ElapsedTime { get; set; }
            public T Data { get; set; }
        }


    }
}
