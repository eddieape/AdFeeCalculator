using AdFeeCalculator.Models;
using AdFeeCalculator.RQ;
using AdFeeCalculator.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdFeeCalculator.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdPriceController : ControllerBase
    {
        private readonly IAdPriceService _adPriceService;

        public AdPriceController(IAdPriceService pricingService)
        {
            _adPriceService = pricingService;
        }

        // GET /api/adprice
        [HttpGet]
        public async Task<ActionResult<AdParamModel>> GetAdParam()
        {
            return await _adPriceService.GetAdParam();
        }

        // POST /api/adprice
        [HttpPost]
        public async Task<ActionResult<AdPriceRes>> GetAdFee(AdPriceRQ req)
        {
            return await _adPriceService.GetAdFee(req);
        }
    }
}
