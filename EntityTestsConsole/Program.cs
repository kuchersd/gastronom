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
            accountService.Create(new Account { UserName = "root", PinCode = 321321 }).Wait();
        }
    }
}
