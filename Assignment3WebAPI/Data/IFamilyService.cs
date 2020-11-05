using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Assignment3WebAPI.Models;

namespace Assignment3WebAPI.Data
{
    public interface IFamilyService
    {
        Task<IList<Family>> GetFamilytAsync();
        Task<Family> AddFamilyAsync(Family family);
        Task RemoveFamilyAsync(int houseNumber,string streetName);
        Task<Family> UpdateFamilyAsync(Family family);
    }
}
