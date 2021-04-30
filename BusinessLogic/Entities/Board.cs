using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domain.Entities
{
    public class Board
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BoardId { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreatedOn { get; set; }
        public int CreatorId { get; set; }
        public List<int> BoardMemberIds { get; set; }
        public virtual User Creator { get; set; }
        public virtual List<User> BoardMembers { get; set; }
        public virtual List<Column> Columns { get; set; }
    }
}
