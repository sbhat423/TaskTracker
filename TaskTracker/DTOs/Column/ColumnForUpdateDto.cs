using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaskTracker.DTOs.Column
{
    public class ColumnForUpdateDto
    {
        public int ColumnId { get; set; }

        public string Name { get; set; }

        public int Order { get; set; }
    }
}
