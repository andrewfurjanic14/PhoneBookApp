using PhoneBookApp.Data;
using PhoneBookApp.Services;
using PhoneBookApp.UI;
using RandomUserGenerator;
using RandomUserGenerator.Models;
using ConsoleUI.StateMachine;

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

                var gen = await RandUserGen.CreateAsync();
                var randUsers = gen.GenerateRandomUsers(20);
                /*foreach (var user in randUsers)
                {
                    string output = $"""
                        {user.FirstName} {user.LastName}
                        Email: {user.Email}
                        Phone Number: {user.PhoneNumber}

                        """;
                    Console.WriteLine(output);
                }*/
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
