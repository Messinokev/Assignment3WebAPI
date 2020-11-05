using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Assignment3WebAPI.Models;

namespace Assignment3WebAPI.Data
{
    public interface IUserService
    {
        Task<User> GetUserAsync(string userName);
        
    }
}
