using System;

namespace FundAppsCodeKata.Main.Services
{
    // Maybe this class and method can be static?
    public class ParcelShippingCalculatorService
    {
        public double Calculcate(int parcelSize)
        {
            // Convert to switch later

            // Small parcel
            if (parcelSize < Constants.MAXIMUM_SMALL_PARCEL_SIZE)
                return 3;
            // Medium parcel
            else if (parcelSize > Constants.MINIMUM_MEDIUM_PARCEL_SIZE && parcelSize < Constants.MAXIMUM_MEDIUM_PARCEL_SIZE)
                return 8;
            // Large Parcel
            else if (parcelSize > Constants.MINIMUM_LARGE_PARCEL_SIZE && parcelSize < Constants.MAXIMUM_LARGE_PARCEL_SIZE)
                return 15;
            // Extra Large Parcel
            else if (parcelSize >= Constants.MINIMUM_EXTRA_LARGE_PARCEL_SIZE)
                return 25;
            else
                // Need to handle this somehow later, or maybe reuturn 0? Not sure.
                throw new Exception("Unable to calculate price");
        }
    }
}
