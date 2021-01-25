using BC.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace BC.Client
{
    public class MenuLoaderService
    {
        private readonly HttpClient _http;

        public MenuLoaderService(HttpClient http)
        {
            _http = http;
        }

        public async Task<MenuItemVM[]> GetAllMenuItemsAsync()
        {
            return await _http.GetFromJsonAsync<MenuItemVM[]>("/api/menu");
        }
    }
}
