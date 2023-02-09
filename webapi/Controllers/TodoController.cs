using Microsoft.AspNetCore.Mvc;
using webapi.Models;
using webapi.Services;

namespace webapi.Controllers;

[ApiController]
[Route("[controller]")]
public class TodoController : ControllerBase
{
    private readonly ILogger<TodoController> _logger;
    private readonly ITodoService todoService;

    public TodoController(ILogger<TodoController> logger, ITodoService todoService)
    {
        _logger = logger;
        this.todoService = todoService;
    }

    [HttpGet(Name = "GetTodo")]
    public IList<Todo> Get()
    {
        return todoService.GetTodos();
    }

    [HttpPost(Name = "CreateTodo")]
    public Todo Create([FromBody] Todo todo) {
        return todoService.CreateTodo(todo);
    }

}