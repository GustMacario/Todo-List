using ToDoList.Entities;
using ToDoList.Models;
using ToDoList.Utils;
using ToDoList.Utils.Enums;

namespace ToDoList.Interfaces.Services
{
    public interface IToDoService : IServiceBase<ToDo>
    {
        ResponseUtil CreateToDo(ToDoRequestModel model);
        ResponseUtil GetToDoById(Guid todoId);
        ResponseUtil EditStatusToDo(ToDoStatus status, Guid todoId);
        ResponseUtil GetToDoTasks();
        ResponseUtil DeleteToDo(Guid todoId);
    }
}
