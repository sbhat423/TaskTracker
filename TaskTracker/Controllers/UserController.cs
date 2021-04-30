using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskTrackerAPI.DTOs.User;

namespace TaskTrackerAPI.Controllers
{
    // Please refere the BoardController regarding the comments of validation and error messages inside each method

    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public UserController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var user = await _unitOfWork.Users.GetAllAsync();
            return Ok(user.ToList());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromRoute] int id)
        {
            var task = await _unitOfWork.Users.GetByIdAsync(id);
            return Ok(task);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] UserForCreationDto userForCreation)
        {
            var user = new User();
            // Map the Dto columnForCreation to column. For example refer BoardController
            await _unitOfWork.Users.AddAsync(user);
            await _unitOfWork.SaveChangesAsync();

            return Ok(user);
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] UserForUpdateDto userForUpdate)
        {
            var id = userForUpdate.UserId;
            var user = new User()
            {
                // Map the Dto userForUpdate to user by assigning properties
            };

            await _unitOfWork.Users.UpdateAsync(id, user);
            await _unitOfWork.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var user = await _unitOfWork.Users.GetByIdAsync(id);

            _unitOfWork.Users.Remove(user);
            await _unitOfWork.SaveChangesAsync();

            return Ok(user);
        }
    }
}
