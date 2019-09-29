using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sundown.Models
{
    public class TableReservation
    {
        public string ReservationId { get; set; }
        public Reservation Reservation { get; set; }
        public string TableId { get; set; }
        public Table Table { get; set; }
    }
}
