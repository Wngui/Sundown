using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Sundown.Models
{
    public class LiteDatabaseContext : DbContext
    {
        public DbSet<Table> Tables { get; set; }
        public DbSet<Reservation> Reservations { get; set; }

        public LiteDatabaseContext()
        {
        }

        /*protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite($"Filename=Sundown.db");
        }*/

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Filename=sundown.db", options =>
            {
                options.MigrationsAssembly(Assembly.GetExecutingAssembly().FullName);
            });

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TableReservation>()
                .HasKey(bc => new { bc.TableId, bc.ReservationId });

            modelBuilder.Entity<TableReservation>()
                .HasOne(bc => bc.Table)
                .WithMany(b => b.TableReservations)
                .HasForeignKey(bc => bc.TableId);

            modelBuilder.Entity<TableReservation>()
                .HasOne(bc => bc.Reservation)
                .WithMany(c => c.TableReservations)
                .HasForeignKey(bc => bc.ReservationId);

            for (int i = 0; i < 10; i++)
            {
                Table table = new Table();
                table.TableId = Guid.NewGuid().ToString();
                modelBuilder.Entity<Table>().HasData(table);
            }
        }

    }
}
