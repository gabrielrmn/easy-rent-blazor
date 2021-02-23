using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using Newtonsoft.Json;

namespace EasyRent.Data.Models
{
    public class Apartment
    {
        public String id { get; set; }
        public String bedrooms { get; set; }
        public String suites { get; set; }
        public String livingRooms { get; set; }
        public String dinningRooms { get; set; }
        public String parkingSpaces { get; set; }
        public String area { get; set; }
        public bool imbuedCloset { get; set; }
        public String description { get; set; }
        public String floor { get; set; }
        public String condominiumValue { get; set; }
        public bool conciergeService { get; set; }
        public String owner { get; set; }
    }

    public class ApartmentManager
    {
        public ApartmentManager() { }

        public void AddApartment(Apartment p_apt)
        {
            MySqlConnection v_connection = ConnectionDB.connection();
            v_connection.Open();
            MySqlCommand v_query = v_connection.CreateCommand();
            v_query.CommandText = "INSERT INTO easyrent.apartment (bedrooms, suites, livingRooms, parkingSpaces, area, imbuedCloset, description, `floor`, condominiumValue, conciergeService, owner) " +
                $"values ('{p_apt.bedrooms}','{p_apt.suites}','{p_apt.livingRooms}','{p_apt.parkingSpaces}','{p_apt.area}','{p_apt.imbuedCloset}','{p_apt.description}','{p_apt.floor}','{p_apt.condominiumValue}'," +
                $"'{p_apt.conciergeService}','{p_apt.owner}')";

            try
            {
                v_query.ExecuteNonQuery();
            }catch(Exception ex)
            {
                Console.WriteLine("Problem inserting new apartment into database: " + ex.Message);
            }
        }

        public List<Apartment> GetApartments()
        {
            List<Apartment> v_apts = new List<Apartment>();
            MySqlConnection v_connection = ConnectionDB.connection();
            MySqlCommand v_query = v_connection.CreateCommand();
            v_query.CommandText = "SELECT * FROM easyrent.apartment";
            v_connection.Open();

            MySqlDataReader m_fetchQuery = v_query.ExecuteReader();
            while (m_fetchQuery.Read())
            {
                Apartment t_apt = new Apartment();
                t_apt.id = m_fetchQuery["id"].ToString();
                t_apt.bedrooms = m_fetchQuery["bedrooms"].ToString();
                t_apt.suites = m_fetchQuery["suites"].ToString();
                t_apt.livingRooms = m_fetchQuery["livingRooms"].ToString();
                t_apt.dinningRooms = m_fetchQuery["dinningRooms"].ToString();
                t_apt.parkingSpaces = m_fetchQuery["parkingSpaces"].ToString();
                t_apt.area = m_fetchQuery["area"].ToString();
                t_apt.description = m_fetchQuery["description"].ToString();
                t_apt.floor = m_fetchQuery["floor"].ToString();
                t_apt.condominiumValue = m_fetchQuery["condominiumValue"].ToString();
                t_apt.owner = m_fetchQuery["owner"].ToString();
                t_apt.conciergeService = (m_fetchQuery["conciergeService"].ToString() == "True") ? true : false;
                t_apt.imbuedCloset = (m_fetchQuery["imbuedCloset"].ToString() == "True") ? true : false;
                v_apts.Add(t_apt);
            }
            v_connection.Close();

            return v_apts;
        }
    }
}
