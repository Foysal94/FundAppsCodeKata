using NUnit.Framework;
using FluentAssertions;
using FundAppsCodeKata.Main.Services;
using System.Collections.Generic;
using System;

namespace FundAppsCodeKata.Main.Unit.Tests.Services
{
    [TestFixture]
    public class ParcelShippingCalculatorServiceTests
    {
        private ParcelShippingCalculatorService _parcelShippingCalculatorService;

        [SetUp]
        public void SetUp()
        {
            _parcelShippingCalculatorService = new ParcelShippingCalculatorService();
        }

        [Test]
        public void Should_Return_Correct_Price_For_Small_Parcel()
        {
            const int ExpectedPrice = 3;
            const int MinimumParcelSize = Constants.MINIMUM_SMALL_PARCEL_SIZE;
            const int MaximumParcelSize = Constants.MAXIMUM_SMALL_PARCEL_SIZE;

            var _parcelSizes = GenerateParcelSizeList(MinimumParcelSize, MaximumParcelSize);

            foreach (var parcelSize in _parcelSizes)
            {
                var actulPrice = _parcelShippingCalculatorService.Calculcate(parcelSize);
                actulPrice.Should().Be(ExpectedPrice);
            }
        }

        [Test]
        public void Should_Return_Correct_Price_For_Medium_Parcel()
        {
            const int ExpectedPrice = 8;
            const int MinimumParcelSize = Constants.MINIMUM_MEDIUM_PARCEL_SIZE;
            const int MaximumParcelSize = Constants.MAXIMUM_MEDIUM_PARCEL_SIZE;

            var _parcelSizes = GenerateParcelSizeList(MinimumParcelSize, MaximumParcelSize);

            foreach (var parcelSize in _parcelSizes)
            {
                var actulPrice = _parcelShippingCalculatorService.Calculcate(parcelSize);
                actulPrice.Should().Be(ExpectedPrice);
            }
        }

        [Test]
        public void Should_Return_Correct_Price_For_Large_Parcel()
        {
            const int ExpectedPrice = 15;
            const int MinimumParcelSize = Constants.MINIMUM_LARGE_PARCEL_SIZE;
            const int MaximumParcelSize = Constants.MAXIMUM_LARGE_PARCEL_SIZE;

            var _parcelSizes = GenerateParcelSizeList(MinimumParcelSize, MaximumParcelSize);

            foreach (var parcelSize in _parcelSizes)
            {
                var actulPrice = _parcelShippingCalculatorService.Calculcate(parcelSize);
                actulPrice.Should().Be(ExpectedPrice);
            }
        }

        [Test]
        public void Should_Return_Correct_Price_For_Extra_Large_Parcel()
        {
            const int ExpectedPrice = 25;
            const int MinimumParcelSize = Constants.MINIMUM_EXTRA_LARGE_PARCEL_SIZE;
            const int MaximumParcelSize = 10000;

            var _parcelSizes = GenerateParcelSizeList(MinimumParcelSize, MaximumParcelSize);

            foreach (var parcelSize in _parcelSizes)
            {
                var actulPrice = _parcelShippingCalculatorService.Calculcate(parcelSize);
                actulPrice.Should().Be(ExpectedPrice);
            }
        }

        private IReadOnlyCollection<int> GenerateParcelSizeList(int minimumParcelSize, int maximumParcelSize)
        {
            var _parcelSizes = new List<int>();
            int randomParcelSize;
            var random = new Random();

            for (int i = 0; i < 6; i++)
            {
                do
                {
                    // -1 and + 1 to include the minimum and maximum in the ranges
                    randomParcelSize = random.Next(minimumParcelSize - 1, maximumParcelSize + 1);
                } while (_parcelSizes.Contains(randomParcelSize));

                _parcelSizes.Add(randomParcelSize);
            }

            return _parcelSizes;
        }

    }
}
