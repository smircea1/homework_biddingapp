//-----------------------------------------------------------------------
// <copyright file="ICurrencyTable.cs" company="Transilvania University of Brasov"> 
//     Copyright (c) Transilvania University of Brasov. All rights reserved. 
// </copyright> 
// <author>Stoica Mircea</author> 
//-----------------------------------------------------------------------  

namespace BiddingApp.BiddingEngine.DomainData
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using BiddingApp.BiddingEngine.DomainLayer.Model;

    /// <summary>
    /// the currency table.
    /// </summary>
    public interface ICurrencyTable
    {
        /// <summary>
        /// Fetches all currencies.
        /// </summary>
        /// <returns>all available currencies.</returns>
        List<Currency> FetchAllCurrencies();
    }
}
