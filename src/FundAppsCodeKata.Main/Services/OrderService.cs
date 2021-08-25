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
            double totalCost = 0;
            foreach (var parcelSize in parcelSizes)
            {
                totalCost = totalCost + _parcelShippingCalculatorService.Calculcate(parcelSize);
            }

            if (isSpeedyShipping)
                totalCost = totalCost * 2;

            return totalCost;
        }

    }
}
