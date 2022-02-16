using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RecepcjaHotelu.Models
{
    [Table("Rooms")]
    public class RoomsModel
    {
        [Key]
        [DisplayName("NumerPokoju")]
        public int ID { get; set; }

        public int ID_RoomType { get; set; }
    }
}
