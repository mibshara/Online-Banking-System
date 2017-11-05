using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BankOfBIT.Models;

namespace BankOfBIT.Controllers
{
    public class InvestmentAccountController : Controller
    {
        private BankOfBITContext db = new BankOfBITContext();

        //
        // GET: /InvestmentAccount/

        public ActionResult Index()
        {
            var bankaccounts = db.InvestmentAccounts.Include(i => i.AccountState).Include(i => i.Client);
            return View(bankaccounts.ToList());
        }

        //
        // GET: /InvestmentAccount/Details/5

        public ActionResult Details(int id = 0)
        {
            InvestmentAccount investmentaccount = db.InvestmentAccounts.Find(id);
            if (investmentaccount == null)
            {
                return HttpNotFound();
            }
            return View(investmentaccount);
        }

        //
        // GET: /InvestmentAccount/Create

        public ActionResult Create()
        {
            ViewBag.AccountStateId = new SelectList(db.AccountStates, "AccountStateId", "Description");
            ViewBag.ClientId = new SelectList(db.Clients, "ClientId", "FullName");
            return View();
        }

        //
        // POST: /InvestmentAccount/Create

        [HttpPost]
        public ActionResult Create(InvestmentAccount investmentaccount)
        {
            //This code has been modified
            if (ModelState.IsValid)
            {
                //Setting the investment account number to the next available one when creating a new investment account
                investmentaccount.SetNextAccountNumber();
                db.BankAccounts.Add(investmentaccount);
                investmentaccount.ChangeState();
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AccountStateId = new SelectList(db.AccountStates, "AccountStateId", "Description", investmentaccount.AccountStateId);
            ViewBag.ClientId = new SelectList(db.Clients, "ClientId", "FullName", investmentaccount.ClientId);
            return View(investmentaccount);
        }

        //
        // GET: /InvestmentAccount/Edit/5

        public ActionResult Edit(int id = 0)
        {
            InvestmentAccount investmentaccount = db.InvestmentAccounts.Find(id);
            if (investmentaccount == null)
            {
                return HttpNotFound();
            }
            ViewBag.AccountStateId = new SelectList(db.AccountStates, "AccountStateId", "Description", investmentaccount.AccountStateId);
            ViewBag.ClientId = new SelectList(db.Clients, "ClientId", "FullName", investmentaccount.ClientId);
            return View(investmentaccount);
        }

        //
        // POST: /InvestmentAccount/Edit/5

        [HttpPost]
        public ActionResult Edit(InvestmentAccount investmentaccount)
        {
            if (ModelState.IsValid)
            {
                db.Entry(investmentaccount).State = EntityState.Modified;
                investmentaccount.ChangeState();
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AccountStateId = new SelectList(db.AccountStates, "AccountStateId", "Description", investmentaccount.AccountStateId);
            ViewBag.ClientId = new SelectList(db.Clients, "ClientId", "FullName", investmentaccount.ClientId);
            return View(investmentaccount);
        }

        //
        // GET: /InvestmentAccount/Delete/5

        public ActionResult Delete(int id = 0)
        {
            InvestmentAccount investmentaccount = db.InvestmentAccounts.Find(id);
            if (investmentaccount == null)
            {
                return HttpNotFound();
            }
            return View(investmentaccount);
        }

        //
        // POST: /InvestmentAccount/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            InvestmentAccount investmentaccount = db.InvestmentAccounts.Find(id);
            db.BankAccounts.Remove(investmentaccount);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}