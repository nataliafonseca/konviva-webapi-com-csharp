using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ToDoList.Domain.Entity
{
    [Table("ToDo")]
    public class ToDo
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Title { get; set; }

        [StringLength(255)]
        public string? Description { get; set; }

        [Required]
        public bool IsDone { get; set; }

        [Required]
        public int Priority { get; set; }
    }
}
