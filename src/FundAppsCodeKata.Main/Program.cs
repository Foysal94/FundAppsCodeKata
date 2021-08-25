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

            IList<int> parcelSizes = new List<int>();

            for(int i = 1; i < parcelCount + 1; i++)
            {
                Console.Write($"What is the size(cm) of parcel {i}:");
                parcelSizes.Add(int.Parse(Console.ReadLine()));
            }

            double totalCost = 0;
            var parcelShippingCalculatorService = new ParcelShippingCalculatorService();
            foreach(var parcelSize in parcelSizes)
            {
                totalCost = totalCost + parcelShippingCalculatorService.Calculcate(parcelSize);
            }

            // Maybe move this to another service to unit test the outputted count is correct?
            Console.WriteLine($"Total Cost: £{totalCost}");
            Console.WriteLine($"Small parcel count: {parcelSizes.Count(size => size <= Constants.MAXIMUM_SMALL_PARCEL_SIZE)}");
            Console.WriteLine($"Medium parcel count: {parcelSizes.Count(size => size >= Constants.MINIMUM_MEDIUM_PARCEL_SIZE && size <= Constants.MAXIMUM_MEDIUM_PARCEL_SIZE)}");
            Console.WriteLine($"Large parcel count: {parcelSizes.Count(size => size >= Constants.MINIMUM_LARGE_PARCEL_SIZE && size <= Constants.MAXIMUM_LARGE_PARCEL_SIZE)}");
            Console.WriteLine($"Extra large parcel count: {parcelSizes.Count(size => size >= Constants.MINIMUM_EXTRA_LARGE_PARCEL_SIZE)}");

            Console.ReadLine();
        }
    }
}
