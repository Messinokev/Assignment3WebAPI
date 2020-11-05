using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Assignment3WebAPI.Models;

namespace Assignment3WebAPI.Data
{
    public class FamilyService : IFamilyService
    {
        private string familyFile = "families.json";
        private IList<Family> families;

        public FamilyService()
        {
            string content = File.ReadAllText(familyFile);
            families = JsonSerializer.Deserialize<List<Family>>(content);
        }



        public async Task<IList<Family>> GetFamilytAsync()
        {
            List<Family> tmp = new List<Family>(families);
            return tmp;
        }

        public Task<Family> AddFamilyAsync(Family family)
        {
            throw new NotImplementedException();
        }

        public async Task RemoveFamilyAsync(int houseNumber, string streetName)
        {
            Family familyToRemove = families.First(t => t.HouseNumber == houseNumber && t.StreetName.Equals(streetName));
            families.Remove(familyToRemove);
            WriteFamiliesToFile();
        }

        public async Task<Family> UpdateFamilyAsync(Family family)
        {
            Family toUpdate = families.First(t => t.HouseNumber == family.HouseNumber && t.StreetName.Equals(family.StreetName));
            toUpdate.Adults = family.Adults;
            toUpdate.Children = family.Children;
            toUpdate.HouseNumber = family.HouseNumber;
            toUpdate.Pets = family.Pets;
            toUpdate.StreetName = family.StreetName;
            WriteFamiliesToFile();
            return toUpdate;

        }

        private void WriteFamiliesToFile()
        {
            string productsAsJson = JsonSerializer.Serialize(families);
            File.WriteAllText(familyFile, productsAsJson);
        }
    }
}
