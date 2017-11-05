﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BankOfBIT.Models;

namespace BankOfBIT.Controllers
{
    public class ChequingAccountController : Controller
    {
        private BankOfBITContext db = new BankOfBITContext();

        //
        // GET: /ChequingAccount/

        public ActionResult Index()
        {
            var bankaccounts = db.ChequingAccounts.Include(c => c.AccountState).Include(c => c.Client);
            return View(bankaccounts.ToList());
        }

        //
        // GET: /ChequingAccount/Details/5

        public ActionResult Details(int id = 0)
        {
            ChequingAccount chequingaccount = db.ChequingAccounts.Find(id);
            if (chequingaccount == null)
            {
                return HttpNotFound();
            }
            return View(chequingaccount);
        }

        //
        // GET: /ChequingAccount/Create

        public ActionResult Create()
        {
            ViewBag.AccountStateId = new SelectList(db.AccountStates, "AccountStateId", "Description");
            ViewBag.ClientId = new SelectList(db.Clients, "ClientId", "FullName");
            return View();
        }

        //
        // POST: /ChequingAccount/Create

        [HttpPost]
        public ActionResult Create(ChequingAccount chequingaccount)
        {
            //this code has been modified
            if (ModelState.IsValid)
            {
                //Setting the chequing account number to the next available one when creating a new chequing account
                chequingaccount.SetNextAccountNumber();
                db.BankAccounts.Add(chequingaccount);
                chequingaccount.ChangeState();
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AccountStateId = new SelectList(db.AccountStates, "AccountStateId", "Description", chequingaccount.AccountStateId);
            ViewBag.ClientId = new SelectList(db.Clients, "ClientId", "FullName", chequingaccount.ClientId);
            return View(chequingaccount);
        }

        //
        // GET: /ChequingAccount/Edit/5

        public ActionResult Edit(int id = 0)
        {
            ChequingAccount chequingaccount = db.ChequingAccounts.Find(id);
            if (chequingaccount == null)
            {
                return HttpNotFound();
            }
            ViewBag.AccountStateId = new SelectList(db.AccountStates, "AccountStateId", "Description", chequingaccount.AccountStateId);
            ViewBag.ClientId = new SelectList(db.Clients, "ClientId", "FirstName", chequingaccount.ClientId);
            return View(chequingaccount);
        }

        //
        // POST: /ChequingAccount/Edit/5

        [HttpPost]
        public ActionResult Edit(ChequingAccount chequingaccount)
        {
            if (ModelState.IsValid)
            {
                db.Entry(chequingaccount).State = EntityState.Modified;
                chequingaccount.ChangeState();
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AccountStateId = new SelectList(db.AccountStates, "AccountStateId", "Description", chequingaccount.AccountStateId);
            ViewBag.ClientId = new SelectList(db.Clients, "ClientId", "FullName", chequingaccount.ClientId);
            return View(chequingaccount);
        }

        //
        // GET: /ChequingAccount/Delete/5

        public ActionResult Delete(int id = 0)
        {
            ChequingAccount chequingaccount = db.ChequingAccounts.Find(id);
            if (chequingaccount == null)
            {
                return HttpNotFound();
            }
            return View(chequingaccount);
        }

        //
        // POST: /ChequingAccount/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            ChequingAccount chequingaccount = db.ChequingAccounts.Find(id);
            db.BankAccounts.Remove(chequingaccount);
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