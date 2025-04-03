using Application.UseCases.Common;
using Application.UseCases.Todos.AddTodo;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Task.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly IAddTodoUseCase _addTodoUseCase;
        public TaskController(IAddTodoUseCase addTodoUseCase)
        {
            _addTodoUseCase = addTodoUseCase;
        }

        [HttpPost]
        public async Task<IActionResult> CreateTodo([FromBody] AddTodoRequest request)
        {
            var result = await _addTodoUseCase.ExecuteAsync(request);
            if (result.IsFailure)
            {
                return BadRequest(result.Error);
            }
            return Ok(result);
        }
    }
}
