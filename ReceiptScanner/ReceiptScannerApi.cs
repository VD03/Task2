using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace ReceiptScanner
{
    public class ReceiptScannerApi
    {
        private static string apiUrl = "https://interview-task-api.mca.dev/qr-scanner-codes/alpha-qr-gFpwhsQ8fkY1";

        public static async Task<string> RunAsync()
        {
            var jsonString = "";


            using (var client = new HttpClient()) {

                client.BaseAddress = new Uri(apiUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = await client.GetAsync(apiUrl);
                if (response.IsSuccessStatusCode)
                {
                    jsonString = await response.Content.ReadAsStringAsync();
                }
            }

            return jsonString;
        }
    }
}
