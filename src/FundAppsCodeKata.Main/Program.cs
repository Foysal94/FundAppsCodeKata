using System;
using System.Collections.Generic;

namespace FundAppsCodeKata.Main
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("How many parcels?");
            var parcelCount = int.Parse(Console.ReadLine());

            IList<int> parcelSizeLists = new List<int>();

            for(int i = 1; i < parcelCount + 1; i++)
            {
                Console.Write($"What is the size of parcel {i}:");
                parcelSizeLists.Add(int.Parse(Console.ReadLine()));
            }
        }
    }
}
