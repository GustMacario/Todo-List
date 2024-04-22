using System.ComponentModel.DataAnnotations;
using ToDoList.Utils.Enums;

namespace ToDoList.Models
{
    public class ToDoRequestModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime ExpectedDate { get; set; }
        [Range(0, 2, ErrorMessage = "Priority must be between 0 and 2.")]
        public Priority Priority { get; set; }
    }
}
