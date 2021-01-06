using BC.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BC.Shared
{
    public class UserProfileVM
    {
        private readonly HttpClient _http;

        public UserProfileVM()
        {

        }

        public UserProfileVM(HttpClient http)
        {
            _http = http;
        }

        public int UserProfileId { get; set; }
        public string EmailAddress { get; set; }
        public string Password { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string AvatarUrl { get; set; }

        #region Implicit operators
        public static implicit operator UserProfileVM(UserProfile up)
        {
            if (up == null)
                return null;
            else return new UserProfileVM()
            {
                AvatarUrl = up.AvatarUrl,
                EmailAddress = up.EmailAddress,
                FirstName = up.FirstName,
                LastName = up.LastName,
                UserProfileId = up.UserProfileId,
            };
        }

        public static implicit operator UserProfile(UserProfileVM vm) => new UserProfile()
        {
            FirstName = vm.FirstName,
            AvatarUrl = vm.AvatarUrl,
            EmailAddress = vm.EmailAddress,
            LastName = vm.LastName,
            UserProfileId = vm.UserProfileId
        };
        #endregion
    }
}
