using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace myPharmacy.Models
{
    public interface IHistoryRepositry
    {
        historyy get_history(int id);
        historyy Add(historyy history);
        historyy Update(historyy new_history);
        historyy Delete(int id);
        IEnumerable<historyy> GetAllHiss();
    }
}
