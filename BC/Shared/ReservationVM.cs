using BC.Shared.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace BC.Shared
{
    public class ReservationVM
    {
        private readonly HttpClient _http;

        public ReservationVM() { }
        public ReservationVM(HttpClient http)
        {
            _http = http;
        }

        public int ReservationId { get; set; }
        [Required]
        public DateTimeOffset ReservationTime { get; set; }
        [Required, System.ComponentModel.DataAnnotations.Range(1, 8)]
        public int GuestsNumber { get; set; }
        public bool Archived { get; set; }

        public async Task<ReservationVM[]> PostReservation()
        {
            var res = await _http.PostAsJsonAsync("/api/reservations/new", this);
            if (res.IsSuccessStatusCode)
                return await res.Content.ReadFromJsonAsync<ReservationVM[]>();
            else return null;
        }


        public static implicit operator ReservationVM(Reservation r)
        {
            if (r == null)
                return null;
            return new ReservationVM()
            {
                GuestsNumber = r.GuestsNumber,
                ReservationId = r.ReservationId,
                ReservationTime = r.ReservationTime,
                Archived = r.ReservationTime <= DateTimeOffset.UtcNow ? true : false,
            };
        }

        public static implicit operator Reservation(ReservationVM r)
        {
            if (r == null)
                return null;
            return new Reservation()
            {
                GuestsNumber = r.GuestsNumber,
                ReservationId = r.ReservationId,
                ReservationTime = r.ReservationTime,
            };
        }

    }
}
