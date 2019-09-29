using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sundown
{
    public class Constants
    {
        public static readonly string DrinksUrl = "https://api.punkapi.com/v2/beers";
        public static readonly string MenuUrl = "https://www.themealdb.com/api/json/v1/1/random.php";

        public static readonly int MaxGuests = 10;
        public static readonly int MinGuests = 2;
        public static readonly int TableSize = 2;
        public static readonly TimeSpan Open = new TimeSpan(16, 0, 0);
        public static readonly TimeSpan Close = new TimeSpan(22, 0, 0);
        public static readonly TimeSpan SlotSize = new TimeSpan(2, 0, 0);
        public static readonly TimeSpan SlotInterval = new TimeSpan(0, 15, 0);
    }
}
