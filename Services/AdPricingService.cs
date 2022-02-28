using AdFeeCalculator.Models;
using AdFeeCalculator.RQ;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdFeeCalculator.Services
{
    public class AdPricingService : IAdPriceService
    {
        public AdPriceModel AdPricing { get; set; }

        public AdPricingService()
        {
            AdPricing = new AdPriceModel();

            AdPricing.AdDurations = new List<AdDuration>(
                new AdDuration[]
                {
                    new AdDuration
                    {
                        Id = 1,
                        MinSecs = 5,
                        MaxSecs = 30,
                        ChargePerSec = 125
                    },
                    new AdDuration
                    {
                        Id = 2,
                        MinSecs = 31,
                        MaxSecs = 60,
                        ChargePerSec = 115
                    },
                    new AdDuration
                    {
                        Id = 3,
                        MinSecs = 61,
                        MaxSecs = 180,
                        ChargePerSec = 95
                    },
                    new AdDuration
                    {
                        Id = 3,
                        MinSecs = 181,
                        MaxSecs = 300,
                        ChargePerSec = 75
                    }
                }
            );

            AdPricing.MediaTypes = new List<MediaType>(
                new MediaType[]
                {
                    new MediaType
                    {
                        Id = 1,
                        Name = "Video",
                        LevyCharge = 225
                    },
                    new MediaType
                    {
                        Id = 2,
                        Name = "Radio",
                        LevyCharge = 150
                    }
                }
            );

            AdPricing.Stations = new List<Station>(
                new Station[]
                {
                    new Station
                    {
                        Id = 1,
                        Name = "Star Wars FM",
                        OneOffCharge = 250
                    },
                    new Station
                    {
                        Id = 2,
                        Name = "Plainsmen FM",
                        OneOffCharge = 250
                    },
                    new Station
                    {
                        Id = 3,
                        Name = "Other",
                        OneOffCharge = 0
                    },
                }
            );
        }
        public Task<AdPriceRes> GetAdFee(AdPriceRQ req)
        {
            AdPriceRes res = new AdPriceRes();
            res.TotalFee = 0;
            for (int i = 0; i < AdPricing.AdDurations.Count; i++)
            {
                if (AdPricing.AdDurations[i].MaxSecs >= req.AdTimeLen
                    && AdPricing.AdDurations[i].MinSecs <= req.AdTimeLen)
                {
                    res.TotalFee += req.AdTimeLen * AdPricing.AdDurations[i].ChargePerSec;
                    break;
                }
            }

            if (res.TotalFee == 0)
            {
                res.Status = -1;
                res.Error = "The value of AdTimeLen must be between 5s and 300s.";
                res.TotalFee = 0;
                return Task.FromResult(res);
            }

            var mediaType = AdPricing.MediaTypes.FirstOrDefault(e => e.Name.ToLower() == req.MediaType.Trim().ToLower());
            if (mediaType == null)
            {
                res.Status = -1;
                res.Error = "The value of mediaType is invalid.";
                res.TotalFee = 0;
                return Task.FromResult(res);
            }

            res.TotalFee += mediaType.LevyCharge;



            if (req.MediaType.Trim().ToLower() == "radio")
            {
                for (int i = 0; i < req.Stations.Count; i++)
                {
                    var station = AdPricing.Stations.FirstOrDefault(e => e.Id == req.Stations[i]);
                    res.TotalFee += station.OneOffCharge;
                }
            }

            res.Status = 0;
            res.Error = "";

            return Task.FromResult(res);
        }

        public Task<AdParamModel> GetAdParam()
        {
            AdParamModel adParam = new AdParamModel();
            adParam.AdTimeLenRange = new AdTimeLenRange
            {
                MinSecs = 5,
                MaxSecs = 300
            };

            adParam.MediaTypes = new List<string> {
                "Video",
                "Radio"
            };

            adParam.Stations = new List<StationLabel> (
                new StationLabel[]
                {
                    new StationLabel
                    {
                        Id = 1,
                        Label = "Star Wars FM"
                    },
                    new StationLabel
                    {
                        Id = 2,
                        Label = "Plainsmen FM"
                    },
                    new StationLabel
                    {
                        Id = 3,
                        Label = "Other"
                    }
                }
            );
            return Task.FromResult(adParam);
        }
    }
}
