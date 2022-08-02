using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using myPharmacy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace myPharmacy.Controllers
{
    public class HistoryController : Controller
    {
        private readonly IHistoryRepositry _hisRepo;

        [BindProperty]
        private historyy history { get; set; }

        public HistoryController(IHistoryRepositry hisRepo)
        {
            _hisRepo = hisRepo;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult bind_drug_id()
        {
            return View();
        }


        public IActionResult Upsert(int? id)
        {
            var drug_list = _hisRepo.GetAllHiss();
            SelectList select = new SelectList(drug_list, "drug_id", "drug_name");
            ViewBag.drugNameList = select;
            history = new historyy();
            if (id == null)
            {
                //create
                return View(history);
            }
            //update
            history = _hisRepo.get_history(id ?? 1);
            if (history == null)
            {
                return NotFound();
            }
            return View(history);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult Upsert(historyy history)
        {
            Console.WriteLine("i out of if");
            if (ModelState.IsValid)
            {
                if (history.his_id == null)
                {
                    var drug = _hisRepo.get_history(history.drug_id);
                    history.drug_name = drug.drug_name;
                    var date1 = DateTime.Today;
                    var date2 = history.expirey_date;
                    if (date2 < date1)
                    {
                        history.expired = true;
                    }else
                    {
                        history.expired = false;
                    }
                    var quant = history.quantity;
                    if (quant == 0)
                    {
                        history.finished = true;
                    }else
                    {
                        history.finished = false;
                    }

                    _hisRepo.Add(history);
                }else
                {
                    var drug = _hisRepo.get_history(history.drug_id);
                    history.drug_name = drug.drug_name;
                    Console.WriteLine("iam in else");
                    var date1 = DateTime.Today;
                    var date2 = history.expirey_date;
                    if (date2 < date1)
                    {
                        history.expired = true;
                    }
                    else
                    {
                        history.expired = false;
                    }
                    var quant = history.quantity;
                    if (quant == 0)
                    {
                        history.finished = true;
                    }
                    else
                    {
                        history.finished = false;
                    }
                    _hisRepo.Update(history);
                }
                return RedirectToAction("Index");
            }
            return View(history);
        }

        #region Api Call
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Json(new { data = _hisRepo.GetAllHiss().ToList() });
        }
        /*
        public async Task<IActionResult> GatAll()
        {
            Console.WriteLine("iam here");
            return Json(new { data = await _db.history.ToListAsync() });
        }*/

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var drug = _hisRepo.Delete(id);
            if (drug == null)
            {
                return Json(new { success = false, message = "Error while deleting" });
            }
            return Json(new { success = true, message = "history deleted successfully" });
        }
        #endregion
    }
}
