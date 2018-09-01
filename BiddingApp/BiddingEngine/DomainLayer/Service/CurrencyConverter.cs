//-----------------------------------------------------------------------
// <copyright file="CurrencyConverter.cs" company="Transilvania University of Brasov"> 
//     Copyright (c) Transilvania University of Brasov. All rights reserved. 
// </copyright> 
// <author>Stoica Mircea</author> 
//-----------------------------------------------------------------------   
namespace BiddingApp.BiddingEngine.DomainLayer
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using BiddingApp.BiddingEngine.DomainData;
    using BiddingApp.BiddingEngine.DomainLayer.Model;

    /// <summary>
    /// Converts currencies
    /// </summary>
    public class CurrencyConverter
    {
        /// <summary>
        /// The currency table
        /// </summary>
        private static ICurrencyTable currencyTable;

        /// <summary>
        /// The converter
        /// </summary>
        private static CurrencyConverter instance;

        /// <summary>
        /// Prevents a default instance of the <see cref="CurrencyConverter"/> class from being created.
        /// </summary>
        private CurrencyConverter()
        {
            currencyTable = DomainDataStorage.GetInstance().CurrencyTable;
            this.UpdateRates();
            this.UpdateDbCurrencies();
        }

        /// <summary>
        /// Gets the available currencies.
        /// </summary>
        /// <value>
        /// The available currencies.
        /// </value>
        public List<Currency> AvailableCurrencies { get; private set; }

        /// <summary>
        /// Gets the currencies rates.
        /// </summary>
        /// <value>
        /// The currencies rates.
        /// </value>
        public Dictionary<Currency, double> CurrenciesRates { get; private set; }

        /// <summary>
        /// Gets the instance.
        /// </summary>
        /// <returns>the instance</returns>
        public static CurrencyConverter GetInstance()
        {
            if (instance == null)
            {
                instance = new CurrencyConverter();
            }

            return instance;
        }

        /// <summary>
        /// Does the exchange.
        /// </summary>
        /// <param name="fromCurrency">From currency.</param>
        /// <param name="toCurrency">To currency.</param>
        /// <param name="value">The value.</param>
        /// <returns>The exchanged value.</returns>
        public double DoExchange(Currency fromCurrency, Currency toCurrency, double value)
        {
            double result = 0;
            //// converts from X to USD then USD to Y
            double usd_value = value * this.CurrenciesRates[fromCurrency];
            result = usd_value * this.CurrenciesRates[toCurrency];

            return result;
        }

        /// <summary>
        /// Updates the rates.
        /// Not implemented. get them from internet idk.
        /// </summary>
        public void UpdateRates()
        {
            this.CurrenciesRates = new Dictionary<Currency, double>()
            {
                { new Currency() { Name = "usd" }, 1.0 },
                { new Currency() { Name = "eur" }, 0.85 },
                { new Currency() { Name = "ron" }, 0.25 },
            };

            this.AvailableCurrencies = new List<Currency>(this.CurrenciesRates.Keys);
        }

        /// <summary>
        /// Gets the name of the currency by.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns>The found currency or null</returns>
        public Currency GetCurrencyByName(string name)
        {
            string nameLower = name.ToLower();

            foreach (Currency currency in this.AvailableCurrencies)
            {
                if (currency.Name.Equals(nameLower))
                {
                    return currency;
                }
            }

            return null;
        }

        /// <summary>
        /// Updates the database currencies.
        /// </summary>
        private void UpdateDbCurrencies()
        {
            List<Currency> currencies = currencyTable.FetchAllCurrencies();

            foreach (Currency currency in this.AvailableCurrencies)
            {
                if (!currencies.Contains(currency))
                {
                    currency.Id = currencyTable.InsertCurrency(currency);
                }
            }
        }
    }
}
