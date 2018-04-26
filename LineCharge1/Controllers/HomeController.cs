using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using LineCharge1.Data;
using LineCharge1.Models;
using LineCharge1.ViewModel;

namespace LineCharge1.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Home
        public ActionResult Index()
        {
            var charges = db.Charges;

            var viewModel = new HomeViewModel
            {
                ChargeTypes = db.ChargeTypes.ToList(),
                Charges = charges.Include(c => c.ChargeType),
                ChargeTotal = GetChargeTotal(),
                Totals = GetTotalsByType()
            };

            return View(viewModel);
        }

        // POST: Home/Index
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(HomeViewModel vm)
        {
            if (ModelState.IsValid)
            {
                var chargeType = db.ChargeTypes.Where(i => i.ChargeTypeID == vm.ChargeTypeID).Single();
                var charge = new Charge
                {
                    Amount = chargeType.Type == "Deposit" ? (double)vm.Amount : ((double)vm.Amount) * -1,
                    ChargeTypeID = vm.ChargeTypeID,
                    TransactionDate = DateTime.Now
                };

                db.Charges.Add(charge);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            vm.ChargeTypes = db.ChargeTypes.ToList();
            vm.Charges = db.Charges.Include(c => c.ChargeType);
            vm.ChargeTotal = GetChargeTotal();
            vm.Totals = GetTotalsByType();

            return View(vm);
        }

        [NonAction]
        private Double GetChargeTotal()
        {
            Double? total = (from item in db.Charges
                             select (Double?) item.Amount).Sum();

            return total ?? 0;
        }

        [NonAction]
        private IEnumerable<ChargeTotal> GetTotalsByType()
        {
            IEnumerable<ChargeTotal> query = from charge in db.Charges
                                            join chargeType in db.ChargeTypes on charge.ChargeTypeID equals chargeType.ChargeTypeID
                                            group charge by chargeType.Type into itemGroup
                                            select new ChargeTotal
                                            {
                                                Type = itemGroup.Key,
                                                Amount = itemGroup.Sum(x => x.Amount >= 0 ? x.Amount : x.Amount * -1)
                                            };

            return query.OrderByDescending(i => i.Amount);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
