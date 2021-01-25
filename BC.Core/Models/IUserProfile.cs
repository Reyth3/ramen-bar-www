using System.Collections.Generic;

namespace BC.Core.Models
{
    public interface IUserProfile
    {
        string AvatarUrl { get; set; }
        string EmailAddress { get; set; }
        string FirstName { get; set; }
        List<IGoal> Goals { get; set; }
        string LastName { get; set; }
        string Password { get; set; }
        string Salt { get; set; }
        int UserProfileId { get; set; }
    }
}