using System.ComponentModel.DataAnnotations;

namespace ToDoList.Domain.DTO
{
    public class ToDoCreateRequest
    {
        [Required(AllowEmptyStrings = false)]
        public string Title { get; set; }

        public string? Description { get; set; }

        [Range(1, 5)]
        public int? Priority { get; set; }
    }
}
