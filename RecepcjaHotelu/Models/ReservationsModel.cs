using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecepcjaHotelu.Models
{
    public class ReservationsModel
    {
        public int ID { get; set; }
        public string Date_CheckIn { get; set; }
        public string Date_CheckOut { get; set; }
        public decimal Amount { get; set; }
        public int ID_Client { get; set; }
        public int ID_Room { get; set; }
        public int ID_Payment { get; set; }
    }
}
