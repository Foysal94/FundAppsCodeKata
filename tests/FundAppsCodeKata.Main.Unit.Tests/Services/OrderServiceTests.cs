using NUnit.Framework;
using FluentAssertions;
using FundAppsCodeKata.Main.Services;
using System.Collections.Generic;
using System;
using Moq;

namespace FundAppsCodeKata.Main.Unit.Tests.Services
{
    [TestFixture]
    class OrderServiceTests
    {
        private OrderService _orderService;
        private Mock<IParcelShippingCalculatorService> _parcelShippingCalculatorServiceMock;

        [SetUp]
        public void SetUp()
        {
            _parcelShippingCalculatorServiceMock = new Mock<IParcelShippingCalculatorService>();
            _orderService = new OrderService(_parcelShippingCalculatorServiceMock.Object);
        }

        [TestCase(true, 6)]
        [TestCase(false, 3)]
        public void Should_Correctly_Process_Order_With_IsSpeedyShipping_Option(bool isSpeedyShipping, double expectedPrice)
        {
            // Force it to no matter what parcel size always return the cost value of 1
            _parcelShippingCalculatorServiceMock
                .Setup(parcelShippingCalculator => parcelShippingCalculator.Calculcate(It.IsAny<int>()))
                .Returns(1);

            // Where isSpeedyShipping is false, should be $3 as it always returns cost of 1 above
            // Where it is set to true, should be $6 as doubled
            var actualPrice = _orderService.CalculateOrder(new int[3] { 4, 22, 77 }, isSpeedyShipping);

            actualPrice.Should().Be(expectedPrice);
        }


    }
}
