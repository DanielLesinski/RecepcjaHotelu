using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecepcjaHotel.Repo
{
    using Microsoft.EntityFrameworkCore;
    using RecepcjaHotel.Models;

    public class RepoRoom
    {
        private readonly RecepcjaDBContext db;
        public RepoRoom(RecepcjaDBContext db)
        {
            this.db = db;
        }

        public Room Get(int id) => db.Rooms.Include(o => o.RoomsType).Include(o => o.Reservations).SingleOrDefault(o => o.Id == id);

        public IQueryable<Room> GetAll => db.Rooms.Include(o => o.RoomsType);

        public void Add(Room room)
        {
            db.Rooms.Add(room);
            db.SaveChanges();
        }

        public bool Update(int id, Room room)
        {
            var result = db.Rooms.Include(o => o.Reservations).SingleOrDefault(o => o.Id == id);
            if (result != null && result.Reservations.Count == 0)
            {
                result.RoomsTypeId = room.RoomsTypeId; 
                db.SaveChanges();
                return true;
            }
            return false;

        }

        public bool Delete(int id)
        {
            var result = db.Rooms.Include(o => o.Reservations).SingleOrDefault(o => o.Id == id);
            if (result != null && result.Reservations.Count == 0)
            {
                db.Rooms.Remove(result);
                db.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
