﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BiddingApp.BiddingEngine.DomainLayer.Model;
using Xunit;

namespace BiddingApp.Tests.EngineTests.DomainLayerTests.ModelTests
{
    public class CurrecyTests
    {
        // TODO: check this
        [Fact]
        public void CreateCurrencyOfferor_ShouldInstantiateCurrency()
        {
            Currency currency = new Currency();
            currency.Id = 1;
            currency.Name = "USD";

            currency.ValidateObject();
            Assert.NotNull(currency);
        }

        [Theory]
        [InlineData(-1, "USD")]
        [InlineData(-1, "")]
        [InlineData(1, " ")]
        [InlineData(1, "")]
        [InlineData(1, null)]
        public void CreateCurrencyOfferor_ShouldThrow(int id, string name)
        {
            Currency currency = new Currency
            {
                Id = id,
                Name = name
            };

            Assert.ThrowsAny<Exception>(() => currency.ValidateObject());
        }
    }
}