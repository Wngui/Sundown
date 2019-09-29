using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sundown.ViewModels
{
    public class TimeSlots
    {
        private TimeSpan Open { get; } = Constants.Open;
        private TimeSpan Close { get; } = Constants.Close;
        private TimeSpan SlotSize { get; } = Constants.SlotSize;
        private TimeSpan SlotInterval { get; } = Constants.SlotInterval;

        public List<TimeSlot> slots {get;}

        public TimeSlots(DateTime selectedDate)
        {
            slots = new List<TimeSlot>();
            TimeSpan currentSpan = Open;
            while (currentSpan <= Close - SlotSize)
            {
                slots.Add(new TimeSlot
                {
                    Time = currentSpan,
                    FullDate = selectedDate.Add(currentSpan)
                }); 
                currentSpan += SlotInterval;
            }
        }
    }
}
