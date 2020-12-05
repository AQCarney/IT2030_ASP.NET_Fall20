using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace QuarterlySales.Models
{
    public static class StringExtensionMethods
    {
        public static int ToInt(this string s)
        {
            int.TryParse(s, out int id);
            return id;
        }
    }
}
