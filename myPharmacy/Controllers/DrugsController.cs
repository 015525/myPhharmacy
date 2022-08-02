using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using myPharmacy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Helpers;

namespace myPharmacy.Controllers
{
    public class DrugsController : Controller
    {
        private readonly IdrugRepository _drug_repo;

        [BindProperty]
        private drug drug { get; set; }

        public DrugsController(IdrugRepository drug_repo)
        {
            _drug_repo = drug_repo;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Upsert(int? id)
        {
            drug = new drug();
            if (id == null)
            {
                //create
                return View(drug);
            }
            var my_id = id;
            //update
            drug = _drug_repo.get_drug(id ?? 1);
            if (drug == null)
            {
                return NotFound();
            }
            return View(drug);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(drug drug)
        {
            if (ModelState.IsValid)
            {
                if (drug.drug_id == null)
                {
                    _drug_repo.Add(drug);
                }else
                {
                    _drug_repo.Update(drug);
                }
                return RedirectToAction("Index");
            }
            return View(drug);
        }

        #region API Calls
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            //IEnumerable < drug > = _drug_repo.GetAllDrugs();
            return Json(new { data =  _drug_repo.GetAllDrugs().ToList() });
        }


        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var drug = _drug_repo.Delete(id);
            if (drug == null)
            {
                return Json(new { success = false, message = "Error while Deleting" });
            }
            return Json(new { success = true, message = "Delete successfull" });
        }
        #endregion
    }
}
