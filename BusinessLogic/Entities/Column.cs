using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domain.Entities
{
    public class Column
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ColumnId { get; set; }
        public int BoardId { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        public int Order { get; set; }
        public DateTime CreatedOn { get; set; }
        public virtual List<Task> Tasks { get; set; }
    }
}
