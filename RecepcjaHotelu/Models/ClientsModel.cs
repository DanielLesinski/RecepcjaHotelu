using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RecepcjaHotelu.Models
{
    [Table("Clients")]
    public class ClientsModel
    {
        [Key]
        public int ID { get; set; }

        [DisplayName("Imie")]
        [Required(ErrorMessage = "Pole Imie jest wymagane.")]
        [MaxLength(20)]
        public string Name { get; set; }

        [DisplayName("Nazwisko")]
        [Required(ErrorMessage = "Pole Nazwisko jest wymagane.")]
        [MaxLength(20)]
        public string Surname { get; set; }

        [DisplayName("Numer telefonu")]
        [Required(ErrorMessage = "Pole Numer telefonu jest wymagane.")]
        [MaxLength(12)]
        [MinLength(9,ErrorMessage = "Conajmniej 9 znaków.")]
        [RegularExpression(@"^[0-9+]*", ErrorMessage = "Proszę podać poprawny numer telefonu np." +
            " +48456234456 lub 456234456")]
        public string PhoneNumber { get; set; }

        [DisplayName("E-mail")]
        [Required(ErrorMessage = "Pole E-mail jest wymagane.")]
        [MaxLength(255)]
        [RegularExpression(@"^[a-zA-z][a-zA-z0-9_]*@[A-Za-z0-9]*\.[A-za-z]{2,3}$",
            ErrorMessage ="Proszę podać prawidłowy adres e-mail.")]
        public string Email { get; set; }
    }
}
