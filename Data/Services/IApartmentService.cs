using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using EasyRent.Data.Models;
namespace EasyRent.Data.Services
{
    public interface IApartmentService
    {
        Task<string> GetApartments();
        Task<string> AddApartment(Apartment p_apt);
    }
}
