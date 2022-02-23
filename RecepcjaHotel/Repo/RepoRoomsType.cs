using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecepcjaHotel.Repo
{
    using Microsoft.EntityFrameworkCore;
    using RecepcjaHotel.Models;
    public class RepoRoomsType
    {
        private readonly RecepcjaDBContext db;
        public RepoRoomsType(RecepcjaDBContext db)
        {
            this.db = db;
        }
        public RoomsType Get(int id) => db.RoomsTypes.Include(o => o.Rooms).SingleOrDefault(o => o.Id == id);

        public IQueryable<RoomsType> GetAll => db.RoomsTypes;

        public void Add(RoomsType roomsType)
        {
            db.RoomsTypes.Add(roomsType);
            db.SaveChanges();
        }

        public bool Update(int id, RoomsType roomsType)
        {
            var result = db.RoomsTypes.Include(o => o.Rooms).SingleOrDefault(o => o.Id == id);
            if (result != null && result.Rooms.Count == 0)
            {
                result.Name = roomsType.Name;
                result.Size = roomsType.Size;
                result.Price = roomsType.Price;
                result.Description = roomsType.Description;
                db.SaveChanges();
                return true;
            }
            return false;

        }

        public bool Delete(int id)
        {
            var result = db.RoomsTypes.Include(o => o.Rooms).SingleOrDefault(o => o.Id == id);
            if (result != null && result.Rooms.Count == 0)
            {
                db.RoomsTypes.Remove(result);
                db.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
