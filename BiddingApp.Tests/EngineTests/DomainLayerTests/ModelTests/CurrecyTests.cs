using System;
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
        [Fact]
        public void CreateCurrencyOfferor_ShouldInstantiateCurrency()
        {
            Currency currency = new Currency();
            currency.IdCurrency = 1;
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
                IdCurrency = id,
                Name = name
            };

            Assert.ThrowsAny<Exception>(() => currency.ValidateObject());
        }

        [Fact]
        public void Equals_shouldFail()
        {
            Currency currency = new Currency
            {
                IdCurrency = 1,
                Name = "blah"
            };

            Assert.False(currency.Equals("badtype"));
        }

        [Theory]
        [InlineData(1, "USD")]
        [InlineData(31212, "GBP")]
        [InlineData(10, "LONGER")]
        [InlineData(1000, "EUR")]
        [InlineData(352, "$")]
        public void CreateCurrencyOfferor_ShouldInstantiateCUrrencyTheory(int id, string name)
        {
            Currency currency = new Currency
            {
                IdCurrency = id,
                Name = name
            };
            
            currency.ValidateObject();
            Assert.NotNull(currency);
        }
    }
}
