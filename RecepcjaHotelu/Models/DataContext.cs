using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecepcjaHotelu.Models
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options) { }

        public DbSet<RoomsTypeModel> RoomsType { get; set; }
        public DbSet<RoomsModel> Rooms { get; set; }
        public DbSet<PaymentsModel> Payments { get; set; }
        public DbSet<ClientsModel> Clients { get; set; }
        public DbSet<ReservationsModel> Reservations { get; set; }
    }
}
