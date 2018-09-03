using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using BiddingApp.BiddingEngine.DomainLayer.Service;
using BiddingApp.Tests.EngineTests.DomainLayerTests.ServiceModelTests;
using BiddingApp.BiddingEngine.DomainData;
using BiddingApp.BiddingEngine.DomainLayer.Model;
using Moq;
using BiddingApp.BiddingEngine.DomainLayer;

namespace BiddingApp.Tests.EngineTests.DomainLayerTests.ServiceTests
{
    public class CurrencyConverterTests
    {
        ITablesProvider tablesProvider;

        public CurrencyConverterTests()
        { 
            ICurrencyTable currencyTable = new CurrencyTable();
            Mock<ITablesProvider> table = new Mock<ITablesProvider>();
            table.Setup(x => x.GetCurrencyTable()).Returns(currencyTable);

            this.tablesProvider = table.Object;
        }

        [Fact]
        public void CurrencyConverter_ShouldCreateInstance()
        {  
            //// MOCKING USED HERE.
            Assert.NotNull(new CurrencyConverter(tablesProvider));
            Assert.NotNull(new CurrencyConverter());
        }

        [Fact]
        public void UpdateRates_ShouldIncrementsTheCurrencies()
        {
            CurrencyConverter converter = new CurrencyConverter();
            converter.CurrencyTable = tablesProvider.GetCurrencyTable();

            int initial_size = converter.AvailableCurrencies.Count;
            converter.UpdateRates();
            int actual_size = converter.AvailableCurrencies.Count;

            Assert.NotEqual(initial_size, actual_size); 
        }

        [Fact]
        public void UpdateDbCurrencies_ShouldIncrementsTheCurrenciesInDb()
        {
            ICurrencyTable currencyTable = tablesProvider.GetCurrencyTable();

            int initial_size = currencyTable.FetchAllCurrencies().Count();

            CurrencyConverter converter = new CurrencyConverter();
            converter.CurrencyTable = tablesProvider.GetCurrencyTable();

            converter.AvailableCurrencies.Add(new Currency() { Name = "dummy" });
                 
            converter.UpdateDbCurrencies();

            int actual_size = currencyTable.FetchAllCurrencies().Count();

            Assert.NotEqual(initial_size, actual_size);
        }

        [Fact]
        public void GetCurrencyByName_ShouldReturnObject()
        {
            CurrencyConverter converter = new CurrencyConverter(tablesProvider);
            Assert.NotNull(converter.GetCurrencyByName("ron"));
        }

        [Fact]
        public void GetCurrencyByName_ShouldReturnNull()
        {
            CurrencyConverter converter = new CurrencyConverter(tablesProvider);
            Assert.Null(converter.GetCurrencyByName("ronn")); 
        }

        [Theory]
        [InlineData(280, 3.3)]
        [InlineData(561, 6.6)]
        [InlineData(8415, 99)]
        public void DoExchange_ShouldConvertAllright(int expected, double value)
        {
            CurrencyConverter converter = new CurrencyConverter(tablesProvider);

            Currency eur = converter.GetCurrencyByName("eur");
            Currency usd = converter.GetCurrencyByName("usd");

            ////double value = 3.3; // eurs
            double converted_value = converter.DoExchange(eur, usd, value); // returns 2.8049999999999997
            ////int expected = 280; 

            Assert.Equal(expected, (int)(converted_value*100)); 
        }



        class CurrencyTable : ICurrencyTable
        {
            List<Currency> currencies = new List<Currency>();
            public CurrencyTable()
            {
                Currency ronCurrency = new Currency() { Name = "ron" };
                Currency eurCurrency = new Currency() { Name = "eur" };

                currencies.Add(ronCurrency);
                currencies.Add(eurCurrency);
            }

            public List<Currency> FetchAllCurrencies()
            {
                return currencies;
            }

            public Currency FetchCurrencyByName(string name)
            {
                foreach(Currency currency in currencies)
                {
                    if (currency.Name.Equals(name))
                        return currency;
                }
                return null;
            }

            public void InsertCurrency(Currency currency)
            {
                currencies.Add(currency);
            }
        };
    }
}
