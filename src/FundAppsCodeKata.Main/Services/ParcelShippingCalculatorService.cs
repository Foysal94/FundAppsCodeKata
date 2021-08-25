using System;

namespace FundAppsCodeKata.Main.Services
{
    // Maybe this class and method can be static?
    public class ParcelShippingCalculatorService
    {
        public double Calculcate(int parcelSize)
        {
            // Convert to switch later
            if (parcelSize < 9)
                return 3;
            else if (parcelSize > 9 && parcelSize < 49)
                return 8;
            else if (parcelSize > 50 && parcelSize < 99)
                return 15;
            else if (parcelSize >= 100)
                return 25;
            else
                // Need to handle this somehow later, or maybe reuturn 0? Not sure.
                throw new Exception("Unable to calculate price");
        }
    }
}
