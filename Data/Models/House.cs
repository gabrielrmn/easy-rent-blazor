using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using Newtonsoft.Json;


namespace EasyRent.Data.Models
{
    public class House
    {
        public String id { get; set; }
        public String bedrooms{ get; set; }
        public String suites{ get; set; }
        public String livingRooms{ get; set; }
        public String parkingSpaces{ get; set; }
        public String area{ get; set; }
        public bool imbuedCloset{ get; set; }
        public String description{ get; set; }
        public String owner{ get; set; }
        public String rentValue { get; set; }
        public String district { get; set; }
        public String address { get; set; }
    }
    public class HouseManager
    {
        public HouseManager() { }

        public void AddHouse(House p_house)
        {
            MySqlConnection v_connection = ConnectionDB.connection();
            v_connection.Open();
            MySqlCommand v_query = v_connection.CreateCommand();
            v_query.CommandText = "INSERT INTO easyrent.house (bedrooms, suites, livingRooms, parkingSpaces, area, imbuedCloset, description, owner, rentValue,district, address) " +
                $"values ('{p_house.bedrooms}','{p_house.suites}','{p_house.livingRooms}','{p_house.parkingSpaces}','{p_house.area}','{p_house.imbuedCloset}','{p_house.description}','{p_house.owner}','{p_house.rentValue}','{p_house.district}','{p_house.address}')";

            try
            {
                v_query.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Problem inserting new House into database: " + ex.Message);
            }
        }

        public List<House> GetHouses()
        {
            List<House> v_houses = new List<House>();
            MySqlConnection v_connection = ConnectionDB.connection();
            MySqlCommand v_query = v_connection.CreateCommand();
            v_query.CommandText = "SELECT * FROM easyrent.house";
            v_connection.Open();

            MySqlDataReader m_fetchQuery = v_query.ExecuteReader();
            while (m_fetchQuery.Read())
            {
                House t_house = new House();
                t_house.id = m_fetchQuery["id"].ToString();
                t_house.bedrooms = m_fetchQuery["bedrooms"].ToString();
                t_house.suites = m_fetchQuery["suites"].ToString();
                t_house.livingRooms = m_fetchQuery["livingRooms"].ToString();
                t_house.parkingSpaces = m_fetchQuery["parkingSpaces"].ToString();
                t_house.area = m_fetchQuery["area"].ToString();
                t_house.description = m_fetchQuery["description"].ToString();
                t_house.owner = m_fetchQuery["owner"].ToString();
                t_house.imbuedCloset = (m_fetchQuery["imbuedCloset"].ToString() == "True") ? true : false;
                t_house.rentValue = m_fetchQuery["rentValue"].ToString();
                t_house.district = m_fetchQuery["district"].ToString();
                t_house.address = m_fetchQuery["address"].ToString();
                v_houses.Add(t_house);
            }
            v_connection.Close();

            return v_houses;
        }
    }
}
