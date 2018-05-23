using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace CheeseMVC.Controllers
{
    public class CheeseController : Controller
    {
		private static Dictionary<string, string> cheeses = new Dictionary<string, string>();

		[HttpGet]
        public IActionResult Index()
        {
			ViewBag.cheeses = cheeses;
            return View();
        }

		[HttpGet]
		public IActionResult Add() 
		{
			return View();
		}

		[HttpPost]
		public IActionResult Add(string cheeseName, string description) 
		{
			if (cheeses.ContainsKey(cheeseName))
				cheeses[cheeseName] = description;
			else
				cheeses.Add(cheeseName, description);
			return Redirect("Index");
		}

		[HttpGet]
		public IActionResult CheckBoxDelete() 
		{
			ViewBag.cheeses = cheeses;
			return View();
		}

		[HttpPost]
		public IActionResult CheckBoxDelete(string[] selectedCheeseNames) 
		{
			foreach (string cheeseName in selectedCheeseNames)
				cheeses.Remove(cheeseName);
			return Redirect("Index");
		}

		[HttpGet]
		public IActionResult DropDownDelete() 
		{
			ViewBag.cheeses = cheeses;
			return View();
		}

		[HttpPost]
		public IActionResult DropDownDelete(string cheeseName) 
		{
			cheeses.Remove(cheeseName);
			return Redirect("Index");
		}
    }
}