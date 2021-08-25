using System;
using System.Collections.Generic;
using System.Text;

namespace FundAppsCodeKata.Main.Services
{
    public interface IParcelShippingCalculatorService
    {
        double Calculcate(int parcelSize);
    }
}
