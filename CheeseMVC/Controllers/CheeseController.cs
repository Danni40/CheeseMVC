using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CheeseMVC.Models.Cheese;
using Microsoft.AspNetCore.Mvc;

namespace CheeseMVC.Controllers
{
    public class CheeseController : Controller
    {
		private static List<Cheese> cheeses = new List<Cheese>();

		[HttpGet]
        public IActionResult Index()
        {
            return View(cheeses);
        }

		[HttpGet]
		public IActionResult Add() 
		{
			return View();
		}

		[HttpPost]
		public IActionResult Add(Cheese cheese) 
		{
			cheeses.Add(cheese);
			return Redirect("Index");
		}

		[HttpGet]
		public IActionResult CheckBoxDelete() 
		{
			var model = new CheckBoxDeleteViewModel(cheeses);
			return View(model);
		}

		[HttpPost]
		public IActionResult CheckBoxDelete(CheckBoxDeleteViewModel model) 
		{
			List<Cheese> cheesesToRemove = new List<Cheese>();
			foreach (Cheese cheese in cheeses)
				if (model.SelectedCheeseNames.Contains(cheese.Name))
					cheesesToRemove.Add(cheese);
			foreach (Cheese cheese in cheesesToRemove)
				cheeses.Remove(cheese);
			return Redirect("Index");
		}

		[HttpGet]
		public IActionResult DropDownDelete() 
		{
			var model = new DropDownDeleteViewModel(cheeses);
			return View(model);
		}

		[HttpPost]
		public IActionResult DropDownDelete(DropDownDeleteViewModel model) 
		{
			Cheese cheeseToRemove = new Cheese();
			foreach (Cheese cheese in cheeses)
				if (cheese.Name == model.SelectedCheeseName)
					cheeseToRemove = cheese;
			cheeses.Remove(cheeseToRemove);

			return Redirect("Index");
		}
    }
}