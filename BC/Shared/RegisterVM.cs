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
    public class RegisterVM
    {
        private readonly HttpClient _http;

        public RegisterVM() { }
        public RegisterVM(HttpClient http)
        {
            _http = http;
        }

        public string Email { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public async Task<bool> RegisterNewUser()
        {
            if(!string.IsNullOrEmpty(Email) && !string.IsNullOrEmpty(Password) && !string.IsNullOrEmpty(FirstName) && !string.IsNullOrEmpty(LastName))
            {
                await _http.PostAsJsonAsync("user/register", this);
            }
            return false;
        }


        public static implicit operator UserProfile(RegisterVM vm)
        {
            if (vm == null)
                return null;
            return new UserProfile()
            {
                EmailAddress = vm.Email,
                FirstName = vm.FirstName,
                LastName = vm.LastName,
                Password = vm.Password,
            };
        }
    }
}
