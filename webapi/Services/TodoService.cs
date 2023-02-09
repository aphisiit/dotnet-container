using System;
using webapi.Models;
using webapi.PostgreSQL;

namespace webapi.Services
{
	public class TodoService : ITodoService
	{
        private readonly ILogger<TodoService> _logger;
        private readonly TestDbContext testDbContext;

		public TodoService(ILogger<TodoService> logger, TestDbContext testDbContext)
		{
            this._logger = logger;
            this.testDbContext = testDbContext;
		}

        public Todo CreateTodo(Todo todo)
        {
            testDbContext.Todos.Add(todo);
            testDbContext.SaveChanges();

            _logger.LogInformation($"todo : {@todo}");

            return todo;
        }

        public IList<Todo> GetTodos()
        {
            var result = testDbContext.Todos.ToList();

            _logger.LogInformation($"Todos: {@result}");

            return result;
        }


    }
}

