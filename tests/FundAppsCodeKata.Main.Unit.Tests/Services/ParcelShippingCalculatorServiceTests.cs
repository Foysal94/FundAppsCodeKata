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
            const int MinimumParcelSize = 1;
            const int MaximumParcelSize = 9;

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
            const int MinimumParcelSize = 10;
            const int MaximumParcelSize = 49;

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
            const int MinimumParcelSize = 50;
            const int MaximumParcelSize = 100;

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
            const int MinimumParcelSize = 100;
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
                    randomParcelSize = random.Next(minimumParcelSize, maximumParcelSize);
                } while (_parcelSizes.Contains(randomParcelSize));

                _parcelSizes.Add(randomParcelSize);
            }

            return _parcelSizes;
        }

    }
}
