using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Sundown.ViewModels
{
    public class ReservationViewModel
    {
        private readonly int MaxGuests = Constants.MaxGuests;
        private readonly int MinGuests = Constants.MinGuests;

        [Range(1,10)]
        [Required]
        public int GuestAmount { get; set; }
        [Required]
        public DateTime ReservationDate { get; set; }
        [EmailAddress(ErrorMessage ="Invalid Email.")]
        [Required]
        public string User { get; set; }
        [Required]
        public string Menu { get; set; }
        [Required]
        public string Drink { get; set; }

        public SelectList GuestAmountList { get; set; }
        public SelectList DrinksList { get; set; }

        public ReservationViewModel()
        {

        }

        public ReservationViewModel(string Menu, List<string> Drinks)
        {
            this.Menu = Menu;

            //Dropdown option for drinks
            List<SelectListItem> drinks = new List<SelectListItem>();
            foreach (string drink in Drinks)
            {
                drinks.Add(new SelectListItem
                {
                    Text = drink,
                    Value = drink
                });
            }
            DrinksList = new SelectList(drinks, "Value", "Text");

            //Dropdown option for guest amount
            List<SelectListItem> guests = new List<SelectListItem>();
            for (int i = MinGuests; i <= MaxGuests; i++)
            {
                guests.Add(new SelectListItem
                {
                    Text = $"{i} Guests",
                    Value = i.ToString()
                });
            }
            GuestAmountList = new SelectList(guests, "Value", "Text");
        }
    }
}
