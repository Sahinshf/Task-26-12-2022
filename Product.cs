using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermarket
{
    internal class Product
    {
        static int _count;
        public double Price;
        public string No;
        public string Name;
        public TypeOfProducts categories;

        public Product( string Name , double Price , TypeOfProducts categories )
        {
            No = $"{_count++}-{Name}";
            this.Name = Name;
            this.Price = Price;
            this.categories = categories;
        }
        static Product()
        {
            _count = 1;
        }

        public override string ToString()
        {
            return $"=> Product: {No} | Price: {Price} ";
        }

    }
}
