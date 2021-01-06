using BC.Shared;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BC.Client
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");
            builder.Services.AddAuthorizationCore()
                .AddOptions()
                .AddScoped<AuthenticationStateProvider, CustomAuthenticationStateProvider>();

            var httpClientConfig = new Action<HttpClient>((http) => http.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress));
            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
            builder.Services.AddHttpClient<GoalsDashboardVM>(httpClientConfig);
            builder.Services.AddHttpClient<UserProfileVM>(httpClientConfig);
            builder.Services.AddHttpClient<LogInVM>(httpClientConfig);

            await builder.Build().RunAsync();
        }
    }
}
