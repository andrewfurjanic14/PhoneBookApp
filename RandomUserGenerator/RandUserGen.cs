using RandomUserGenerator.Models;
using System.Text.Json;

namespace RandomUserGenerator
{
    public class RandUserGen
    {
        private IReadOnlyList<string> _firstNames = [];
        private IReadOnlyList<string> _lastNames = [];

        private RandUserGen() { }
        private async Task InitializeAsync()
        {
            var fullNamesJson = await File.ReadAllTextAsync("Datasets/fullnames.json");
            var fullNames = JsonSerializer.Deserialize<FullNames>(fullNamesJson) ??
                throw new InvalidOperationException("Failed to retrieve names from json source!");
 
            _firstNames = fullNames.FirstNames;
            _lastNames = fullNames.LastNames;
        }
        public static async Task<RandUserGen> CreateAsync()
        {
            var instance = new RandUserGen();
            await instance.InitializeAsync();
            return instance;
        }

        public List<User> GenerateRandomUsers(int amount)
        {
            var users = new List<User>();
            for (int i = 0; i < amount; i++)
            {
                string fname = _firstNames[Random.Shared.Next(_firstNames.Count)];
                string lname = _lastNames[Random.Shared.Next(_lastNames.Count)];
                string email = fname + lname + "@email.com";
                string phoneNum = 
                    $"({Random.Shared.Next(200, 1000)}) " +
                    $"{Random.Shared.Next(200, 1000)}-" +
                    $"{Random.Shared.Next(0, 10000):D4}";

                users.Add(new User(fname, lname, email, phoneNum));
            }
            return users;
        }

    }
}
