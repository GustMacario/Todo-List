using Microsoft.EntityFrameworkCore;
using ToDoList.Context;
using ToDoList.Entities;
using ToDoList.Interfaces.Repositories;

namespace ToDoList.Repositories
{
    public class ToDoRepository : RepositoryBase<ToDo>, IToDoRepository
    {
        private readonly DbSet<ToDo> _ToDos;

        public ToDoRepository(AppDbContext context) : base(context)
        {
            _ToDos = context.ToDos;
        }

    }
}
