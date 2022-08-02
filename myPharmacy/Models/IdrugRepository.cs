using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace myPharmacy.Models
{
    public interface IdrugRepository
    {
        drug get_drug(int id);
        //IEnumerable<drug> GetAllDrugs();
        drug Add(drug drug);
        drug Update(drug new_drug);
        drug Delete(int id);
        IEnumerable<drug> GetAllDrugs();
    }
}
