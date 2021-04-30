using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskTracker.DTOs.Board;
using TaskTracker.DTOs.Column;

namespace TaskTracker.Controllers
{
    // Please refere the BoardController regarding the comments of validation and error messages inside each method

    [ApiController]
    [Route("[controller]")]
    public class ColumnController: ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public ColumnController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var columns = await _unitOfWork.Columns.GetAllAsync();

            return Ok(columns);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromRoute] int id)
        {
            var column = await _unitOfWork.Columns.GetByIdAsync(id);

            return Ok(column);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ColumnForCreationDto columnForCreation) 
        {
            var column = new Column();
            // Map the Dto columnForCreation to the column object, for example refer the BoardController 
            await _unitOfWork.Columns.AddAsync(column);
            await _unitOfWork.SaveChangesAsync();
            return Ok(column);
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] ColumnForUpdateDto columnForUpdate)
        {
            var id = columnForUpdate.ColumnId;
            var column = new Column()
            {
                // Map the Dto columnForUpdate to column by assigning properties
            };

            await _unitOfWork.Columns.UpdateAsync(id, column);
            await _unitOfWork.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var column = await _unitOfWork.Columns.GetByIdAsync(id);
            _unitOfWork.Columns.Remove(column);
            await _unitOfWork.SaveChangesAsync();
            return Ok(column);
        }
    }
}
