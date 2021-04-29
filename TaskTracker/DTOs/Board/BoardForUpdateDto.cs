using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaskTracker.DTOs.Board
{
    public class BoardForUpdateDto
    {
        public int BoardId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
