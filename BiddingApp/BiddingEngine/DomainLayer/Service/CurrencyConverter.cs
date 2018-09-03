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
        /// Initializes a new instance of the <see cref="CurrencyConverter"/> class.
        /// </summary>
        public CurrencyConverter()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CurrencyConverter"/> class.
        /// </summary>
        /// <param name="tablesProvider">The tables provider.</param>
        public CurrencyConverter(ITablesProvider tablesProvider)
        {
            this.CurrencyTable = tablesProvider.GetCurrencyTable();
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
        public Dictionary<string, double> CurrenciesRates { get; private set; }

        /// <summary>
        /// Gets or sets the currency table.
        /// </summary>
        /// <value>
        /// The currency table.
        /// </value>
        private ICurrencyTable CurrencyTable { get; set; }
         
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
            double usd_value = value * this.CurrenciesRates[fromCurrency.Name];
            result = usd_value * this.CurrenciesRates[toCurrency.Name];

            return result;
        }

        /// <summary>
        /// Updates the rates.
        /// Not implemented. get them from internet idk.
        /// </summary>
        public void UpdateRates()
        {
            this.AvailableCurrencies = new List<Currency>();
            this.AvailableCurrencies.Add(new Currency() { Name = "usd" });
            this.AvailableCurrencies.Add(new Currency() { Name = "eur" });
            this.AvailableCurrencies.Add(new Currency() { Name = "ron" }); 

            this.CurrenciesRates = new Dictionary<string, double>()
            {
                { "usd", 1.0 },
                { "eur", 0.85 },
                { "ron", 0.25 },
            }; 
        }

        /// <summary>
        /// Gets the name of the currency by.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns>
        /// The found currency or null
        /// </returns>
        public Currency GetCurrencyByName(string name)
        {
            string nameLower = name.ToLower();

            return this.CurrencyTable.FetchCurrencyByName(name); 
        }

        /// <summary>
        /// Updates the database currencies.
        /// </summary>
        private void UpdateDbCurrencies()
        {
            List<Currency> currencies = this.CurrencyTable.FetchAllCurrencies();

            foreach (Currency currency in this.AvailableCurrencies)
            {
                if (!currencies.Contains(currency))
                {
                    try
                    {
                        this.CurrencyTable.InsertCurrency(currency);
                    }
#pragma warning disable CS0168 // The variable 'e' is declared but never used
                    catch (Exception e)
#pragma warning restore CS0168 // The variable 'e' is declared but never used
                    {
                        // just ignore that they already exist and trigger unique exception.
                    }
                }
            }
        }
    }
}
