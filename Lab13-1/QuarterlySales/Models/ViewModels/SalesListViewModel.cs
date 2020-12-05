using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using QuarterlySales.Models;

namespace QuarterlySales.Models
{
    public class SalesListViewModel
    {
        public IEnumerable<Sales> Sales { get; set; }
        public RouteDictionary CurrentRoute { get; set; }
        public int TotalPages { get; set; }
        

        public IEnumerable<Employee> Employees { get; set; }
        public IEnumerable<int> Years
        {
            get
            {
                List<int> years = new List<int>();
                int foundingYear = 1995;
                for (int year = DateTime.Today.Year; year >= foundingYear; year--)
                {
                    years.Add(year);
                }
                return years;
            }
        }
        public IEnumerable<int> Quarters
        {
            get
            {
                List<int> quarters = new List<int> { 1, 2, 3, 4 };
                return quarters;
            }
        }

    }
}
