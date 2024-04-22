using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ToDoList.Interfaces.Services;
using ToDoList.Models;
using ToDoList.Utils;
using ToDoList.Utils.Enums;

namespace ToDoList.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class ToDoController : ControllerBase
    {
        private readonly IToDoService _toDoService;

        public ToDoController(IToDoService toDoService)
        {
            _toDoService = toDoService;
        }

        /// <summary>
        /// Create a ToDo Task
        /// </summary>       
        /// <returns>ResponseUtil</returns>
        /// <response code="200">ResponseUtil</response>
        /// <response code="400">Corpo da requisição inválido</response> 
        /// <response code="401">Token Inválido</response>  
        /// <response code="500">Erro Interno</response>  
        [HttpPost]
        [Route("CreateToDo")]
        [ProducesResponseType(typeof(ResponseUtil), 200)]
        public IActionResult CreateToDo(ToDoRequestModel model)
        {
            var response = _toDoService.CreateToDo(model);

            if (!response.Sucesso)
                return BadRequest(response);

            return Ok(response);
        }

        /// <summary>
        /// Get a ToDo Task by Id
        /// </summary>       
        /// <returns>ResponseUtil</returns>
        /// <response code="200">ResponseUtil</response>
        /// <response code="400">Corpo da requisição inválido</response> 
        /// <response code="401">Token Inválido</response>  
        /// <response code="500">Erro Interno</response>  
        [HttpGet]
        [Route("GetToDoById/{toDoId}")]
        [ProducesResponseType(typeof(ResponseUtil), 200)]
        public IActionResult GetToDoById([FromRoute]Guid toDoId)
        {
            var response = _toDoService.GetToDoById(toDoId);

            if (!response.Sucesso)
                return BadRequest(response);

            return Ok(response);
        }

        /// <summary>
        /// Get all ToDo Tasks
        /// </summary>       
        /// <returns>ResponseUtil</returns>
        /// <response code="200">ResponseUtil</response>
        /// <response code="400">Corpo da requisição inválido</response> 
        /// <response code="401">Token Inválido</response>  
        /// <response code="500">Erro Interno</response>  
        [HttpGet]
        [Route("GetToDoTasks")]
        [ProducesResponseType(typeof(ResponseUtil), 200)]
        public IActionResult GetToDoTasks()
        {
            var response = _toDoService.GetToDoTasks();

            if (!response.Sucesso)
                return BadRequest(response);

            return Ok(response);
        }

        /// <summary>
        /// Edit a ToDo Task Status
        /// </summary>       
        /// <returns>ResponseUtil</returns>
        /// <response code="200">ResponseUtil</response>
        /// <response code="400">Corpo da requisição inválido</response> 
        /// <response code="401">Token Inválido</response>  
        /// <response code="500">Erro Interno</response>  
        [HttpPut]
        [Route("EditToDoTaskStatus/{toDoId}")]
        [ProducesResponseType(typeof(ResponseUtil), 200)]
        public IActionResult EditToDoTaskStatus(ToDoStatus status, [FromRoute] Guid toDoId)
        {
            var response = _toDoService.EditStatusToDo(status, toDoId);

            if (!response.Sucesso)
                return BadRequest(response);

            return Ok(response);
        }

        /// <summary>
        /// Delete a ToDo Task
        /// </summary>       
        /// <returns>ResponseUtil</returns>
        /// <response code="200">ResponseUtil</response>
        /// <response code="400">Corpo da requisição inválido</response> 
        /// <response code="401">Token Inválido</response>  
        /// <response code="500">Erro Interno</response>  
        [HttpDelete]
        [Route("DeleteToDoTask/{toDoId}")]
        [ProducesResponseType(typeof(ResponseUtil), 200)]
        public IActionResult DeleteToDoTask([FromRoute]Guid toDoId)
        {
            var response = _toDoService.DeleteToDo(toDoId);

            if (!response.Sucesso)
                return BadRequest(response);

            return Ok(response);
        }
    }
}
