using ToDoList.Utils.Enums;

namespace ToDoList.Entities
{
    public class ToDo : AuditableEntity
    {
        public Guid TodoId { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public DateTime ExpectedDate { get; set; }
        public ToDoStatus Status { get; set; }
        public Priority Priority { get; set; }
    }
}
