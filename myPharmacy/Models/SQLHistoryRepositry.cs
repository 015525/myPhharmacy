
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace myPharmacy.Models
{
    public class SQLHistoryRepositry : IHistoryRepositry
    {
        private ApplicationDbContext _db;
        public SQLHistoryRepositry(ApplicationDbContext db)
        {
            _db = db;
        }
        public historyy Add(historyy history)
        {
            _db.history.Add(history);
            _db.SaveChanges();
            return history;
        }

        public historyy Delete(int id)
        {
            historyy d = _db.history.Find(id);
            if (d != null)
            {
                _db.history.Remove(d);
                _db.SaveChanges();
            }
            return d;
        }

        public IEnumerable<historyy> GetAllHiss()
        {
            return _db.history;
        }

        public historyy get_history(int id)
        {
            return _db.history.Find(id);
        }

        public historyy Update(historyy new_history)
        {
            var d = _db.history.Attach(new_history);
            d.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _db.SaveChanges();
            return new_history;
        }
    }
}
