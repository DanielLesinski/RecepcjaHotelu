using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecepcjaHotel.Repo
{
    using Microsoft.EntityFrameworkCore;
    using RecepcjaHotel.Models;
    public class RepoClient
    {
        private readonly RecepcjaDBContext db;
        public RepoClient(RecepcjaDBContext db)
        {
            this.db = db;
        }

        public Client Get(int id) => db.Clients.Include(o => o.Reservations).SingleOrDefault(o => o.Id == id);

        public IQueryable<Client> GetAll => db.Clients;

        public void Add(Client clients)
        {
            db.Clients.Add(clients);
            db.SaveChanges();
        }

        public bool Update(int id, Client client)
        {
            var result = db.Clients.Include(o => o.Reservations).SingleOrDefault(o => o.Id == id);
            if (result != null && result.Reservations.Count == 0)
            {
                result.Name = client.Name;
                result.Surname = client.Surname;
                result.PhoneNumber = client.PhoneNumber;
                result.Email = client.Email;
                db.SaveChanges();
                return true;
            }
            return false;

        }

        public bool Delete(int id)
        {
            var result = db.Clients.Include(o => o.Reservations).SingleOrDefault(o => o.Id == id);
            if (result != null && result.Reservations.Count == 0)
            {
                db.Clients.Remove(result);
                db.SaveChanges();
                return true;
            }
            return false;
        }
    }
}

