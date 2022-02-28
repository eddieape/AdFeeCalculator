using AdFeeCalculator.Models;
using AdFeeCalculator.RQ;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdFeeCalculator.Services
{
    public interface IAdPriceService
    {
        Task<AdPriceRes> GetAdFee(AdPriceRQ request);

        Task<AdParamModel> GetAdParam();
    }
}
