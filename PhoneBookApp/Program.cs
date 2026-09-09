using PhoneBookApp.Data;
using PhoneBookApp.Services;
using PhoneBookApp.UI;
using RandomUserGenerator;
using RandomUserGenerator.Models;
using ConsoleUI.StateMachine;
using PhoneBookApp.Models;

namespace PhoneBookApp
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            try
            {
                var _db = new AppDbContext();
                var contactService = new ContactService(_db);

                // generate some random users for testing
                /*var gen = await RandUserGen.CreateAsync();
                var randUsers = gen.GenerateRandomUsers(20);
                List<Contact> contacts = new List<Contact>();
                foreach (var user in  randUsers)
                {
                    contacts.Add(Contact.FromUser(user));
                }
                await contactService.AddAsync(contacts);*/

                var screenController = new ScreenController(new MainMenu(contactService));
                await screenController.RunAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.ReadKey();
        }
    }
}
