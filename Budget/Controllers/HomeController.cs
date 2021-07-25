using Budget.Models;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Budget.Controllers
{
    public class HomeController : Controller
    {
        private BudgetDbContext _context;

        public HomeController()
        {
            _context = new BudgetDbContext();
        }

        public ActionResult Categories()
        {
            return View(_context.Categories.ToList());
        }
        public ActionResult AddCategory()
        {
            return View();   
        }

        [HttpPost]
        public ActionResult AddCategory(Category c)
        {
            _context.Categories.Add(c);
            _context.SaveChanges();
            return View("Index");
        }
        public ActionResult EditCategory(int id)
        {
            return View(_context.Categories.SingleOrDefault(c=>c.ID==id));
        }
        [HttpPost]
        public ActionResult EditCategory(Category category)
        {
            Category cat = _context.Categories.SingleOrDefault(c => c.ID == category.ID);
            cat.Description = category.Description;
            _context.SaveChanges();
            return RedirectToAction("Categories");
        }
        public ActionResult DeleteCategory(int id)
        {
            Category cat = _context.Categories.SingleOrDefault(c => c.ID == id);
            _context.Categories.Remove(cat);
            _context.SaveChanges();

            return RedirectToAction("Categories");
        }

        public ActionResult AddExpense()
        {
            ViewBag.Categories = _context.Categories.ToList();
            return View();
        }
        [HttpPost]
        public ActionResult AddExpense(Expense exp,FormCollection fc)
        {
            int id = Convert.ToInt32(fc["category"].ToString());
            exp.Category =_context.Categories.SingleOrDefault(c=>c.ID ==id );
            _context.Expenses.Add(exp);
            _context.SaveChanges();

            return RedirectToAction("Expenses");
        }
        public ActionResult Expenses()
        {
            var data = _context.Expenses.Include("Category").ToList();
            return View(data);
        }
        public ActionResult EditExpense(int id)
        {
            var data = _context.Expenses.Include("Category").SingleOrDefault(e => e.ID == id);
            ViewBag.Categories = _context.Categories.ToList();
            return View(data);
        }
        [HttpPost]
        public ActionResult EditExpense(Expense expense, FormCollection fc)
        {
            int id = Convert.ToInt32(fc["category"].ToString());

            Expense exp = _context.Expenses.SingleOrDefault(e=>e.ID==expense.ID);
            exp.Amount = expense.Amount;
            exp.Description = expense.Description;
            exp.Date = expense.Date;
            exp.Category = _context.Categories.SingleOrDefault(c => c.ID == id);

            _context.SaveChanges();

            return RedirectToAction("Expenses");
        }
        public ActionResult DeleteExpense(int id)
        {
            Expense exp = _context.Expenses.SingleOrDefault(e => e.ID == id);
            _context.Expenses.Remove(exp);
            _context.SaveChanges();
            return RedirectToAction("Expenses");

        }

    }

}