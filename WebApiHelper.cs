using System;
using System.Net.Http;
using System.Text;
using TaxScheduler.Models;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace TaxScheduler
{
    public class WebApiHelper
    {
        public WebApiHelper()
        {

        }
        public static async Task UploadTaxInformation(string filePath, string fileType)
        {
            string URL = string.Format("{0}{1}", Contants.URL,"/api/FileAccess/DocumentUpload");

            var fileAccessRequest = new FileAccessRequest()
            {
                FilePath = filePath,
                FileType = fileType
            };

            string result = await POST<FileAccessRequest>(URL, fileAccessRequest);

            if (result == "true")
            {
                Console.WriteLine("UpLoaded TaxInformation Successfully");
            }
            else
            {
                Console.WriteLine("Not able to UpLoaded TaxInformation. Please check the Log File");
            }           

        }
        public static async Task GetALLTaxDetails()
        {
           
            string URL = string.Format("{0}{1}", Contants.URL, "/api/Tax");

            string result = await GET(URL);           

            if (!string.IsNullOrEmpty(result))
            {
                Console.WriteLine(result);

                Console.WriteLine("Complted Fetching All the TaxInformation");
            }
            else
            {
                Console.WriteLine("Not able to Fecth TaxInformation. Please check the Log File");
            }

        }

        public static async Task GetTaxDetails(string municipalityName, string date)
        {
            
            string URL = string.Format("{0}{1}", Contants.URL, "/api/Tax/GetTaxDetails");

            var obj = new Municipality
            {
                Name = municipalityName,
                Date = Convert.ToDateTime(date)
            };

            string result = await POST<Municipality>(URL, obj);
                        

            if (!string.IsNullOrEmpty(result))
            {
                Console.WriteLine(result);


                Console.WriteLine("Completed Fetching Tax Details");
            }
            else
            {
                Console.WriteLine("Not able to Fecth TaxInformation. Please check the Log File");
            }

        }

        public static async Task SaveTaxDetails(string municipalityName, string date, string frequency, string tax)
        {
            
            string URL = string.Format("{0}{1}", Contants.URL, "/api/Tax/Save");

            var taxDetails = new Municipality
            {
                Name = municipalityName,
                Date = Convert.ToDateTime(date),
                Frequency = frequency,
                Tax = tax

            };

            string result = await POST<Municipality>(URL, taxDetails);

            

            if (result == "true")
            {
                Console.WriteLine("Saved TaxInformation Successfully");
            }
            else
            {
                Console.WriteLine("Not able to Save TaxInformation. Please check the Log File");
            }

        }

        public static async Task UpdateTaxDetails(string municipalityName, string date, string frequency, string tax)
        {
           
            string URL = string.Format("{0}{1}", Contants.URL, "/api/Tax/Update");

            var taxDetails = new Municipality
            {
                Name = municipalityName,
                Date = Convert.ToDateTime(date),
                Frequency = frequency,
                Tax = tax
            };

            string result = await PUT<Municipality>(URL, taxDetails);            

            if (result == "true")
            {
                Console.WriteLine("Update TaxInformation Successfully");
            }
            else
            {
                Console.WriteLine("Not able to Update TaxInformation. Please check the Log File");
            }

        }


        private static async Task<string> GET(string URL)
        {

            HttpClient client = new HttpClient();

            var response = await client.GetStringAsync(URL);

            return response;
        }

        private static async Task<string> POST<T>(string URL, T fileAccessRequest)
        {
            var json = JsonConvert.SerializeObject(fileAccessRequest);

            var data = new StringContent(json, Encoding.UTF8, "application/json");

            HttpClient client = new HttpClient();

            //client.BaseAddress = new Uri(URL);

            //client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var response = await client.PostAsync(URL, data);

            string result = response.Content.ReadAsStringAsync().Result;

            return result;
        }

        private static async Task<string> PUT<T>(string URL, T fileAccessRequest)
        {
            var json = JsonConvert.SerializeObject(fileAccessRequest);

            var data = new StringContent(json, Encoding.UTF8, "application/json");

            HttpClient client = new HttpClient();

            //client.BaseAddress = new Uri(URL);

            //client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var response = await client.PutAsync(URL, data);

            string result = response.Content.ReadAsStringAsync().Result;

            return result;
        }

    }
}