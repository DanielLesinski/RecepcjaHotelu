using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RecepcjaHotelu.Models
{
    [Table("RoomsType")]
    public class RoomsTypeModel
    {
        [Key]
        public int ID { get; set; }
        
        [DisplayName("Nazwa")]
        [Required(ErrorMessage = "Pole Nazwa jest wymagane.")]
        [MaxLength(50)]
        public string Name { get; set; }

        [DisplayName("Rozmiar")]
        [Required(ErrorMessage = "Pole Rozmiar jest wymagane.")]
        public decimal Size { get; set; }

        [DisplayName("Cena za dobe")]
        [Required(ErrorMessage = "Pole Cena za dobe jest wymagane.")]
        public decimal Price { get; set; }

        [DisplayName("Opis")]
        [MaxLength(4000)]
        public string Description { get; set; }
    }
}
