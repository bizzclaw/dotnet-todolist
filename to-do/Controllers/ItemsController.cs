using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ToDo.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ToDo.Controllers
{
    public class ItemsController : Controller
    {
		private ToDoListContext db = new ToDoListContext();

		public IActionResult Index()
        {
            List<Item> model = db.Items.ToList();
            return View(model);
        }

		public IActionResult Details(int id)
		{
			Item model = db.Items.FirstOrDefault(items => items.ItemId == id);
			return View(model);
		}

		public IActionResult Create()
		{
			return View();
		}

		[HttpPost]
		public IActionResult Create(Item item)
		{
			db.Items.Add(item);
			db.SaveChanges();
			return RedirectToAction("Index");
		}

		public IActionResult Edit(int id)
		{
			var model = db.Items.FirstOrDefault(items => items.ItemId == id);
			return View(model);
		}

		[HttpPost]
		public IActionResult Edit(Item item)
		{
			db.Entry(item).State = EntityState.Modified;
			db.SaveChanges();
			return RedirectToAction("Index");
		}

		public IActionResult Delete(int id)
		{
			var model = db.Items.FirstOrDefault(items => items.ItemId == id);
			return View(model);
		}

		[HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
		{
            var thisItem = db.Items.FirstOrDefault(items => items.ItemId == id);
            db.Items.Remove(thisItem);
            db.SaveChanges();
			return RedirectToAction("Index");
		}
	}
}
