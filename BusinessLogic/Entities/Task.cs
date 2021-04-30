using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domain.Entities
{
    public class Task
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TaskId { get; set; }
        public int ColumnId { get; set; }

        [Required]
        [MaxLength(100)]
        public string Title { get; set; }

        public string Description { get; set; }
        public virtual Column Status { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public DateTime CreatedOn { get; set; }
        public int Order { get; set; }
        public List<string> Comments { get; set; }
        public List<int> AssigneeIds { get; set; }
        public virtual List<User> Assignees { get; set; }
    }
}
