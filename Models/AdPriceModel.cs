using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdFeeCalculator.Models
{
    public class AdDuration
    {
        public int Id { get; set; }
        public int MaxSecs { get; set; }
        public int MinSecs { get; set; }
        public int ChargePerSec { get; set; }
    }

    public class MediaType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int LevyCharge { get; set; }
    }

    public class Station
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int OneOffCharge { get; set; }
    }

    public class AdPriceModel
    {

        public IList<AdDuration> AdDurations { get; set; }

        public IList<MediaType> MediaTypes { get; set; }

        public IList<Station> Stations { get; set; }
    }
}
