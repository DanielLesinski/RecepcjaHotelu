using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecepcjaHotelu.Data
{
    using RecepcjaHotelu.Models;
    public class DataRoomsType
    {
        private readonly DataContext db;
        public DataRoomsType(DataContext db)
        {
            this.db = db;
        }

        public RoomsTypeModel Get(int id) => db.RoomsType.SingleOrDefault(o => o.ID == id);

        public IQueryable<RoomsTypeModel> GetAll => db.RoomsType;

        public void Add(RoomsTypeModel roomsType)
        {
            db.RoomsType.Add(roomsType);
            db.SaveChanges();
        }

        public void Update(int id, RoomsTypeModel typeModel)
        {
            var result = db.RoomsType.SingleOrDefault(o => o.ID == id);
            if(result != null)
            {
                result.Name = typeModel.Name;
                result.Size = typeModel.Size;
                result.Price = typeModel.Price;
                result.Description = result.Description;
                db.SaveChanges();
            }
            
        }

        public void Delete(int id)
        {
            var result = db.RoomsType.SingleOrDefault(o => o.ID == id);
            if(result != null)
            {
                db.RoomsType.Remove(result);
                db.SaveChanges();
            }
        }
    }
}
