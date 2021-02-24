using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using Microsoft.AspNetCore.Mvc;
using EasyRent.Data.Models;
using Newtonsoft.Json;

namespace EasyRent.Data.Controllers
{
    [Route("apartment")]
    [Produces("application/json")]
    [ApiController]
    public class ApartmentController : Controller
    {
        [HttpPost]
        public void AddApartment(Apartment p_apt)
        {
            ApartmentManager v_aptManager = new ApartmentManager();
            v_aptManager.AddApartment(p_apt);
        }
        [HttpGet]
        public List<Apartment> GetApartments()
        {
            ApartmentManager v_aptManager = new ApartmentManager();
            return v_aptManager.GetApartments();
        }
    }
}
