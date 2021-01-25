using BC.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BC.Shared.Models
{
    public class Goal
    {
        public int GoalId { get; set; }
        [Required]
        [MaxLength(200)]
        public string Name { get; set; }
        [Required]
        public DateTime ExpectedDeadline { get; set; }
        public int Difficulty { get; set; }
        public bool IsCompleted { get; set; }
        public DateTime DateCompleted { get; set; }

        [NotMapped]
        public int Points => IsCompleted ? Difficulty : 0;

        //[Required]
        public int OwnerId { get; set; }

        public Goal Parent { get; set; }
        public UserProfile Owner { get; set; }

    }
}
