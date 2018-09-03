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
            Assert.NotNull(new CurrencyConverter(tablesProvider)); 
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
