using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermarket
{
    internal interface IMarketService
    {
        void AddProduct(string name , double price , TypeOfProducts categories);
        void RemoveProductByNo(string no);
        void FilterProductsByType(TypeOfProducts categories);
        void FilterProductByName(string word);
        void AllProducts();
    }
}
