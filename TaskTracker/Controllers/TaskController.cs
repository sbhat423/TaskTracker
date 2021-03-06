using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskTracker.DTOs.Task;

namespace TaskTracker.Controllers
{
    // Please refere the BoardController regarding the comments of validation and error messages inside each method

    [ApiController]
    [Route("[controller]")]
    public class TaskController: ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public TaskController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var tasks = await _unitOfWork.Tasks.GetAllAsync();
            return Ok(tasks.ToList());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromRoute] int id)
        {
            var task = await _unitOfWork.Tasks.GetByIdAsync(id);
            return Ok(task);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] TaskForCreationDto taskForCreation)
        {
            var task = new Domain.Entities.Task();
            // Map the Dto columnForCreation to column. For example refer BoardController
            // Assign the AssigneeIds of task by providing the userIds if needed
            await _unitOfWork.Tasks.AddAsync(task);
            await _unitOfWork.SaveChangesAsync();

            return Ok(task);
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] TaskForUpdateDto taskForUpdate)
        {
            var id = taskForUpdate.TaskId;
            var task = new Domain.Entities.Task()
            {
                // Map the Dto userForUpdate to user by assigning properties
                // Add other members by assigning userIds in the list AssigneeIds of task
            };
            await _unitOfWork.Tasks.UpdateAsync(id, task);

            await _unitOfWork.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var task = await _unitOfWork.Tasks.GetByIdAsync(id);
            
            _unitOfWork.Tasks.Remove(task);
            await _unitOfWork.SaveChangesAsync();

            return Ok(task);
        }
    }
}
