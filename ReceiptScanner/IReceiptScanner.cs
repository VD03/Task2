using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReceiptScanner
{
   public interface IReceiptScanner
    {
        List<ReceiptScannerDetails> Products(List<ReceiptScannerDetails> data, bool domestic);

        float Cost(List<ReceiptScannerDetails> data, bool domestic);

        int Count(List<ReceiptScannerDetails> data, bool domestic);
    }
}
