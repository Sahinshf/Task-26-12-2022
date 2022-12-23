using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermarket
{
    internal class MarketService : IMarketService
    {
        public void AddProduct(string name, double price, TypeOfProducts type)
        {
            int existProduct = 0;
            foreach (Product product in Store.product)
            {
                if (name == product.Name)
                {
                    existProduct++;
                }
            }
            if (existProduct < 1)
            {

                Product product = new Product(name, price, type);
                Array.Resize(ref Store.product, Store.product.Length + 1);
                Store.product[Store.product.Length - 1] = product;
                Console.WriteLine("=> Product added successfully ");
            }
            else
            {
                Console.WriteLine("!! You cannot add this product. " + name + " is already exist !!");
            }
        }

        public void FilterProductByName(string word)
        {
            int prod = 0;
            foreach (Product product in Store.product)
            {
                if (product != null)
                {
                    
                    if (product.Name.Contains(word) || product.Name.Contains(word.ToUpper()) )
                    {
                        prod++;
                        Console.WriteLine($"=> Product Name: {product.Name} | Product Price: {product.Price}");
                    }
                }
            }
            if (prod == 0)
            {
                Console.WriteLine($"!! There is no product with this name: {word} !!");
            }
        }

        public void FilterProductsByType(TypeOfProducts type)
        {
            int count = 0;
            Console.WriteLine($"\n=> Products of {type}");
            foreach (Product product in Store.product)
            {
                if (product != null)
                {
                    if (product.categories == type)
                    {
                        count++;
                        Console.WriteLine($"=> Product Name: {product.Name} | Product Price: {product.Price}");
                    }
                }
            }
            if (count == 0)
            {
                Console.WriteLine("!! There is no product of this type !!");
            }
        }

        public void RemoveProductByNo(string no)
        {
            int count = 0;
            int remove = 0;
            foreach (Product product in Store.product)
            {
                if (product != null)
                {
                    count++;
                    if (product.No.ToUpper() == no.ToUpper())
                    {
                        remove++;
                        Store.product[count - 1] = null;
                        Console.WriteLine($"=> Product removed");
                    }
                }
            }
            if (remove == 0)
            {
                Console.WriteLine("!! Product does not exist in store !!");
            }
        }

        public void AllProducts()
        {
            if (Store.product.Length > 0)
                foreach (Product product in Store.product)
                {
                    Console.WriteLine(product);
                }
            else
            {
                Console.WriteLine("There is no product");
            }
        }
    }
}
