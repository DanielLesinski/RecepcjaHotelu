using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecepcjaHotel.Repo
{
    using RecepcjaHotel.Models;
    public class RepoPayment
    {
        private readonly RecepcjaDBContext db;
        public RepoPayment(RecepcjaDBContext db)
        {
            this.db = db;
        }

        public IQueryable<Payment> GetAll => db.Payments;
    }
}
