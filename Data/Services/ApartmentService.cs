using EasyRent.Data.Models;
using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Text;
using Newtonsoft.Json;

namespace EasyRent.Data.Services
{
    public class ApartmentService : IApartmentService
    {
        private readonly HttpClient httpClient;

        public ApartmentService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }
        public async Task<string> GetApartments()
        {
            var v_response = await httpClient.GetAsync("apartment/get");
            string v_content = v_response.Content.ReadAsStringAsync().Result;
            return v_content;
        }
        public async Task<string> AddApartment(Apartment p_apt)
        {
            //string v_json = JsonConvert.SerializeObject(p_apt);
            //var v_content = new StringContent(v_json, Encoding.UTF8, "application/json");
            Apartment v_apt = p_apt;
            await httpClient.SendJsonAsync(HttpMethod.Post, "apartment/post", v_apt);
            string v_status = "200";
            return v_status;
        }
    }
}