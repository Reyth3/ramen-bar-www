using System;
using System.ComponentModel.DataAnnotations;

namespace BC.Core.Models
{
    public interface IGoal
    {
        DateTime DateCompleted { get; set; }
        int Difficulty { get; set; }
        DateTime ExpectedDeadline { get; set; }
        int GoalId { get; set; }
        bool IsCompleted { get; set; }
        string Name { get; set; }
        IUserProfile Owner { get; set; }
        int OwnerId { get; set; }
        IGoal Parent { get; set; }
        int Points { get; }
    }
}