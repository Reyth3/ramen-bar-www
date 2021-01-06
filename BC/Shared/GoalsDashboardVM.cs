using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace BC.Shared
{
    public class GoalsDashboardVM
    {
        private readonly HttpClient _http;

        public GoalsDashboardVM() { }
        public GoalsDashboardVM(HttpClient http)
        {
            _http = http;
        }

        public List<GoalInfo> Goals { get; set; }
        public List<GoalInfo> AllGoals { get; set; }

        public async Task GetUserGoals()
        {
            var allGoals = await _http.GetFromJsonAsync<List<GoalInfo>>("goals");
            Goals = GoalInfo.NestGoals(allGoals);
            AllGoals = allGoals;
        }
    }
}
