using LanguageInetgratedQuery.Models;
using LanguageInetgratedQuery.Repositories;

namespace LanguageInetgratedQuery
{
    /// <summary>
    /// Mainmenu
    /// </summary>
    internal class MainMenu
    {
        private Repository _repository = new Repository();

        /// <summary>
        /// Displays mainmenu
        /// </summary>
        public void DisplayMainMenu()
        {
            List<Product> products = this._repository.GetProducts();
            bool isAppRunning = true;
            while (isAppRunning)
            {
                Console.WriteLine(@"Hello User.... Welcome to LINQ
Select your choice to  the corresponding LINQ : 

1.Implementation of Basix LINQ queries
2.Implementations of Intermediate LINQ Queries 
3.Implementation of Advanced LINQ Queries
4.Optimized LINQ Queries
5.Implementation of Fluent API pattern.");

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
                switch (userChoice)
                {
                    case UserOptions.BasicLINQ:
                        LinqTasks.ExecuteBasicLinqTask(products);
                        break;
                    case UserOptions.IntermediateLINQ:
                        LinqTasks.ExecuteIntermediateLinqTask(products, this._repository.GetSuppliers());
                        break;
                    case UserOptions.AdvancedLINQ:
                        LinqTasks.ExecuteAdvancedLinqTask(this._repository.GetNumbers());
                        break;
                    case UserOptions.OptimizedLINQ:
                        LinqTasks.ExecuteOptimizedLinqTask(products);
                        break;
                    case UserOptions.FluentAPI:
                        LinqTasks.ExecuteFluentApiPattern(products);
                        break;
                    case UserOptions.Exit:
                        isAppRunning = false;
                        break;
                }
            }
        }
    }
}
