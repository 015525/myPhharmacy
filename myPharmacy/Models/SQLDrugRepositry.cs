using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace myPharmacy.Models
{
    public class SQLDrugRepositry : IdrugRepository
    {
        private ApplicationDbContext _db;
        public SQLDrugRepositry(ApplicationDbContext db)
        {
            _db = db;      
        }
        public drug Add(drug drug)
        {
            _db.drugs.Add(drug);
            _db.SaveChanges();
            return drug;
        }

        public drug Delete(int id)
        {
            drug d = _db.drugs.Find(id);
            if (d != null)
            {
                _db.drugs.Remove(d);
                _db.SaveChanges();
            }
            return d;
        }

        public IEnumerable<drug> GetAllDrugs()
        {
            return _db.drugs;
        }

        public drug get_drug(int id)
        {
            return _db.drugs.Find(id);
        }

        public drug Update(drug new_drug)
        {
            var d = _db.drugs.Attach(new_drug);
            d.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _db.SaveChanges();
            return new_drug;
        }
    }
}
