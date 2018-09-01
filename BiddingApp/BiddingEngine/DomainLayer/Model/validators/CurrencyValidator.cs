﻿//-----------------------------------------------------------------------
// <copyright file="CurrencyValidator.cs" company="Transilvania University of Brasov"> 
//     Copyright (c) Transilvania University of Brasov. All rights reserved. 
// </copyright> 
// <author>Stoica Mircea</author> 
//-----------------------------------------------------------------------  

namespace BiddingApp.BiddingEngine.DomainLayer.Model
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// currency validator
    /// </summary>
    public static class CurrencyValidator
    {
        /// <summary>
        /// Validates the object.
        /// </summary>
        /// <param name="currency">The currency.</param>
        /// <exception cref="Exception">Name is required</exception>
        public static void ValidateObject(this Currency currency)
        {
            if (currency.Name == null)
            {
                throw new Exception("Name is required!");
            }
        }
    }
}