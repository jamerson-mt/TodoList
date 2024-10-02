using Microsoft.AspNetCore.Mvc;
using Todo.Models;
using Todo.Data;

namespace Todo.Controllers
{

    [ApiController]
    public class HomeController : ControllerBase
    {
        [HttpGet("/list")]
        public List<TodoModel> Get([FromServices] AppDbContext context)
        {
            return context.Todos.ToList(); // Get all todos
        }

        [HttpGet("/list/{id:int}")]
        public TodoModel GetById(
            [FromRoute] int id,
            [FromServices] AppDbContext context)
        {
            return context.Todos.FirstOrDefault(x => x.Id == id); // pesquisar por id e retornar o todo correspondente 
        }

        [HttpPost("/create")]
        public TodoModel Post([FromServices] AppDbContext context, [FromBody] TodoModel model)
        {
            context.Todos.Add(model); // Add new todo
            context.SaveChanges(); // Save changes
            return model; // Return new todo
        }


        [HttpPut("/update/{id:int}")]
        public TodoModel Put([FromServices] AppDbContext context, [FromBody] TodoModel model, [FromRoute] int id)
        {
            var todo = context.Todos.FirstOrDefault(x => x.Id == id); // Get todo by id
            if (todo == null) return null; // If todo not found, return bad request

            todo.Name = model.Name; // Update model name
            todo.Status = model.Status; // Update model status
            context.SaveChanges(); // Save changes
            return todo; // Return updated todo
        }

        [HttpDelete("/remove/{id:int}")]
        public TodoModel Delete([FromServices] AppDbContext context, [FromRoute] int id)
        {
            var todo = context.Todos.FirstOrDefault(x => x.Id == id); // Get todo by id
            if (todo == null) return null; // If todo not found, return bad request

            context.Todos.Remove(todo); // Remove todo
            context.SaveChanges(); // Save changes
            return todo; // Return removed todo
        }



    }
}