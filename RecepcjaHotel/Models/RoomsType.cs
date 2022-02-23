using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace RecepcjaHotel.Models
{
    public partial class RoomsType
    {
        public RoomsType()
        {
            Rooms = new HashSet<Room>();
        }

        public int Id { get; set; }

        [DisplayName("Rodzaj Pokoju")]
        [Required(ErrorMessage = "Pole Rodzaj Pokoju jest wymagane.")]
        [MaxLength(50)]
        public string Name { get; set; }

        [DisplayName("Rozmiar")]
        [Required(ErrorMessage = "Pole Rozmiar jest wymagane.")]
        public decimal Size { get; set; }

        [DisplayName("Cena")]
        [Required(ErrorMessage = "Pole Cena jest wymagane.")]
        public decimal Price { get; set; }

        [DisplayName("Opis")]
        [MaxLength(4000)]
        public string Description { get; set; }

        public virtual ICollection<Room> Rooms { get; set; }
    }
}
