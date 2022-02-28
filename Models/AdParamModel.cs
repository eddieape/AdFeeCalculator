using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdFeeCalculator.Models
{
    public class AdTimeLenRange
    {
        public int MaxSecs { get; set; }
        public int MinSecs { get; set; }
    }

    public class StationLabel
    {
        public int Id { get; set; }
        public string Label { get; set; }
    }

    public class AdParamModel
    {
        public AdTimeLenRange AdTimeLenRange { get; set; }

        public IList<string> MediaTypes { get; set; }

        public IList<StationLabel> Stations { get; set; }
    }
}
