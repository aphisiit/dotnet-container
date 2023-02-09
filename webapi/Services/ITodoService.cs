using System;
using webapi.Models;

namespace webapi.Services
{
	public interface ITodoService
	{
		public IList<Todo> GetTodos();
		public Todo CreateTodo(Todo todo);
	}
}

