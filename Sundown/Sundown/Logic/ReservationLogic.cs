using Microsoft.EntityFrameworkCore;
using Sundown.Models;
using Sundown.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sundown.Logic
{
    public static class ReservationLogic
    {
        public static bool isAvailable(LiteDatabaseContext _context, int guests, int tables, TimeSlot timeslot)
        {
            List<Reservation> reservations = getReservations(_context, timeslot);
            //How many tables are booked for this timeslot?
            int usedtables = reservations.Sum(res => res.TableReservations.Count);
            //Decide if the slot available given the desired guest amount and current booked tables
            int tables_needed = guests / Constants.TableSize;
            return (tables - usedtables) >= tables_needed;
        }

        public static List<Table> reserveTables(LiteDatabaseContext _context, int guests, TimeSlot timeslot)
        {
            //Reserve the needed amount of tables
            List<Table> availableTables = getAvailableTables(_context, timeslot);
            int requiredTables = (int)Math.Ceiling((double)guests / (double)Constants.TableSize);
            return availableTables.Take(requiredTables).ToList();
        }

        private static List<Table> getAvailableTables(LiteDatabaseContext _context, TimeSlot timeslot)
        {
            //Get available tables in the given timeslot
            List<Reservation> reservations = getReservations(_context, timeslot);
            List<TableReservation> tablesReserved = reservations.SelectMany(d => d.TableReservations).ToList();
            List<Table> usedTables = tablesReserved.Select(d => d.Table).ToList();
            List<Table> alltables = _context.Tables.ToList();
            return alltables.Where(table => !usedTables.Contains(table)).ToList();
        }

        private static List<Reservation> getReservations(LiteDatabaseContext _context, TimeSlot timeslot)
        {
            //Get reservations in the given timeslot
            List<Reservation> reservations = _context.Reservations
                .Include(x => x.TableReservations)
                .Where(res => res.ReservationTime.Date == timeslot.FullDate.Date)
                .ToList()
                //.Where(res => res.ReservationTime.Add(Constants.SlotSize) > timeslot.FullDate)
                //.Where(res => res.ReservationTime.Subtract(Constants.SlotSize) > timeslot.FullDate && res.ReservationTime.Add(Constants.SlotSize) > timeslot.FullDate)
                .Where(res => res.ReservationTime > timeslot.FullDate.Subtract(Constants.SlotSize) && res.ReservationTime < timeslot.FullDate.Add(Constants.SlotSize))
                .ToList();
            return reservations;
        }

        public static int getTableCount(LiteDatabaseContext _context)
        {
            return _context.Tables.Count();
        }

        public static List<Reservation> getAllReservations(LiteDatabaseContext _context)
        {
            List<Reservation> reservations = _context.Reservations.ToList();
            return reservations;
        }

        public static void removeById(LiteDatabaseContext _context, string id)
        {
            Reservation reservation = _context.Reservations.SingleOrDefault(e => e.ReservationId == id);
            _context.Reservations.Remove(reservation);
            _context.SaveChanges();
        }
    }
}
