using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using ModelKlasser;

namespace REST_Customer
{
    class Program
    {
        static void Main(string[] args)
        {
            Methods testMethods = new Methods();

            testMethods.GetAllFacilities();

            testMethods.GetFacilityFromId(1);

            Faciliteter testFacilitet = new Faciliteter() { Facilitet_Nr = 6, Navn = "Bar", Åbningstid = new TimeSpan(hours: 16, minutes: 00, seconds: 00), Lukketid = new TimeSpan(hours: 23, minutes: 00, seconds: 00) };
            testMethods.CreateFacility(testFacilitet);

            Faciliteter testFacilitet2 = new Faciliteter() { Facilitet_Nr = 6, Navn = "Bar", Åbningstid = new TimeSpan(hours: 15, minutes: 00, seconds: 00), Lukketid = new TimeSpan(hours: 23, minutes: 30, seconds: 00) };
            testMethods.UpdateFacility(4, testFacilitet2);

            testMethods.DeleteFacility(6);

            testMethods.GetAllHotels();

            testMethods.GetHotelFromId(1);

            Hotel testHotel = new Hotel() { Hotel_Nr = 6, Navn = "Detdetjo", Adresse = "Vejenenene 1" };
            testMethods.CreateHotel(testHotel);

            Hotel testHotel2 = new Hotel() { Hotel_Nr = 6, Navn = "BestHotel", Adresse = "Algade 1" };
            testMethods.UpdateHotel(4, testHotel2);

            testMethods.DeleteHotel(6);

            Console.ReadKey();
        }
    }
}
