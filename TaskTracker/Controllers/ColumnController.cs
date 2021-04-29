using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskTracker.DTOs.Board;
using TaskTracker.DTOs.Column;

namespace TaskTracker.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ColumnController: ControllerBase
    {
        // provide all related services here
        public ColumnController()
        {

        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            // get all the columns available in the table
            return Ok();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromRoute] int id)
        {
            // var column = get the column from the db and return it
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ColumnForCreationDto columnForCreation) 
        {
            //var column = new C
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] ColumnForUpdateDto columnForUpdate)
        {
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            // delete the column with the given id
            return Ok();
        }
    }
}
