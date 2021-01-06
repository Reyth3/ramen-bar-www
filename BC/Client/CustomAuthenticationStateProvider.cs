using BC.Shared;
using Microsoft.AspNetCore.Components.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BC.Client
{
    public class CustomAuthenticationStateProvider : AuthenticationStateProvider
    {
        private readonly HttpClient _http;

        public CustomAuthenticationStateProvider(HttpClient http)
        {
            _http = http;
        }

        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            var user = await _http.GetFromJsonAsync<UserProfileVM>("user/current");
            if (user != null && user.EmailAddress != null)
            {
                var claim = new Claim(ClaimTypes.Name, user.EmailAddress);
                var identity = new ClaimsIdentity(new Claim[] { claim }, "ServerAuth");
                var principal = new ClaimsPrincipal(identity);
                return new AuthenticationState(principal);
            }
            return new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity()));
        }
    }
}
