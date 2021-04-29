using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskTracker.DTOs.Board;

namespace TaskTracker.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BoardController : ControllerBase
    {
        // provide all the services here
        public BoardController()
        {

        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            // var boards = get all the boards from the db and return in ok()
            return Ok();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromRoute] int id)
        {
            // var board = read the board with the given id and return in the Ok()
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] BoardForCreationDto boardForCreation)
        {
            // validate boardForCreation
            // if not valid return BadRequest()
            var board = new Board
            {
                Name = boardForCreation.Name,
                Description = boardForCreation.Description
            };

            // save the board in the database
            return Ok(board);
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] BoardForUpdateDto boardForUpdate) 
        {
            var id = boardForUpdate.BoardId;
            // var boardToUpdate = read board from the Boards table using the id
            // boardToUpdate.Name = boardForUpdate.Name
            // boardToUpdate.Description = boardToUpdate.Description
            // save the boardToUpdate and return it in the Ok()
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            // delete the board based on the id and return the deleted board
            return Ok();
        }
    }
}
