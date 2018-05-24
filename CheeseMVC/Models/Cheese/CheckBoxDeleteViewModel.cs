using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CheeseMVC.Models.Cheese
{
    public class CheckBoxDeleteViewModel
    {
		public List<Cheese> Cheeses { get; set; }
		public string[] SelectedCheeseNames { get; set; }

		public CheckBoxDeleteViewModel(List<Cheese> cheeses) {
			Cheeses = cheeses;
		}

		public CheckBoxDeleteViewModel() { }
    }
}
