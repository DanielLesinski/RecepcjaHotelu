using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace RecepcjaHotel.Models
{
    public partial class Reservation
    {
        [DisplayName("Numer Rezerwacji")]
        public int Id { get; set; }

        [DisplayName("Data zameldowania")]
        [Range(typeof(DateTime), "1/1/2021", "1/1/2025")]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DateCheckIn { get; set; }

        [DisplayName("Data wymeldowania")]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? DateCheckOut { get; set; }

        [DisplayName("Koszt pobytu")]
        public decimal? Amount { get; set; }
        public int ClientsId { get; set; }
        public int RoomsId { get; set; }
        public int PaymentsId { get; set; }

        public virtual Client Clients { get; set; }
        public virtual Payment Payments { get; set; }
        public virtual Room Rooms { get; set; }
    }
}
