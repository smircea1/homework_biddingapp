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
    using BiddingApp.BiddingEngine.DomainLayer.Model;

    /// <summary>
    /// Converts currencies
    /// </summary>
    public class CurrencyConverter
    {
        /// <summary>
        /// Does the exchange.
        /// </summary>
        /// <param name="fromCurrency">From currency.</param>
        /// <param name="toCurrency">To currency.</param>
        /// <param name="value">The value.</param>
        /// <returns>The exchanged value.</returns>
        public static double DoExchange(Currency fromCurrency, Currency toCurrency, double value)
        {
            double usd_value = value * fromCurrency.Rate;
            double result = usd_value * toCurrency.Rate;

            return result;
        }

        /// <summary>
        /// Updates the rates.
        /// Not implemented. get them from internet idk.
        /// </summary>
        public static void UpdateRates()
        {
        }

        /// <summary>
        /// Holds te current currencies
        /// </summary>
        public class CurrencyRates
        {
            /// <summary>
            /// The currencies
            /// USD TO USD
            /// EUR TO USD
            /// LEU TO USD
            /// </summary>
            private static Dictionary<string, Currency> currencies = new Dictionary<string, Currency>()
            {
                { "USD", new Currency("USD", 1.0) },
                { "Euro", new Currency("Euro", 1.16805) },
                { "Ron", new Currency("Ron", 0.251395) },
            };

            /// <summary>
            /// Gets the currency by its name.
            /// </summary>
            /// <param name="name">The name.</param>
            /// <returns>The currency object by its name.</returns>
            public static Currency GetCurrencyByName(string name)
            {
                return currencies[name];
            }
        }
    }
}
