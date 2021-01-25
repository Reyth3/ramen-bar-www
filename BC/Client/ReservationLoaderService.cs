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
    public class ReservationLoaderService
    {
        private readonly HttpClient _http;

        public ReservationLoaderService(HttpClient http)
        {
            _http = http;
        }

        public async Task<ReservationVM[]> GetAllReservationsAsync()
        {
            return await _http.GetFromJsonAsync<ReservationVM[]>("/api/reservations");
        }
    }
}
