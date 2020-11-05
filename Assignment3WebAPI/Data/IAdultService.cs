using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Assignment3WebAPI.Models;


namespace Assignment3WebAPI.Data
{
    public interface IAdultService
    {
        Task<IList<Adult>> GetAdultAsync(string name, int? age, int? id);
        Task<Adult> AddAdultAsync(Adult adult);
        Task RemoveAdultAsync(int adultId);
        Task<Adult> UpdateAdultAsync(Adult adult);
    }
}
