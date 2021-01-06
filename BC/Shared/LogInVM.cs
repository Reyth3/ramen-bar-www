using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace BC.Shared
{
    public class LogInVM
    {
        private readonly HttpClient _http;

        public LogInVM() { }
        public LogInVM(HttpClient http)
        {
            _http = http;
        }

        public string Email { get; set; }
        public string Password { get; set; }
        public string UIMessage { get; set; }

        public async Task<bool> SignInUserAsync()
        {
            if(string.IsNullOrEmpty(Email) || !Email.Contains("@") || Password.Length < 4 || string.IsNullOrEmpty(Password))
            {
                UIMessage = "Provided email and password is incorrect.";
                return false;
            }
            var res = await _http.PostAsJsonAsync("user/login", this);
            if (res.StatusCode == System.Net.HttpStatusCode.OK)
                return true;
            else return false;
        }
    }
}
