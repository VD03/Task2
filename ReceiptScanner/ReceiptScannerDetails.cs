using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReceiptScanner
{
   public class ReceiptScannerDetails
    {
        public string Name { get; set; }
        public bool Domestic { get; set; }
        public float Price { get; set; }
        public int Weight { get; set; }
        public string Description { get; set; }
    }
}
