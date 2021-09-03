using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Globalization;
using Newtonsoft.Json;

namespace ReceiptScanner
{
   public class ReceiptScannerService : IReceiptScanner
    {
        public static async Task<List<ReceiptScannerDetails>> GetReceiptData()
        {
            string jsonString = await ReceiptScannerApi.RunAsync();

            var data = JsonConvert.DeserializeObject<List<ReceiptScannerDetails>>(jsonString);

            return data;
        }

        public List<ReceiptScannerDetails> Products(List<ReceiptScannerDetails> data, bool domestic)
        {
            var products = data.Where(x => x.Domestic == domestic).OrderBy(x => x.Name).ToList();

            return products;
        }

        public float Cost(List<ReceiptScannerDetails> data, bool domestic)
        {
            float totalCost = data.Where(x => x.Domestic == domestic).Select(y => y.Price).Sum();

            return totalCost;
        }

        public int Count(List<ReceiptScannerDetails> data, bool domestic)
        {
            int count = data.Where(x => x.Domestic == domestic).Count();

            return count;
        }

        public static async void Data()
        {
            var data = await ReceiptScannerService.GetReceiptData();

            ReceiptScannerService receiptScanner = new ReceiptScannerService();
            var domesticProducts = receiptScanner.Products(data, true);
            var importedProducts = receiptScanner.Products(data, false);
            var domesticCost = receiptScanner.Cost(data, true);
            var importedCost = receiptScanner.Cost(data, false);
            var domesticCount = receiptScanner.Count(data, true);
            var importedCount = receiptScanner.Count(data, false);

            Print(domesticProducts, true);
            Print(importedProducts, false);
            Print(null, true, domesticCost, null);
            Print(null, false, importedCost, null);
            Print(null, true, null, domesticCount);
            Print(null, false, null, importedCount);
        }
        public static void Print(List<ReceiptScannerDetails> data, bool domestic, float? cost = null, int? count = null)
        {
            NumberFormatInfo nfi = new CultureInfo("en-US", false).NumberFormat;
            nfi.CurrencyDecimalSeparator = ",";
            var emptySpace = "    ";

            if (data != null)
            {
                Console.WriteLine(". {0}", domestic ? "Domestic" : "Imported");

                foreach (var item in data)
                {
                    Console.WriteLine("... {0}", item.Name);
                    Console.WriteLine(emptySpace + "Price: {0}", item.Price.ToString("C1", nfi));
                    Console.WriteLine(item.Description.Length > 30 ? emptySpace + item.Description.Substring(0, 10) + "..." : emptySpace + item.Description);
                    Console.WriteLine(emptySpace + "Weight: {0}", item.Weight > 0 ? item.Weight + "g" : "N/A");
                }
            }

            if (cost.HasValue)
            {
                Console.WriteLine((domestic ? "DomesticCost: " : "ImportedCost: ") + cost.Value.ToString("C1", nfi));
            }

            if (count.HasValue)
            {
                Console.WriteLine((domestic ? "DomesticCount: " : "ImportedCount: ") + count.Value);
            }
        }
    }
}
