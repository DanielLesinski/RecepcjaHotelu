using System;
using System.Collections.Generic;
using System.ComponentModel;

#nullable disable

namespace RecepcjaHotel.Models
{
    public partial class Room
    {
        public Room()
        {
            Reservations = new HashSet<Reservation>();
        }

        [DisplayName("Numer Pokoju")]
        public int Id { get; set; }
        public int RoomsTypeId { get; set; }

        public virtual RoomsType RoomsType { get; set; }
        public virtual ICollection<Reservation> Reservations { get; set; }
    }
}
