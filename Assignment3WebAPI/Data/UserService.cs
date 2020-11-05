using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Assignment3WebAPI.Models;

namespace Assignment3WebAPI.Data
{
    public class UserService : IUserService
    {
        private string userFile = "user.json";
        private IList<User> users;

        public UserService()
        {
            if (!File.Exists(userFile))
            {
                Seed();
                WriteUsersToFile();
            }
            else
            {
                string content = File.ReadAllText(userFile);
                users = JsonSerializer.Deserialize<List<User>>(content);
            }
        }

        private void Seed()
        {
            User[] users = {
                new User {
                ID = 1,
                City = "Horsens",
                Password = "123456",
                Role = "Admin",
                BirthYear = 1986,
                SecurityLevel = 3,
                UserName = "Troels"
            },
            new User {
                ID = 2,
                City = "Aarhus",
                Password = "123456",
                Role = "User",
                BirthYear = 1998,
                SecurityLevel = 2,
                UserName = "Jakob"
            },
            new User {
                ID = 3,
                City = "Vejle",
                Password = "123456",
                Role = "User",
                BirthYear = 1973,
                SecurityLevel = 1,
                UserName = "Kasper"
            }
            };
            this.users = users.ToList();
        }

        public async Task<User> GetUserAsync(string userName)
        {
            User first = users.FirstOrDefault(user => user.UserName.Equals(userName));
            if (first == null)
            {
                throw new Exception("User not found");
            }

            return first;
        }

        private void WriteUsersToFile()
        {
            string productsAsJson = JsonSerializer.Serialize(users);
            File.WriteAllText(userFile, productsAsJson);
        }
    }
}
