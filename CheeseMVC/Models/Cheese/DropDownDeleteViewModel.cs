using CheeseMVC.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CheeseMVC.Models.Cheese
{
    public class DropDownDeleteViewModel
    {

		public List<Cheese> Cheeses { get; set; }
		public string SelectedCheeseName { get; set; }

		public DropDownDeleteViewModel(List<Cheese> cheeses) {
			Cheeses = cheeses;
		}

		public DropDownDeleteViewModel() { }
    }
}
