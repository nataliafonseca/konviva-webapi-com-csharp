using Microsoft.EntityFrameworkCore;
using ToDoList.DAL;
using ToDoList.Domain.DTO;
using ToDoList.Domain.Entity;
using ToDoList.Services.Base;

namespace ToDoList.Services
{
    public class ToDoService
    {
        private readonly AppDbContext _dbContext;

        public ToDoService(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public ServiceResponse<ToDoResponse> Create(ToDoCreateRequest model)
        {
            ToDo newToDo = new()
            {
                Title = model.Title,
                Description = model.Description,
                IsDone = false,
            };

            if (model.Priority == null)
                newToDo.Priority = 5;
            else
                newToDo.Priority = (int)model.Priority;

            _dbContext.Add(newToDo);
            _dbContext.SaveChanges();

            return new ServiceResponse<ToDoResponse>(new ToDoResponse(newToDo));
        }

        public IEnumerable<ToDoResponse> ListAll()
        {
            var dbReturn = _dbContext.ToDo.ToList();
            IEnumerable<ToDoResponse> list = dbReturn.Select(todo => new ToDoResponse(todo));
            return list;
        }

        public ServiceResponse<ToDoResponse> GetById(int id)
        {
            var dbReturn = _dbContext.ToDo.FirstOrDefault(todo => todo.Id == id);

            if (dbReturn == null)
                return new ServiceResponse<ToDoResponse>("There are no ToDos with this Id.");

            return new ServiceResponse<ToDoResponse>(new ToDoResponse(dbReturn));
        }

        public ServiceResponse<ToDoResponse> CheckAsDone(int id)
        {
            var dbReturn = _dbContext.ToDo.FirstOrDefault(todo => todo.Id == id);

            if (dbReturn == null)
                return new ServiceResponse<ToDoResponse>("There are no ToDos with this Id.");

            dbReturn.IsDone = true;

            _dbContext.ToDo.Add(dbReturn).State = EntityState.Modified;
            _dbContext.SaveChanges();

            return new ServiceResponse<ToDoResponse>(new ToDoResponse(dbReturn));
        }

        public ServiceResponse<ToDoResponse> UpdatePriority(int id, ToDoUpdateRequest model)
        {
            var dbReturn = _dbContext.ToDo.FirstOrDefault(todo => todo.Id == id);

            if (dbReturn == null)
                return new ServiceResponse<ToDoResponse>("There are no ToDos with this Id.");

            dbReturn.Priority = model.Priority;

            _dbContext.ToDo.Add(dbReturn).State = EntityState.Modified;
            _dbContext.SaveChanges();

            return new ServiceResponse<ToDoResponse>(new ToDoResponse(dbReturn));
        }

        public ServiceResponse<bool> Remove(int id)
        {
            var dbReturn = _dbContext.ToDo.FirstOrDefault(todo => todo.Id == id);

            if (dbReturn == null)
                return new ServiceResponse<bool>("There are no ToDos with this Id.");

            _dbContext.ToDo.Remove(dbReturn);
            _dbContext.SaveChanges();

            return new ServiceResponse<bool>(true);
        }

    }
}
