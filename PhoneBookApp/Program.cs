using PhoneBookApp.Data;
using PhoneBookApp.Services;

namespace PhoneBookApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var _db = new AppDbContext();
                var contactService = new ContactService(_db);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
