using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelKlasser;

namespace DBContext
{
    public class ManageHotel : IManageHotel
    {

        public const string DbAccess =
            "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog = Test; Integrated Security = True; Connect Timeout = 30; Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        List<Hotel> hotelList = new List<Hotel>();

        public bool CreateHotel(Hotel hotel)
        {
            using (SqlConnection connection = new SqlConnection(DbAccess))
            {
                var Test = GetAllHotel().Contains(hotel);
                if (!Test)
                {
                    var Query =
                        $"Insert into Hotel Values ({hotel.Hotel_Nr}, '{hotel.Navn}', '{hotel.Adresse}')";
                    SqlCommand command = new SqlCommand(Query, connection);
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                }
                return Test;
            }
        }

        public Hotel DeleteHotel(int HotelId)
        {
            using (SqlConnection connection = new SqlConnection(DbAccess))
            {
                var Test = GetHotelFromId(HotelId);
                if (Test != null)
                {
                    var Query =
                        $"Delete from Hotel where Hotel_Nr = {HotelId}";
                    SqlCommand command = new SqlCommand(Query, connection);
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                }
                return Test;
            }
        }

        public List<Hotel> GetAllHotel()
        {
            using (SqlConnection connection = new SqlConnection(DbAccess))
            {
                var Query = "Select * from Hotel";
                SqlCommand command = new SqlCommand(Query, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    int HotelNr = reader.GetInt32(0);
                    string HotelNavn = reader.GetString(1);
                    string HotelAdresse = reader.GetString(2);
                    Hotel addHotel = new Hotel()
                    {
                        Hotel_Nr = HotelNr,
                        Navn = HotelNavn,
                        Adresse = HotelAdresse
                    };
                    hotelList.Add(addHotel);
                }
                connection.Close();
                return hotelList;
            }
        }

        public Hotel GetHotelFromId(int HotelId)
        {
            using (SqlConnection connection = new SqlConnection(DbAccess))
            {
                var Query = $"Select * from Hotel where Hotel_Nr = {HotelId}";
                SqlCommand command = new SqlCommand(Query, connection);
                connection.Open();
                Hotel newHotel = new Hotel();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    int HotelNr = reader.GetInt32(0);
                    string HotelNavn = reader.GetString(1);
                    string HotelAdresse = reader.GetString(2);
                    newHotel.Hotel_Nr = HotelNr;
                    newHotel.Navn = HotelNavn;
                    newHotel.Adresse = HotelAdresse;
                }
                connection.Close();
                return newHotel;
            }
        }

        public bool UpdateHotel(int HotelId, Hotel hotel)
        {
            using (SqlConnection connection = new SqlConnection(DbAccess))
            {
                var Test = GetAllHotel().Contains(hotel);
                if (!Test)
                {
                    var Query =
                        $"Update Hotel set Hotel_Nr = {hotel.Hotel_Nr}, Navn = '{hotel.Navn}', Adresse = '{hotel.Adresse}' where Hotel_Nr = {HotelId}";
                    SqlCommand command = new SqlCommand(Query, connection);
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                }
                return Test;
            }
        }
    }
}
