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
    [Route("house")]
    [Produces("application/json")]
    [ApiController]
    public class HouseController : Controller
    {
        [HttpPost]
        public void AddHouse(House p_house)
        {
            HouseManager v_houseManager = new HouseManager();
            v_houseManager.AddHouse(p_house);
        }
        [HttpGet]
        public List<House> GetHouses()
        {
            HouseManager v_houseManager = new HouseManager();
            return v_houseManager.GetHouses();
        }
    }
}
