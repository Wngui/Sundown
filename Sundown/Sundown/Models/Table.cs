using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Sundown.Models
{
    public class Table
    {
        public Table()
        {
            this.TableReservations = new List<TableReservation>();
        }

        [Key]
        public string TableId { get; set; }
        public virtual ICollection<TableReservation> TableReservations { get; set; }
    }
}
