using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using Newtonsoft.Json;

namespace EasyRent.Data.Models
{
    public class PropertyVisit
    {
        public String propertyId { get; set; }
        public String type { get; set; }
        public DateTime datetime { get; set; }
        public String customer { get; set; }

        //public List<String> schedules = new List<String>(new String[] { "09:00:00", "10:00:00", "11:00:00", "14:00:00", "15:00:00", "16:00:00" });
    }

    public class PropertyVisitManager
    {
        public PropertyVisitManager() { }

        public void AddPropertyVisit(PropertyVisit p_apt)
        {
            MySqlConnection v_connection = ConnectionDB.connection();
            v_connection.Open();
            MySqlCommand v_query = v_connection.CreateCommand();
            v_query.CommandText = "INSERT INTO easyrent.propertyvisits (propertyId, `type`, `datetime`, customer) " +
                $"values ('{p_apt.propertyId}','{p_apt.type}','{p_apt.datetime.ToString("yyyy-MM-dd HH:mm:ss")}','{p_apt.customer}')";

            try
            {
                v_query.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Problem inserting new apartment into database: " + ex.Message);
            }
        }

        public List<String> GetSchedules(String p_id, String p_type, String p_date)
        {
            List<PropertyVisit> v_apts = new List<PropertyVisit>();
            MySqlConnection v_connection = ConnectionDB.connection();
            MySqlCommand v_query = v_connection.CreateCommand();
            v_query.CommandText = $"SELECT `datetime` FROM easyrent.propertyvisits where propertyId = '{p_id}' and `type` = '{p_type}'";
            v_connection.Open();

            List<String> v_schedules = new List<String>(new String[] { "09:00:00", "10:00:00", "11:00:00", "14:00:00", "15:00:00", "16:00:00" });

            MySqlDataReader m_fetchQuery = v_query.ExecuteReader();
            while (m_fetchQuery.Read())
            {
                String v_dateString = m_fetchQuery["datetime"].ToString().Split(" ")[0];
                DateTime v_date = DateTime.Parse(v_dateString);
                v_dateString = v_date.ToString("yyyy-MM-dd HH:mm:ss").Split(" ")[0];
                PropertyVisit t_apt = new PropertyVisit();
                if (v_schedules.Contains(m_fetchQuery["datetime"].ToString().Split(" ")[1]) && p_date.Equals(v_dateString))
                    v_schedules.Remove(m_fetchQuery["datetime"].ToString().Split(" ")[1]);
            }
            v_connection.Close();

            return v_schedules;
        }
    }
}
