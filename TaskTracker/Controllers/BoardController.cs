using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskTracker.DTOs.Board;

namespace TaskTracker.Controllers
{
    /// <summary>
    /// TODO: 
    /// Haven't implemented the validation.
    /// Haven't implemented the eager loading anywhere yet.
    /// Haven't added the ef migration
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class BoardController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public BoardController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var boards = await _unitOfWork.Boards.GetAllAsync();
            
            return Ok(boards);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromRoute] int id)
        {
            // Validate id, return appropriate error response code if invalid

            var board = await _unitOfWork.Boards.GetByIdAsync(id);

            // If board not found return appropriate error response code
            
            return Ok(board);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] BoardForCreationDto boardForCreation)
        {
            // Validate boardForCreation, return appropriate error response code if invalid

            var board = new Board
            {
                Name = boardForCreation.Name,
                Description = boardForCreation.Description
                // Assign other properties as well

                // Assing creatorId with the UserId
                // Add other members by assigning userIds in the list BoardMemberIds of board
            };

            await _unitOfWork.Boards.AddAsync(board);
            await _unitOfWork.SaveChangesAsync();
            
            // Return appropriate error response code with message if anything wrong happens during the operation
            
            return Ok(board);
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] BoardForUpdateDto boardForUpdate) 
        {
            // Validate id, return appropriate error response code if invalid
            var id = boardForUpdate.BoardId;
            var board = new Board()
            {
                // Map the Dto boardForUpdate to board by assigning properties
                // Add/delete other members by assigning userIds in the list BoardMemberIds
            };

            await _unitOfWork.Boards.UpdateAsync(id, board);
            await _unitOfWork.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            // Validate id, return appropriate error response code if invalid
            var board = await _unitOfWork.Boards.GetByIdAsync(id);
            // If board not found, return appropriate error response code

            _unitOfWork.Boards.Remove(board);
            await _unitOfWork.SaveChangesAsync();

            // Return appropriate error response code with message if anything wrong happens during the operation
            return Ok(board);
        }
    }
}
