namespace Supermarket
{
    internal class Program
    {
        static void Main(string[] args) //I focused on this work like a project.
        {

            int operationn;
            Console.WriteLine("=> Welcome. Please choose operation.\n");
            do
            {
            start:
                
                Console.WriteLine("\n1. Add Product");
                Console.WriteLine("2. Remove Product");
                Console.WriteLine("3. Filter Products *By Type* ");
                Console.WriteLine("4. Filter Products *By Name* ");
                Console.WriteLine("0. Exit");
            operation:
                bool res = int.TryParse(Console.ReadLine(), out operationn);
                if (!res)
                {
                    goto operation;
                }
                else
                {
                    switch (operationn)
                    {
                        case 1: MenuService.AddProductMenu(); goto start;
                        case 2: MenuService.RemoveProductByNoMenu(); goto start;
                        case 3: MenuService.FilterProductsByTypeMenu(); goto start;
                        case 4: MenuService.FilterProductByNameMenu(); goto start;
                        default: break;
                    }

                }

            } while (operationn != 0);
        }
    }
}