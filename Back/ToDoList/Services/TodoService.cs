using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ToDoList.Entities;
using ToDoList.Interfaces.Repositories;
using ToDoList.Interfaces.Services;
using ToDoList.Models;
using ToDoList.Utils;
using ToDoList.Utils.Enums;
using ToDoList.Utils.Validators;

namespace ToDoList.Services
{
    public class TodoService : ServiceBase<ToDo>, IToDoService
    {
        private readonly IToDoRepository _todoRepository;

        public TodoService(IToDoRepository todoRepository) : base(todoRepository)
        {
            _todoRepository = todoRepository;
        }

        public ResponseUtil CreateToDo(ToDoRequestModel model)
        {
            ResponseUtil response = new ResponseUtil();
            try
            {
                //Model Validation
                var modelValidator = new ToDoRequestModelValidator().Validate(model);
                if (!modelValidator.IsValid)
                {
                    response.Sucesso = false;
                    response.Resultado = modelValidator.Errors.FirstOrDefault().ToString();
                    return response;
                }
                //Creating entity ToDo
                ToDo todo = new ToDo
                {
                    TodoId = Guid.NewGuid(),
                    Name = model.Name,
                    Description = model.Description,
                    ExpectedDate = model.ExpectedDate,
                    Status = ToDoStatus.Pending,
                    Priority = model.Priority
                };
                //Adding ToDo to database
                _todoRepository.Add(todo);

                response.Sucesso = true;
                response.Resultado = "ToDo Task created successfully.";
            }
            catch (Exception ex)
            {
                response.Sucesso = false;
                response.Resultado = $"Failed to create ToDo Task - {ex.Message}";
            }
            return response;
        }

        public ResponseUtil GetToDoById(Guid todoId)
        {
            ResponseUtil response = new ResponseUtil();
            try
            {
                //Validating ID
                if (todoId == Guid.Empty)
                {
                    response.Sucesso = false;
                    response.Resultado = "Invalid ID.";
                    return response;
                }
                //Getting ToDo from database
                ToDo todo = _todoRepository.GetById(todoId);
                if(todo == null)
                {
                    response.Sucesso = false;
                    response.Resultado = "ToDo not found.";
                    return response;
                }
                //converting entity to response model
                ToDoResponseModel todoResponse = new ToDoResponseModel(todo);

                response.Sucesso = true;
                response.Resultado = todoResponse;

            }
            catch (Exception ex)
            {
                response.Sucesso = false;
                response.Resultado = $"Failed to find ToDo Task - { ex.Message}";
            }
            return response;
        }

        public ResponseUtil GetToDoTasks()
        {
            ResponseUtil response = new ResponseUtil();
            try
            {
                List<ToDoResponseModel> toDoList = new List<ToDoResponseModel>();

                //Getting all ToDo tasks from database
                List<ToDo> toDos = _todoRepository.GetAll().ToList();
                //Validating if there are any ToDo tasks
                if (toDos.Count == 0)
                {
                    response.Sucesso = false;
                    response.Resultado = "No ToDo Task found.";
                    return response;
                }
                //Converting entity ToDo to response model
                toDoList = toDos.Select(x => new ToDoResponseModel(x)).ToList();

                response.Sucesso = true;
                response.Resultado = toDoList;

            }
            catch (Exception ex)
            {
                response.Sucesso = false;
                response.Resultado = ex.Message;
            }
            return response;
        }

        public ResponseUtil EditStatusToDo(ToDoStatus status, Guid todoId)
        {
            ResponseUtil response = new ResponseUtil();
            try
            {
                //Validating ID
                ToDo toDo = _todoRepository.GetById(todoId);
                if (toDo == null)
                {
                    response.Sucesso = false;
                    response.Resultado = "ToDo not found.";
                    return response;
                }

                //Updating ToDo status
                toDo.Status = status;
                _todoRepository.Edit(toDo);

                response.Sucesso = true;
                response.Resultado = "ToDo Task status updated successfully.";
            }
            catch (Exception ex)
            {
                response.Sucesso = false;
                response.Resultado = ex.Message;
            }
            return response;
        }

        public ResponseUtil DeleteToDo(Guid todoId)
        {
            ResponseUtil response = new ResponseUtil();
            try
            {
                //Validating ID
                ToDo toDo = _todoRepository.GetById(todoId);
                if (toDo == null)
                {
                    response.Sucesso = false;
                    response.Resultado = "ToDo not found.";
                    return response;
                }
                //Deleting ToDo from database
                _todoRepository.Remove(toDo);

                response.Sucesso = true;
                response.Resultado = "ToDo Task deleted successfully.";
            }
            catch (Exception ex)
            {
                response.Sucesso = false;
                response.Resultado = ex.Message;
            }
            return response;
        }
    }
}
