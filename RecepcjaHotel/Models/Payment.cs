using System;
using System.Collections.Generic;
using System.ComponentModel;

#nullable disable

namespace RecepcjaHotel.Models
{
    public partial class Payment
    {
        public Payment()
        {
            Reservations = new HashSet<Reservation>();
        }

        public int Id { get; set; }

        [DisplayName("Metoda zapłaty")]
        public string Name { get; set; }

        public virtual ICollection<Reservation> Reservations { get; set; }
    }
}
