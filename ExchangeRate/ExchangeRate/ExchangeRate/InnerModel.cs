using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExchangeRate
{
    class InnerModel
    {
        public string currency { get; set; }
        public double saleRateNB { get; set; }
        public double purchaseRateNB { get; set; }
        public double saleRate { get; set; }
        public double purchaseRate { get; set; }
        public string date { get; set; }
        public int rowHeight { get; set; }
        public int rowHeight2 { get; set; }
        public string saleRateSTR { get; set; }
        public string saleRateNBSTR { get; set; }
        public string purchaseRateSTR { get; set; }
        public string purchaseRateNBSTR { get; set; }
    }
}
