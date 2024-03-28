using AutoMapper;
using Caching.Domain;
using Caching.Infra;
using Caching.Infra.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using WebApi.Model;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("v1/todos")]
    public class ToDoController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IRepository _repository;
        private readonly IRedisRepository<TaskItem> _redis;

        public ToDoController(IMapper mapper, IRepository repository, IRedisRepository<TaskItem> distributedCache)
        {
            _mapper = mapper;
            _repository = repository;
            _redis = distributedCache;
        }

        [HttpGet]
        [Route("cache")]
        public async Task<IActionResult> GetAllWithCache()
        {
            var startTime = DateTime.Now;

            // Verificar se os dados estão em cache
            var todos = await _redis.GetAllAsync();
            if (todos == null)
            {
                // Se os dados não estiverem em cache, busca do banco de dados
                todos = await _repository.GetAll();

                // Armazena no cache
                await _redis.SetAllAsync(todos);
            }

            var endTime = DateTime.Now;
            var elapsedTime = endTime - startTime;

            var resultWithElapsedTime = new ResultWithElapsedTime<IEnumerable<TaskItem>>
            {
                ElapsedTime = elapsedTime,
                Data = todos
            };

            return Ok(resultWithElapsedTime);
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetAll()
        {
            var startTime = DateTime.Now;
            var   todos = await _repository.GetAll();

            var endTime = DateTime.Now;
            var elapsedTime = endTime - startTime;

            var resultWithElapsedTime = new ResultWithElapsedTime<IEnumerable<TaskItem>>
            {
                ElapsedTime = elapsedTime,
                Data = todos
            };

            return Ok(resultWithElapsedTime);
        }


        public class ResultWithElapsedTime<T>
        {
            public TimeSpan ElapsedTime { get; set; }
            public T Data { get; set; }
        }


    }
}
