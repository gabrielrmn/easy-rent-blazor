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
    [Route("propertyvisit")]
    [Produces("application/json")]
    [ApiController]
    public class PropertyVisitController : Controller
    {
        [HttpPost]
        public void AddPropertyVisit(PropertyVisit p_visit)
        {
            PropertyVisitManager v_visitManager = new PropertyVisitManager();
            v_visitManager.AddPropertyVisit(p_visit);
        }
        [HttpGet]
        public List<String> GetSchedules(String p_id, String p_type,String p_date)
        {
            PropertyVisitManager v_visitManager = new PropertyVisitManager();
            return v_visitManager.GetSchedules(p_id, p_type,p_date);
        }
    }
}
