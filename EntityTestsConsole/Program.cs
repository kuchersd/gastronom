using gastronom.Models;
using gastronom.Services;
using System;

namespace EntityTestsConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            IDataService<Account> accountService = new GenericDataService<Account>(new DbContextFactory());
            IDataService<Products> productsService = new GenericDataService<Products>(new DbContextFactory());
            //accountService.Create(new Account { UserName = "root2", PinCode = 321321333 }).Wait();

            productsService.Create(new Products {Id = 619619619614 ,Name = "Soup", Description = "with mushrooms", Added = DateTime.Now, Type = 0, QuantityOrWeight = 10, Price = 20 }).Wait();

            //accountService.Delete(2).Wait();

            Console.WriteLine(); Console.WriteLine();

            var allEntities = accountService.GetAll();
            foreach(var allent in allEntities.Result)
            {
                Console.WriteLine(allent.UserName);
            }



            Console.ReadKey();
        }
    }
}
