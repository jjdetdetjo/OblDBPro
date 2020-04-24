using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using ModelKlasser;

namespace REST_Customer
{
    class Methods
    {
        const string accessString = "https://localhost:44362/";

        #region FacilitetMethods
        public void GetAllFacilities()
        {
            //Hent alle faciliteter

            HttpClientHandler handler = new HttpClientHandler()
            {
                UseDefaultCredentials = true
            };
            using (var client = new HttpClient(handler))
            {
                client.BaseAddress = new Uri(accessString);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                Console.WriteLine("Du har hentet alle faciliteter\n");
                try
                {
                    var hentFaciliteter = client.GetAsync("api/faciliteter").Result;
                    if (hentFaciliteter.IsSuccessStatusCode)
                    {
                        var mineFaciliteter = hentFaciliteter.Content.ReadAsAsync<IEnumerable<Faciliteter>>().Result;

                        foreach (var faciliteter in mineFaciliteter)
                        {
                            Console.WriteLine(faciliteter);
                        }
                    }
                }

                catch (Exception e)
                {
                    Console.WriteLine("You broke it");
                }
            }
        }

        public void GetFacilityFromId(int id)
        {
            //Hent facilitet via id

            HttpClientHandler handler = new HttpClientHandler()
            {
                UseDefaultCredentials = true
            };
            using (var client = new HttpClient(handler))
            {
                client.BaseAddress = new Uri(accessString);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                Faciliteter mitFaciliteter = new Faciliteter();

                Console.WriteLine($"Du har hentet facilitet med id: {id}\n");
                try
                {
                    var hentFaciliteter = client.GetAsync($"api/faciliteter/{id}").Result;
                    if (hentFaciliteter.IsSuccessStatusCode)
                    {
                        var mineFaciliteter = hentFaciliteter.Content.ReadAsAsync<Faciliteter>().Result;

                        mitFaciliteter.Facilitet_Nr = mineFaciliteter.Facilitet_Nr;
                        mitFaciliteter.Navn = mineFaciliteter.Navn;
                        mitFaciliteter.Åbningstid = mineFaciliteter.Åbningstid;
                        mitFaciliteter.Lukketid = mineFaciliteter.Lukketid;

                        Console.WriteLine(mitFaciliteter);
                    }
                }

                catch (Exception e)
                {
                    Console.WriteLine("You broke it");
                }


            }
        }

        public void CreateFacility(Faciliteter postFacilitet)
        {
            //Opret facilitet

            HttpClientHandler handler = new HttpClientHandler()
            {
                UseDefaultCredentials = true
            };
            using (var client = new HttpClient(handler))
            {
                client.BaseAddress = new Uri(accessString);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                try
                {
                    var createFacilitet = client.PostAsJsonAsync("api/faciliteter", postFacilitet).Result;
                }

                catch (Exception e)
                {
                    Console.WriteLine("You broke it");
                }

                Console.WriteLine($"Du har oprettet et facilitet med id: {postFacilitet.Facilitet_Nr}\n");
            }
        }

        public void UpdateFacility(int id, Faciliteter putFaciliteter)
        {
            //Opdater facilitet

            HttpClientHandler handler = new HttpClientHandler()
            {
                UseDefaultCredentials = true
            };
            using (var client = new HttpClient(handler))
            {
                client.BaseAddress = new Uri(accessString);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                try
                {
                    var createFacilitet = client.PutAsJsonAsync($"api/faciliteter/{id}", putFaciliteter).Result;
                }

                catch (Exception e)
                {
                    Console.WriteLine("You broke it");
                }

                Console.WriteLine($"Du har opdateret et facilitet med id: {putFaciliteter.Facilitet_Nr}\n");
            }
        }

        public void DeleteFacility(int id)
        {
            //Slet facilitet

            HttpClientHandler handler = new HttpClientHandler()
            {
                UseDefaultCredentials = true
            };
            using (var client = new HttpClient(handler))
            {
                client.BaseAddress = new Uri(accessString);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                try
                {
                    var deleteFacilitet = client.DeleteAsync($"api/faciliteter/{id}").Result;
                }

                catch (Exception e)
                {
                    Console.WriteLine("You broke it");
                }

                Console.WriteLine($"Du har slettet facilitet med id: {id}");
            }
        }
        #endregion

