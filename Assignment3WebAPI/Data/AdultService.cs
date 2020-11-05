using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Assignment3WebAPI.Models;

namespace Assignment3WebAPI.Data
{
    public class AdultService : IAdultService
    {
        private string adultFile = "adults.json";
        private IList<Adult> adults;

        public AdultService()
        {
            string content = File.ReadAllText(adultFile);
            adults = JsonSerializer.Deserialize<List<Adult>>(content);
        }


        public async Task<IList<Adult>> GetAdultAsync(string name, int? age, int? id)
        {
            List<Adult> tmp = new List<Adult>(adults);
            List<Adult> result = new List<Adult>();

            if (name == null && age == null && id == null)
            {
                return tmp;
            }
            if (name != null && age != null)
            {
                foreach (var adult in tmp)
                {
                    if ((adult.FirstName.ToLower().Contains(name.ToLower()) || adult.LastName.ToLower().Contains(name.ToLower())) && adult.Age >= age)
                    {
                        result.Add(adult);
                    }
                }
                return result;
            }
            if (age != null)
            {
                foreach (var adult in tmp)
                {
                    if (adult.Age >= age)
                    {
                        result.Add(adult);
                    }
                }
                return result;
            }
            if (name != null)
            {
                foreach (var adult in tmp)
                {
                    if ((adult.FirstName.ToLower().Contains(name.ToLower()) || adult.LastName.ToLower().Contains(name.ToLower())))
                    {
                        result.Add(adult);
                    }
                }
                return result;
            }
            if (id != null)
            {
                foreach (var adult in tmp)
                {
                    if (adult.Id == id)
                    {
                        result.Add(adult);
                    }
                }
                return result;
            }
            return null;

        }

        public async Task RemoveAdultAsync(int adultId)
        {
            Adult toRemove = adults.First(t => t.Id == adultId);
            adults.Remove(toRemove);
            WriteAdultsToFile();
        }

        public async Task<Adult> AddAdultAsync(Adult adult)
        {
            int max = adults.Max(adult => adult.Id);
            adult.Id = (++max);
            adults.Add(adult);
            WriteAdultsToFile();
            return adult;
        }

        

        public async Task<Adult> UpdateAdultAsync(Adult adult)
        {
            Adult toUpdate = adults.First(t => t.Id == adult.Id);
            toUpdate.JobTitle = adult.JobTitle;
            toUpdate.Id = adult.Id;
            toUpdate.FirstName = adult.FirstName;
            toUpdate.LastName = adult.LastName;
            toUpdate.HairColor = adult.HairColor;
            toUpdate.EyeColor = adult.EyeColor;
            toUpdate.Age = adult.Age;
            toUpdate.Weight = adult.Weight;
            toUpdate.Height = adult.Height;
            toUpdate.Sex = adult.Sex;
            WriteAdultsToFile();
            return toUpdate;
        }

        private void WriteAdultsToFile()
        {
            string productsAsJson = JsonSerializer.Serialize(adults);
            File.WriteAllText(adultFile, productsAsJson);
        }
    }
}
