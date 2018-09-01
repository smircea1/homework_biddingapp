//-----------------------------------------------------------------------
// <copyright file="Program.cs" company="Transilvania University of Brasov"> 
//     Copyright (c) Transilvania University of Brasov. All rights reserved. 
// </copyright> 
// <author>Stoica Mircea</author> 
//-----------------------------------------------------------------------
namespace BiddingApp
{
    using System;
    using System.Configuration;
    using System.Data;
    using BiddingApp.BiddingEngine.DomainData;
    using BiddingApp.BiddingEngine.DomainLayer;
    using BiddingApp.BiddingEngine.DomainLayer.Model;
    using Insight.Database;
    using MySql.Data.MySqlClient;

    /// <summary>
    /// The main method holder class.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Defines the entry point of the application.
        /// </summary>
        /// <param name="args">The arguments.</param>
        public static void Main(string[] args)
        { 
            string connectionString = ConfigurationManager.ConnectionStrings["MySQL"].ConnectionString; 
            MySqlConnection conn = new MySqlConnection(connectionString);
             
            Currency currencyA = new Currency(null);
            currencyA.ValidateObject();

            double valueA = 234.2;
            Currency currencyB = new Currency("ron");
             
            ////double converted_value = CurrencyConverter.DoExchange(currencyA, currencyB, valueA);

            ////IAuctionTable auctionTable = DomainDataStorage.GetInstance().AuctionTable;
            ////auctionTable.InsertAuction(auctionA);

            System.Console.WriteLine("app ended!");
        }
    }
}
