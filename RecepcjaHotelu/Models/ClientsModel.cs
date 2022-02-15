using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecepcjaHotelu.Models
{
    public class ClientsModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
    }
}
