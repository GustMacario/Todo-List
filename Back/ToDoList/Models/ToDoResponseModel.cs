using ToDoList.Entities;
using ToDoList.Utils.Enums;

namespace ToDoList.Models
{
    public class ToDoResponseModel
    {
        public ToDoResponseModel(ToDo todo)
        {
            TodoId = todo.TodoId;
            Name = todo.Name;
            Description = todo.Description;
            ExpectedDate = todo.ExpectedDate;
            Status = todo.Status;
            Priority = todo.Priority;
            CreatedAt = todo.CreatedAt;
            UpdatedAt = todo.UpdatedAt;
            Delayed = todo.ExpectedDate < System.DateTime.Now && todo.Status != ToDoStatus.Done;

        }
        public Guid TodoId { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public DateTime ExpectedDate { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public ToDoStatus Status { get; set; }
        public Priority Priority { get; set; }
        public bool Delayed { get; set; }
    }
}
