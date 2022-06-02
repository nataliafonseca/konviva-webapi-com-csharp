using System.ComponentModel.DataAnnotations;

namespace ToDoList.Domain.DTO
{
    public class ToDoUpdateRequest
    {
        [Range(1, 5)]
        public int Priority { get; set; }
    }
}
