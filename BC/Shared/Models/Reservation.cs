using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BC.Shared.Models
{
    public class Reservation
    {
        public Reservation()
        {

        }

        public int ReservationId { get; set; }
        public DateTimeOffset ReservationTime { get; set; }
        public int GuestsNumber { get; set; }

        public UserProfile Owner { get; set; }
    }
}
