using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace myPharmacy.Models
{
    public class MochDrugRepositry : IdrugRepository
    {
        private List<drug> _drugList;

        public MochDrugRepositry()
        {
            _drugList = new List<drug>();
        }
        public drug Add(drug drug)
        {
            drug.drug_id = _drugList.Max(u => u.drug_id) + 1;
            _drugList.Add(drug);
            return drug;
        }

        public drug Delete(int id)
        {
            drug d = _drugList.FirstOrDefault(u => u.drug_id == id);
            if (d != null)
            {
                _drugList.Remove(d);
            }
            return d;
        }

        public IEnumerable<drug> GetAllDrugs()
        {
            return _drugList;
        }

        public ApplicationDbContext GetDatabase()
        {
            throw new NotImplementedException();
        }

        public drug get_drug(int id)
        {
            return _drugList.FirstOrDefault(u => u.drug_id == id);
        }

        public drug Update(drug new_drug)
        {
            drug d = _drugList.FirstOrDefault(u => u.drug_id == new_drug.drug_id);
            if (d != null)
            {
                d.drug_name = new_drug.drug_name;
                
            }
            return new_drug;
        }
    }
}
