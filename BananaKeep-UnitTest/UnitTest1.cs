using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Net.Http;
using System.ComponentModel;
using Newtonsoft.Json;

namespace BananaKeep_UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        private const string URL = "http://localhost:5257/api/gps/gps-data";
        private string urlParameters = "";
        public class DataObject
        {
            public string Name { get; set; }
        }

        public class GPSUnit
        {
            // GPSData class is used to store the GPS data received from the GPS module.
            public int ID { get; set; }
            public string Name { get; set; }
            public bool Active { get; set; }
            public double Latitude { get; set; }
            public double Longitude { get; set; }
            public double Altitude { get; set; }
            public DateTime Timestamp { get; set; }
        }

        [TestMethod]
        public void TestGPSDataEndpoint()
        {
            // Source:
            // https://stackoverflow.com/a/17459045

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(URL);

            // Add an Accept header for JSON format.
            client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));

            GPSUnit gPSUnit = new GPSUnit();
            gPSUnit.Altitude = 1500;
            gPSUnit.Latitude = 75;
            gPSUnit.Longitude = 75;
            gPSUnit.Active= true;
            gPSUnit.Name = "Whatever";
            gPSUnit.Timestamp = DateTime.Now.ToUniversalTime();
            gPSUnit.ID = 3;

            // List data response.
            HttpResponseMessage response = client.PostAsJsonAsync(urlParameters, gPSUnit).Result; // client.GetAsync(urlParameters).Result;  // Blocking call! Program will wait here until a response is received or a timeout occurs.
            /*
            if (response.IsSuccessStatusCode)
            {
                // Parse the response body.
                var dataObjects = response.Content.ReadAsAsync<IEnumerable<DataObject>>().Result;  //Make sure to add a reference to System.Net.Http.Formatting.dll
                foreach (var d in dataObjects)
                {
                    Console.WriteLine("{0}", d.Name);
                }
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }
            */
            Assert.IsTrue(response.IsSuccessStatusCode);

            // Make any other calls using HttpClient here.

            // Dispose once all HttpClient calls are complete. This is not necessary if the containing object will be disposed of; for example in this case the HttpClient instance will be disposed automatically when the application terminates so the following call is superfluous.
            client.Dispose();
        }
    }
}
