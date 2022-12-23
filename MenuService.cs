using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermarket
{
    internal class MenuService
    {
        static MarketService marketService;

        static MenuService()
        {
            marketService = new();
        }

        public static void AddProductMenu()
        {
        TypeAttribute:
            Console.Write("=> Please select type of Product:");

            listProductType();

            Console.WriteLine("\n");
            bool res = Enum.TryParse(typeof(TypeOfProducts), Console.ReadLine(), out object result);

            if (res)
            {
                Console.WriteLine("\n=> Please enter product name");
                string name = Console.ReadLine();

                SetPrice:
                Console.WriteLine("=> Please enter product Price");
                bool ress = double.TryParse(Console.ReadLine(), out double price);
                if (ress)
                {
                    TypeOfProducts category = (TypeOfProducts)result; //Downcasting
                    marketService.AddProduct(name, price, category);
                }
                else
                {
                    goto SetPrice;
                }
            }
            else
            {
                Console.WriteLine("=> Please choose type correctly");
                goto TypeAttribute;
            }
        }

        public static void FilterProductByNameMenu()
        {
            //listProductType();
            Console.WriteLine("\n=> Enter the name of the product you want to find.");

            EnteringWord:
            string word = Console.ReadLine();
            if( string.IsNullOrEmpty(word) )
            {
                Console.WriteLine("=> !! Something is wrong. Please enter name again !!");
                goto EnteringWord;
            }
            else
            {
                marketService.FilterProductByName(word);
            }

        }

        public static void FilterProductsByTypeMenu()
        {
            Console.Write("\n=> Include the type whose products you want to see.");
            listProductType();

            typeChoosing:
            bool res = Enum.TryParse(typeof(TypeOfProducts), Console.ReadLine(), out object type);
            if( res )
            {
                TypeOfProducts product = (TypeOfProducts)type;
                marketService.FilterProductsByType(product);
            }
            else
            {
                Console.WriteLine("=> Please choose type correctly");
                goto typeChoosing;
            }

        }

        public static void RemoveProductByNoMenu()
        {
            marketService.AllProducts();
            Console.WriteLine("\n=> Enter name of product which you want to remove.");
            EnteringNo:
            string no = Console.ReadLine();
            if ( string.IsNullOrEmpty(no) )
            {
                Console.WriteLine("=> Please enter valid No");
                goto EnteringNo;
            }
            else
            {
                marketService.RemoveProductByNo(no);
            }
        }

        public static void listProductType()
        {
            Console.WriteLine("\n");
            Console.WriteLine("~~~~~~~~~~~");
            foreach (object category in Enum.GetValues(typeof(TypeOfProducts)))
            {
                Console.WriteLine($"{(int)category}.{category}");
            }
            Console.WriteLine("~~~~~~~~~~~");
        }
    }
}
