using System;
using System.Threading.Tasks;

namespace ReceiptScanner
{
    public class Program
    {
        static void Main()
        {
            try
            {
                Console.OutputEncoding = System.Text.Encoding.UTF8;

                var data = ReceiptScannerService.Data();

            }
            catch (Exception ex)
            {
                Console.WriteLine("The procedure didn't completed.. The following error occured:");
                Console.WriteLine(ex.Message);
            }
            Console.ReadLine();
        }
    }
}
