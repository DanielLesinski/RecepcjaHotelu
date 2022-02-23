using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace RecepcjaHotel.Models
{
    public partial class Client
    {
        public Client()
        {
            Reservations = new HashSet<Reservation>();
        }

        [DisplayName("Klient")]
        public int Id { get; set; }

        [DisplayName("Imię")]
        [MaxLength(20)]
        [Required(ErrorMessage = "Pole Imię jest wymagane")]
        public string Name { get; set; }

        [DisplayName("Nazwisko")]
        [MaxLength(20)]
        [Required(ErrorMessage = "Pole Nazwisko jest wymagane")]
        public string Surname { get; set; }

        [DisplayName("Numer telefonu")]
        [MaxLength(12)]
        [MinLength(9, ErrorMessage = "Proszę podać poprawny numer telefonu")]
        [RegularExpression(@"^[0-9+]*", ErrorMessage = "Proszę podać poprawny numer telefonu np." +
            " +48456234456 lub 456234456")]
        public string PhoneNumber { get; set; }

        [DisplayName("E-mail")]
        [Required(ErrorMessage = "Pole E-mail jest wymagane.")]
        [MaxLength(255)]
        [RegularExpression(@"^[a-zA-z][a-zA-z0-9_]*@[A-Za-z0-9]*\.[A-za-z]{2,3}$",
            ErrorMessage = "Proszę podać prawidłowy adres e-mail.")]
        public string Email { get; set; }

        public virtual ICollection<Reservation> Reservations { get; set; }
    }
}
