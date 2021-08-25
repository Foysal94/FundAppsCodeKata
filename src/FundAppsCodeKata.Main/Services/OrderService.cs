using System;
using System.Collections.Generic;
using System.Text;

namespace FundAppsCodeKata.Main.Services
{
    public class OrderService
    {
        private readonly IParcelShippingCalculatorService _parcelShippingCalculatorService;

        public OrderService(IParcelShippingCalculatorService parcelShippingCalculatorService)
        {
            _parcelShippingCalculatorService = parcelShippingCalculatorService;
        }

        public double CalculateOrder(IReadOnlyCollection<int> parcelSizes, bool isSpeedyShipping)
        {
            return 0;
        }

    }
}