        #region HotelMethods

        public void GetAllHotels()
        {
            //Hent alle hoteller

            HttpClientHandler handler = new HttpClientHandler()
            {
                UseDefaultCredentials = true
            };
            using (var client = new HttpClient(handler))
            {
                client.BaseAddress = new Uri(accessString);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                Console.WriteLine("Du har hentet alle hoteller\n");
                try
                {
                    var hentHoteller = client.GetAsync("api/hotel").Result;
                    if (hentHoteller.IsSuccessStatusCode)
                    {
                        var mineHoteller = hentHoteller.Content.ReadAsAsync<IEnumerable<Hotel>>().Result;

                        foreach (var hotel in mineHoteller)
                        {
                            Console.WriteLine(hotel);
                        }
                    }
                }

                catch (Exception e)
                {
                    Console.WriteLine("You broke it");
                }
            }
        }

        public void GetHotelFromId(int id)
        {
            //Hent hotel via id

            HttpClientHandler handler = new HttpClientHandler()
            {
                UseDefaultCredentials = true
            };
            using (var client = new HttpClient(handler))
            {
                client.BaseAddress = new Uri(accessString);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                Hotel mitHotel = new Hotel();

                Console.WriteLine($"Du har hentet hotel med id: {id}\n");
                try
                {
                    var hentHotel = client.GetAsync($"api/hotel/{id}").Result;
                    if (hentHotel.IsSuccessStatusCode)
                    {
                        var myHotel = hentHotel.Content.ReadAsAsync<Hotel>().Result;

                        mitHotel.Hotel_Nr = myHotel.Hotel_Nr;
                        mitHotel.Navn = myHotel.Navn;
                        mitHotel.Adresse = myHotel.Adresse;

                        Console.WriteLine(mitHotel);
                    }
                }

                catch (Exception e)
                {
                    Console.WriteLine("You broke it");
                }


            }
        }

        public void CreateHotel(Hotel postHotel)
        {
            //Opret hotel

            HttpClientHandler handler = new HttpClientHandler()
            {
                UseDefaultCredentials = true
            };
            using (var client = new HttpClient(handler))
            {
                client.BaseAddress = new Uri(accessString);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                try
                {
                    var createHotel = client.PostAsJsonAsync("api/hotel", postHotel).Result;
                }

                catch (Exception e)
                {
                    Console.WriteLine("You broke it");
                }

                Console.WriteLine($"Du har oprettet et hotel med id: {postHotel.Hotel_Nr}\n");
            }
        }

        public void UpdateHotel(int id, Hotel putHotel)
        {
            //Opdater hotel

            HttpClientHandler handler = new HttpClientHandler()
            {
                UseDefaultCredentials = true
            };
            using (var client = new HttpClient(handler))
            {
                client.BaseAddress = new Uri(accessString);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                try
                {
                    var createHotel = client.PutAsJsonAsync($"api/hotel/{id}", putHotel).Result;
                }

                catch (Exception e)
                {
                    Console.WriteLine("You broke it");
                }

                Console.WriteLine($"Du har opdateret et facilitet med id: {putHotel.Hotel_Nr}\n");
            }
        }

        public void DeleteHotel(int id)
        {
            //Slet hotel

            HttpClientHandler handler = new HttpClientHandler()
            {
                UseDefaultCredentials = true
            };
            using (var client = new HttpClient(handler))
            {
                client.BaseAddress = new Uri(accessString);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                try
                {
                    var deleteHotel = client.DeleteAsync($"api/hotel/{id}").Result;
                }

                catch (Exception e)
                {
                    Console.WriteLine("You broke it");
                }

                Console.WriteLine($"Du har slettet hotel med id: {id}");
            }
        }

        #endregion
    }
}
