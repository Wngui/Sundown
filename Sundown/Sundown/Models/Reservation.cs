using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Sundown.Models
{
    public class Reservation
    {
        public Reservation()
        {
            this.TableReservations = new List<TableReservation>();
        }

        [Key]
        public string ReservationId { get; set; }
        public string BookingUser { get; set; }
        public int GuestAmount { get; set; }
        public DateTime ReservationTime { get; set; }
        public virtual ICollection<TableReservation> TableReservations { get; set; }
        public string Drink { get; set; }
        public string Menu { get; set; }
    }
}
