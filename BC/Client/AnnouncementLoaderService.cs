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
    public class AnnouncementLoaderService
    {
        private readonly HttpClient _http;

        public AnnouncementLoaderService(HttpClient http)
        {
            _http = http;
        }

        public async Task<AnnouncementVM[]> GetRecentAnnouncementsAsync(int count)
        {
            return await _http.GetFromJsonAsync<AnnouncementVM[]>($"/api/announcements/recent/{count}");
        }

        public async Task<AnnouncementVM> GetAnnouncementById(int id)
        {
            return await _http.GetFromJsonAsync<AnnouncementVM>($"/api/announcements/{id}");
        }

        public async Task<bool> PostNewAnnouncement(AnnouncementVM vm)
        {
            var res = await _http.PostAsJsonAsync("api/announcements/new", vm);
            return res.IsSuccessStatusCode;
        }
    }
}
