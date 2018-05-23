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
			return View(cheeses);
		}

		[HttpPost]
		public IActionResult CheckBoxDelete(string[] selectedCheeseNames) 
		{
			List<Cheese> cheesesToRemove = new List<Cheese>();
			foreach (Cheese cheese in cheeses)
				if (selectedCheeseNames.Contains(cheese.Name))
					cheesesToRemove.Add(cheese);
			foreach (Cheese cheese in cheesesToRemove)
				cheeses.Remove(cheese);
			return Redirect("Index");
		}

		[HttpGet]
		public IActionResult DropDownDelete() 
		{
			return View(cheeses);
		}

		[HttpPost]
		public IActionResult DropDownDelete(string selectedCheeseName) 
		{
			Cheese cheeseToRemove = new Cheese();
			foreach (Cheese cheese in cheeses)
				if (cheese.Name == selectedCheeseName)
					cheeseToRemove = cheese;
			cheeses.Remove(cheeseToRemove);

			return Redirect("Index");
		}
    }
}