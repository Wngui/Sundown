using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;
using Sundown.Logic;
using Sundown.Models;
using Sundown.ViewModels;

namespace Sundown.Controllers
{
    public class BookingController : Controller
    {

        LiteDatabaseContext _context;
        private readonly ILogger<BookingController> _logger;

        public BookingController(ILogger<BookingController> logger, LiteDatabaseContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Reservation()
        {
            List<string> Drinks = new List<string>();
            using (WebClient wc = new WebClient())
            {
                string json = wc.DownloadString(Constants.DrinksUrl);
                JArray drinks = JArray.Parse(json);
                Drinks = drinks.Values<string>("name").ToList();
            }

            string Menu;
            using (WebClient wc = new WebClient())
            {
                string json = wc.DownloadString(Constants.MenuUrl);
                JObject menu = JObject.Parse(json);
                Menu = menu["meals"][0]["strMeal"].ToString();
            }

            ReservationViewModel ReservationViewModel = new ReservationViewModel(Menu, Drinks);
            return View(ReservationViewModel);
        }

        public IActionResult ReservationSummary(ReservationViewModel reservation)
        {
            if (ModelState.IsValid)
            {
                return View(reservation);
            }
            return RedirectToAction("Error");
        }

        public IActionResult ConfirmReservation(ReservationViewModel reservation)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Error");
            }
            TimeSlot slot = new TimeSlot();
            slot.FullDate = reservation.ReservationDate;
            //Ensure reservation is still available
            if (ReservationLogic.isAvailable(_context, reservation.GuestAmount, ReservationLogic.getTableCount(_context), slot))
            {
                //Convert out viewmodel to entity model
                Reservation EntityReservation = new Reservation();
                EntityReservation.ReservationId = Guid.NewGuid().ToString();
                EntityReservation.BookingUser = reservation.User;
                EntityReservation.GuestAmount = reservation.GuestAmount;
                EntityReservation.ReservationTime = reservation.ReservationDate;
                EntityReservation.Menu = reservation.Menu;
                EntityReservation.Drink = reservation.Drink;

                List<Table> desiredTables = ReservationLogic.reserveTables(_context, reservation.GuestAmount, slot);
                foreach (Table table in desiredTables)
                {
                    TableReservation tableReservation = new TableReservation();
                    tableReservation.Reservation = EntityReservation;
                    tableReservation.ReservationId = EntityReservation.ReservationId;
                    tableReservation.Table = table;
                    tableReservation.TableId = table.TableId;
                    EntityReservation.TableReservations.Add(tableReservation);
                }
                
                //Save entity to db
                _context.Add(EntityReservation);
                _context.SaveChanges();
                return View();
            }
            else
            {
                return RedirectToAction("Error");
            }
        }

        public async Task<JsonResult> GetTimeSlots(int guests, string date)
        {
            DateTime dt = DateTime.ParseExact(date, "MM/dd/yyyy", CultureInfo.InvariantCulture);
            TimeSlots timeslots = new TimeSlots(dt);
            foreach (TimeSlot slot in timeslots.slots)
            {
                slot.isAvailable = ReservationLogic.isAvailable(_context, guests, ReservationLogic.getTableCount(_context), slot);
            }
            return Json(timeslots.slots);
        }

        public IActionResult ViewReservations()
        {
            List<Reservation> reservations = ReservationLogic.getAllReservations(_context);
            ViewBag.reservations = reservations;
            return View();
        }

        public IActionResult Remove(string Id)
        {
            ReservationLogic.removeById(_context, Id);
            return RedirectToAction("ViewReservations");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
