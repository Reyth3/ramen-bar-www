using BC.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
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
        public bool IsEditor { get; set; }
        public int PostedAnnouncementsCount { get; set; }
        public int ReservationsCount { get; set; }

        public async Task GetCurrentlyLoggedInUser()
        {
            var user = await _http.GetFromJsonAsync<UserProfileVM>("/user/current");
            if (user == null)
                return;
            EmailAddress = user.EmailAddress;
            FirstName = user.FirstName;
            LastName = user.LastName;
            IsEditor = user.IsEditor;
            PostedAnnouncementsCount = user.PostedAnnouncementsCount;
            ReservationsCount = user.ReservationsCount;
        }

        public async Task LogOutCurrentUser()
        {
            var user = await _http.GetFromJsonAsync<object>("/user/logout");
        }

        #region Implicit operators
        public static implicit operator UserProfileVM(UserProfile up)
        {
            if (up == null)
                return null;
            else return new UserProfileVM()
            {
                PostedAnnouncementsCount = up.PostedAnnouncements.Count,
                ReservationsCount = up.Reservations.Count,
                IsEditor = up.IsEditor,
                EmailAddress = up.EmailAddress,
                FirstName = up.FirstName,
                LastName = up.LastName,
                UserProfileId = up.UserProfileId,
            };
        }

        public static implicit operator UserProfile(UserProfileVM vm) => new UserProfile()
        {
            FirstName = vm.FirstName,
            EmailAddress = vm.EmailAddress,
            LastName = vm.LastName,
            UserProfileId = vm.UserProfileId
        };
        #endregion
    }
}
