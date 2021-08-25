using FundAppsCodeKata.Main.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FundAppsCodeKata.Main
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("How many parcels: ");
            var parcelCount = int.Parse(Console.ReadLine());

            List<int> parcelSizes = new List<int>();

            for (int i = 1; i < parcelCount + 1; i++)
            {
                Console.Write($"What is the size(cm) of parcel {i}: ");
                parcelSizes.Add(int.Parse(Console.ReadLine()));
            }

            var parcelShippingCalculatorService = new ParcelShippingCalculatorService();
            var orderService = new OrderService(parcelShippingCalculatorService);

            double totalCostWithoutSpeedyShipping = orderService.CalculateOrder(parcelSizes, false);
            double totalCostWithSpeedyShipping = orderService.CalculateOrder(parcelSizes, true);

            const string parcelOuputDetails = "{0} parcel count: {1}, each costing ${2}";

            // Maybe move this to another service to unit test the outputted count is correct?
            Console.WriteLine(string.Format(parcelOuputDetails, "Small", parcelSizes.Count(size => size <= Constants.MAXIMUM_SMALL_PARCEL_SIZE), Constants.SMALL_PARCEL_SIZE_COST));
            Console.WriteLine(string.Format(parcelOuputDetails, "Medium", 
                parcelSizes.Count(size => size >= Constants.MINIMUM_MEDIUM_PARCEL_SIZE && size <= Constants.MAXIMUM_MEDIUM_PARCEL_SIZE),
                Constants.MEDIUM_PARCEL_SIZE_COST));
            Console.WriteLine(string.Format(parcelOuputDetails, "Large",
                parcelSizes.Count(size => size >= Constants.MINIMUM_LARGE_PARCEL_SIZE && size <= Constants.MAXIMUM_LARGE_PARCEL_SIZE),
                Constants.LARGE_PARCEL_SIZE_COST));
            Console.WriteLine(string.Format(parcelOuputDetails, "Extra Large",
                parcelSizes.Count(size => size >= Constants.MINIMUM_EXTRA_LARGE_PARCEL_SIZE),
                Constants.EXTRA_LARGE_PARCEL_SIZE_COST));

            Console.WriteLine($"Total Cost without SpeedyShipping: ${totalCostWithoutSpeedyShipping}");

            Console.WriteLine($"Total Cost with SpeedyShipping: ${totalCostWithSpeedyShipping}");

            Console.ReadLine();
        }
    }
}
