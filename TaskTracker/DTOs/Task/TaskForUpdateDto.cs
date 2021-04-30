using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaskTracker.DTOs.Task
{
    public class TaskForUpdateDto
    {
        public int TaskId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime CreatedOn { get; set; }
        public int Order { get; set; }
        public List<string> Comments { get; set; }

    }
}
