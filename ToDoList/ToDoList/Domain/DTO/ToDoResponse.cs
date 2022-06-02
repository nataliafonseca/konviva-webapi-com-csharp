using ToDoList.Domain.Entity;

namespace ToDoList.Domain.DTO
{
    public class ToDoResponse
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string? Description { get; set; }
        public bool IsDone { get; set; }
        public int? Priority { get; set; }

        public ToDoResponse(ToDo todo)
        {
            Id = todo.Id;
            Title = todo.Title;
            Description = todo.Description;
            IsDone = todo.IsDone;
            Priority = todo.Priority;
        }
    }
}
