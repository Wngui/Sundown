using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sundown.ViewModels
{
    public class TimeSlot
    {
        public TimeSpan Time { get; set; }
        public string TimeString { get { return FullDate.ToString("HH:mm"); } }
        public string FullTimeString { get { return FullDate.ToString("dd/MM HH:mm"); } }
        public DateTime FullDate { get; set; }
        public bool isAvailable { get; set; } = true;
    }
}
