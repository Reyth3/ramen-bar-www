using BC.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BC.Shared
{
    public class GoalInfo
    {
        public GoalInfo()
        {
            Children = new List<GoalInfo>();
        }

        public int GoalId { get; set; }
        public string Name { get; set; }
        public DateTime ExpectedDeadline { get; set; }
        public int Difficulty { get; set; }
        public bool IsCompleted { get; set; }
        public DateTime DateCompleted { get; set; }

        public int Points => IsCompleted ? Difficulty : 0;
        public int ParentId { get; set; }
        public int OwnerId { get; set; }
        public List<GoalInfo> Children { get; set; }

        public static List<GoalInfo> NestGoals(List<GoalInfo> goals)
        {
            var remainingUnassigned = new List<GoalInfo>();
            remainingUnassigned.AddRange(goals);
            var root = new List<GoalInfo>(goals.Where(o => o.ParentId == 0));
            var dictionary = new Dictionary<int, GoalInfo>();
            foreach (var goal in goals)
                if (goal != null)
                    dictionary.Add(goal.GoalId, goal);
            foreach (var goal in goals)
            {
                var assigned = new List<GoalInfo>();
                foreach (var unassigned in remainingUnassigned)
                    if (unassigned.ParentId == goal.GoalId)
                    {
                        goal.Children.Add(unassigned);
                        assigned.Add(unassigned);
                    }
                foreach (var item in assigned)
                    remainingUnassigned.Remove(item);
            }
            return root;
        }

        public static implicit operator Goal(GoalInfo gi)
        {
            return new Goal()
            {
                DateCompleted = gi.DateCompleted,
                Difficulty = gi.Difficulty,
                ExpectedDeadline = gi.ExpectedDeadline,
                Name = gi.Name,
                GoalId = gi.GoalId,
                IsCompleted = gi.IsCompleted,
                OwnerId = gi.OwnerId,
            };
        }

        public static implicit operator GoalInfo(Goal g)
        {
            return new GoalInfo() {
                GoalId = g.GoalId,
                DateCompleted = g.DateCompleted,
                Difficulty = g.Difficulty,
                ExpectedDeadline = g.ExpectedDeadline,
                IsCompleted = g.IsCompleted,
                Name = g.Name,
                ParentId = g.Parent?.GoalId ?? 0,
                OwnerId = g.OwnerId
            };

        }
    }
}
