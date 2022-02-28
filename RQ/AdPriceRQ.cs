using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdFeeCalculator.RQ
{
    public class AdPriceRQ
    {
        public int AdTimeLen { get; set; }

        public string MediaType { get; set; }

        public IList<string> Stations { get; set; }

    }

    public class AdPriceRes
    {
        public int TotalFee { get; set; }
        public int Status { get; set; }
        public string Error { get; set; }
    }
}
