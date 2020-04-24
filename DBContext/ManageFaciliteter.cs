using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelKlasser;

namespace DBContext
{
    public class ManageFaciliteter : IManageFaciliteter
    {
        public const string DbAccess =
            "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog = Test; Integrated Security = True; Connect Timeout = 30; Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public List<Faciliteter> FacilitetList = new List<Faciliteter>();

        public bool CreateFacilitet(Faciliteter facilitet)
        {
            using (SqlConnection connection = new SqlConnection(DbAccess))
            {
                var Test = GetAllFaciliteter().Contains(facilitet);
                if (!Test)
                {
                    var Query =
                        $"Insert into Faciliteter Values ({facilitet.Facilitet_Nr}, '{facilitet.Navn}', '{facilitet.Åbningstid}', '{facilitet.Lukketid}')";
                    SqlCommand command = new SqlCommand(Query, connection);
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                }
                return Test;
            }
        }

        public Faciliteter DeleteFacilitet(int FacilitetId)
        {
            using (SqlConnection connection = new SqlConnection(DbAccess))
            {
                var Test = GetFaciliteterFromId(FacilitetId);
                if (Test != null)
                {
                    var Query =
                        $"Delete from Faciliteter where Facilitet_Nr = {FacilitetId}";
                    SqlCommand command = new SqlCommand(Query, connection);
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                }
                return Test;
            }
        }

        public List<Faciliteter> GetAllFaciliteter()
        {
            using (SqlConnection connection = new SqlConnection(DbAccess))
            {
                var Query = "Select * from Faciliteter";
                SqlCommand command = new SqlCommand(Query, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    int FacilitetNr = reader.GetInt32(0);
                    string FacilitetNavn = reader.GetString(1);
                    TimeSpan Åbningstid = reader.GetTimeSpan(2);
                    TimeSpan Lukketid = reader.GetTimeSpan(3);
                    Faciliteter addFaciliteter = new Faciliteter()
                    {
                        Facilitet_Nr = FacilitetNr,
                        Navn = FacilitetNavn,
                        Åbningstid = Åbningstid,
                        Lukketid = Lukketid,
                        //Hotel_Nr = HotelNr
                    };
                    FacilitetList.Add(addFaciliteter);
                }
                connection.Close();
                return FacilitetList;
            }
        }

        public Faciliteter GetFaciliteterFromId(int FacilitetId)
        {
            using (SqlConnection connection = new SqlConnection(DbAccess))
            {
                var Query = $"Select * from Faciliteter where Facilitet_Nr = {FacilitetId}";
                SqlCommand command = new SqlCommand(Query, connection);
                connection.Open();
                Faciliteter facilitet = new Faciliteter();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    int FacilitetNr = reader.GetInt32(0);
                    string FacilitetNavn = reader.GetString(1);
                    TimeSpan Åbningstid = reader.GetTimeSpan(2);
                    TimeSpan Lukketid = reader.GetTimeSpan(3);
                    facilitet.Facilitet_Nr = FacilitetNr;
                    facilitet.Navn = FacilitetNavn;
                    facilitet.Åbningstid = Åbningstid;
                    facilitet.Lukketid = Lukketid;
                }
                connection.Close();
                return facilitet;
            }
        }

        public bool UpdateFacilitet(int FacilitetId, Faciliteter facilitet)
        {
            using (SqlConnection connection = new SqlConnection(DbAccess))
            {
                var Test = GetAllFaciliteter().Contains(facilitet);
                if (!Test)
                {
                    var Query =
                        $"Update Faciliteter set Facilitet_Nr = {facilitet.Facilitet_Nr}, Navn = '{facilitet.Navn}', Åbningstid = '{facilitet.Åbningstid}', Lukketid = '{facilitet.Lukketid}' where Facilitet_Nr = {FacilitetId}";
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
