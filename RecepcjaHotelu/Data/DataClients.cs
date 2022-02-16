using RecepcjaHotelu.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecepcjaHotelu.Data
{
    public class DataClients
    {
        private readonly DataContext db;
        public DataClients(DataContext db)
        {
            this.db = db;
        }

        public ClientsModel Get(int id) => db.Clients.SingleOrDefault(o => o.ID == id);

        public IQueryable<ClientsModel> GetAll => db.Clients;

        public void Add(ClientsModel clients)
        {
            db.Clients.Add(clients);
            db.SaveChanges();
        }

        public void Update(int id, ClientsModel clients)
        {
            var result = db.Clients.SingleOrDefault(o => o.ID == id);
            if (result != null)
            {
                result.Name = clients.Name;
                result.Surname = clients.Surname;
                result.PhoneNumber = clients.PhoneNumber;
                result.Email = clients.Email;
                db.SaveChanges();
            }

        }

        public void Delete(int id)
        {
            var result = db.Clients.SingleOrDefault(o => o.ID == id);
            if (result != null)
            {
                db.Clients.Remove(result);
                db.SaveChanges();
            }
        }
    }
}
