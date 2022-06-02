using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ToDoList.Domain.DTO;
using ToDoList.Services;

namespace ToDoList.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToDoController : ControllerBase
    {
        private readonly ToDoService toDoService;

        public ToDoController(ToDoService toDoService)
        {
            this.toDoService = toDoService;
        }

        [HttpGet]
        public IEnumerable<ToDoResponse> ListAll()
        {
            return toDoService.ListAll();
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var response = toDoService.GetById(id);

            if (!response.Success)
                return NotFound(response);

            return Ok(response.Data);
        }

        [HttpPost]
        public IActionResult Create([FromBody] ToDoCreateRequest request)
        {
            if (ModelState.IsValid)
            {
                var response = this.toDoService.Create(request);

                if (!response.Success)
                    return BadRequest(response);
                return Ok(response.Data);
            }

            return BadRequest(ModelState);

        }

        [HttpPut("check/{id}")]
        public IActionResult CheckAsDone(int id)
        {
            var response = toDoService.CheckAsDone(id);

            if (!response.Success)
                return NotFound(response);

            return Ok(response.Data);
        }


        [HttpPut("{id}")]
        public IActionResult UpdatePriority(int id, [FromBody] ToDoUpdateRequest putModel)
        {
            if (ModelState.IsValid)
            {
                var response = toDoService.UpdatePriority(id, putModel);

                if (!response.Success)
                    return NotFound(response);

                return Ok(response.Data);
            }

            return BadRequest(ModelState);
        }

        [HttpDelete("{id}")]
        public IActionResult Remove(int id)
        {
            var response = toDoService.Remove(id);

            if (!response.Success)
                return NotFound(response);

            return Ok(response.Data);
        }
    }
}
