using Microsoft.EntityFrameworkCore;
using Todo.Models;

namespace Todo.Data;

public class AppDbContext : DbContext
{
    public DbSet<TodoModel> Todos { get; set; } // DbSet é uma coleção de entidades que representa uma tabela no banco de dados
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) // Configura o banco de dados 
    {
        optionsBuilder.UseSqlite("Data Source=app.db;Cache=Shared"); // Define o banco de dados SQLite
    }
}
