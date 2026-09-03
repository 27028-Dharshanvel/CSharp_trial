using LanguageInetgratedQuery.Models;
using LanguageInetgratedQuery.Repositories;

namespace LanguageInetgratedQuery
{
    /// <summary>
    /// Mainmenu of the application
    /// </summary>
    internal class MainMenu
    {
        private ProductRepository _productRepository = new ProductRepository();
        private IntegerArray _intArray = new IntegerArray();
        private SupplierRepository _supplierRepository = new SupplierRepository();

        /// <summary>
        /// Displays the mainmenu
        /// </summary>
        public void DisplayMainMenu()
        {
            List<Product> products = this._productRepository.GetProducts();
            bool isAppRunning = true;
            while (isAppRunning)
            {
                Console.WriteLine(@"Hello User.... Welcome to LINQ
Select your choice to  the corresponding LINQ : 

1.Implementation of Basix LINQ queries
2.Implementations of Intermediate LINQ Queries 
3.Implementation of Advanced LINQ Queries
4.Optimized LINQ Queries
5.Implementation of Fluent API pattern.
6.Exit");

                int choice;
                if (int.TryParse(Console.ReadLine(), out choice))
                {
                    Console.WriteLine($"Index: {choice}");
                }
                else
                {
                    Console.WriteLine("Invalid input");
                }

                UserOptions userChoice = (UserOptions)choice;
                Console.Clear();
                switch (userChoice)
                {
                    case UserOptions.BasicLINQ:
                        LinqTask.ExecuteBasicLinqTask(products);
                        break;
                    case UserOptions.IntermediateLINQ:
                        LinqTask.ExecuteIntermediateLinqTask(products, this._supplierRepository.GetSuppliers());
                        break;
                    case UserOptions.AdvancedLINQ:
                        LinqTask.ExecuteAdvancedLinqTask(this._intArray.GetNumbers());
                        break;
                    case UserOptions.OptimizedLINQ:
                        LinqTask.ExecuteOptimizedLinqTask(products);
                        break;
                    case UserOptions.FluentAPI:
                        LinqTask.ExecuteFluentApiPattern(products);
                        break;
                    case UserOptions.Exit:
                        isAppRunning = false;
                        break;
                }

                Console.ReadKey();
                Console.Clear();
            }
        }
    }
}
