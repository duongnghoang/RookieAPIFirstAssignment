using Application.UseCases.Todos.AddTodo;
using Application.UseCases.Todos.BulkAddTodosUseCase;
using Application.UseCases.Todos.BulkRemoveTodosUseCase;
using Application.UseCases.Todos.DeleteTodo;
using Application.UseCases.Todos.GetAllTodosUseCase;
using Application.UseCases.Todos.GetTodoByIdUseCase;
using Application.UseCases.Todos.UpdateTodo;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Task.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodosController : ControllerBase
    {
        private readonly IAddTodoUseCase _addTodoUseCase;
        private readonly IUpdateTodoUseCase _updateTodoUseCase;
        private readonly IGetAllTodosUseCase _getAllTodosUseCase;
        private readonly IDeleteTodoUseCase _deleteTodoUseCase;
        private readonly IGetTodoByIdUseCase _getTodoByIdUseCase;
        private readonly IBulkDeleteTodosUseCase _bulkDeleteTodosUseCase;
        private readonly IBulkAddTodosUseCase _bulkAddTodosUseCase;

        public TodosController(IAddTodoUseCase addTodoUseCase, IUpdateTodoUseCase updateTodoUseCase,
            IGetAllTodosUseCase getAllTodosUseCase, IDeleteTodoUseCase deleteTodoUseCase, IGetTodoByIdUseCase getTodoByIdUseCase, IBulkAddTodosUseCase bulkAddTodosUseCase, IBulkDeleteTodosUseCase bulkDeleteTodosUseCase)
        {
            _addTodoUseCase = addTodoUseCase;
            _updateTodoUseCase = updateTodoUseCase;
            _getAllTodosUseCase = getAllTodosUseCase;
            _deleteTodoUseCase = deleteTodoUseCase;
            _getTodoByIdUseCase = getTodoByIdUseCase;
            _bulkAddTodosUseCase = bulkAddTodosUseCase;
            _bulkDeleteTodosUseCase = bulkDeleteTodosUseCase;
        }

        [HttpPost]
        public async Task<IActionResult> CreateTodo([FromBody] AddTodoRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _addTodoUseCase.ExecuteAsync(request);
            if (result.IsFailure)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTodo(Guid id, [FromBody] UpdateTodoRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            request.Id = id;
            var result = await _updateTodoUseCase.ExecuteAsync(request);
            if (result.IsFailure)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllTodos()
        {
            var result = await _getAllTodosUseCase.ExecuteAsync();

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTodo(Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _deleteTodoUseCase.ExecuteAsync(id);
            if (result.IsFailure)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTodoById(Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _getTodoByIdUseCase.ExecuteAsync(id);

            return Ok(result);
        }

        [HttpPost("bulk-insert")]
        public async Task<IActionResult> BulkInsert([FromBody] List<AddTodoRequest> requests)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _bulkAddTodosUseCase.ExecuteAsync(requests);
            if (result.IsFailure)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        [HttpDelete("bulk-delete")]
        public async Task<IActionResult> BulkDelete([FromBody] List<Guid> requests)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _bulkDeleteTodosUseCase.ExecuteAsync(requests);
            if (result.IsFailure)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

    }
}
