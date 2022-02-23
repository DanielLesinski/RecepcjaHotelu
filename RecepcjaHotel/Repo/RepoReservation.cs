using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecepcjaHotel.Repo
{
    using Microsoft.EntityFrameworkCore;
    using RecepcjaHotel.Models;

    public class RepoReservation
    {
        private readonly RecepcjaDBContext db;
        public RepoReservation(RecepcjaDBContext db)
        {
            this.db = db;
        }

        public Reservation Get(int id) =>
            db.Reservations.Include(o => o.Clients).Include(o => o.Rooms).Include(o => o.Payments).SingleOrDefault(o => o.Id == id);

        public IQueryable<Reservation> GetAll => db.Reservations;

        public bool Add(Reservation reservation)
        {
            if (DateTime.Compare(reservation.DateCheckIn, DateTime.Now) < 0)
                return false;

            if(reservation.DateCheckOut.HasValue)
            {
                if (DateTime.Compare(reservation.DateCheckIn, (DateTime)reservation.DateCheckOut) > 0)
                    return false;
            }
           
            if (check(reservation.DateCheckIn, reservation.DateCheckOut, reservation.RoomsId, reservation.Id))
                return false;
            
            if(reservation.DateCheckOut.HasValue)
            {
                DateTime date = (DateTime)reservation.DateCheckOut;
                reservation.Amount = addAmount(date, reservation.DateCheckIn, reservation.RoomsId);
            }
            db.Reservations.Add(reservation);
            db.SaveChanges();
            return true;
        }

        public bool Update(int id, Reservation reservation)
        {
            if (DateTime.Compare(reservation.DateCheckIn, DateTime.Now) < 0)
                return false;

            if (reservation.DateCheckOut.HasValue)
            {
                if (DateTime.Compare(reservation.DateCheckIn, (DateTime)reservation.DateCheckOut) > 0)
                    return false;
            }

            if (check(reservation.DateCheckIn, reservation.DateCheckOut, reservation.RoomsId, reservation.Id))
                return false;

            var result = db.Reservations.SingleOrDefault(o => o.Id == id);
            if (result != null)
            {
                result.DateCheckIn = reservation.DateCheckIn;
                result.DateCheckOut = reservation.DateCheckOut;
                if (reservation.DateCheckOut.HasValue)
                {
                    DateTime date = (DateTime)reservation.DateCheckOut;
                    reservation.Amount = addAmount(date, reservation.DateCheckIn, reservation.RoomsId);
                }
                result.Amount = reservation.Amount;
                result.ClientsId = reservation.ClientsId;
                result.RoomsId = reservation.RoomsId;
                result.PaymentsId = reservation.PaymentsId;
                db.SaveChanges();
            }
            return true;
        }

        private bool check(DateTime timeIn, DateTime? timeOut, int id, int idRezerwacji)
        {
            Room room = db.Rooms.Include(o => o.Reservations).SingleOrDefault(o => o.Id == id);
            IEnumerable<Reservation> reservations = room.Reservations.Where(o => o.Id != idRezerwacji);

            if(!timeOut.HasValue)
            {
                foreach (Reservation item in reservations)
                {
                    if (item.DateCheckOut.HasValue)
                    {
                        if (DateTime.Compare(timeIn, (DateTime)item.DateCheckOut) > 0)
                            continue;
                        return true;
                    }
                    return true;
                }
            }
            
            foreach(Reservation item in reservations)
            {
                if(item.DateCheckOut.HasValue)
                {
                    if (DateTime.Compare(timeIn, (DateTime)item.DateCheckOut) > 0)
                        continue;
                    if (DateTime.Compare((DateTime)timeOut, item.DateCheckIn) < 0)
                        continue;
                    return true;
                }
                if (DateTime.Compare((DateTime)timeOut, item.DateCheckIn) < 0)
                    continue;
                return true;
            }
            return false;
        }

        private decimal addAmount(DateTime timeIn, DateTime timeOut, int RoomsID)
        {
            int days = (timeIn.Date - timeOut.Date).Days + 1;
            int id = RoomsID;
            decimal amount = db.Rooms.Include(o => o.RoomsType).SingleOrDefault(o => o.Id == id).RoomsType.Price;
            return amount * days;
        }

        public void Delete(int id)
        {
            var result = db.Reservations.SingleOrDefault(o => o.Id == id);
            if (result != null)
            {
                db.Reservations.Remove(result);
                db.SaveChanges();
            }
        }
    }
}
