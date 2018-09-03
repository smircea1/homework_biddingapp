using BiddingApp.BiddingEngine.DomainData;
using BiddingApp.BiddingEngine.DomainLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiddingApp.Tests.EngineTests.DomainLayerTests.ServiceTests.MockedTables
{
    class CurrencyTable : ICurrencyTable
    {
        List<Currency> currencies = new List<Currency>();

        int index = 3;

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
            foreach (Currency currency in currencies)
            {
                if (currency.Name.Equals(name))
                    return currency;
            }
            return null;
        }

        public void InsertCurrency(Currency currency)
        {
            currency.IdCurrency = index++;
            currencies.Add(currency);
        }
    };
}
