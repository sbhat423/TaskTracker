using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaskTracker.DTOs.Board
{
    public class ColumnForCreationDto
    {
        public int BoardId { get; set; }
        public string Name { get; set; }

        public int Order { get; set; }
    }
}
