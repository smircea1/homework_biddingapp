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
            ////try
            ////{
            ////    BiddingBroker broker = new BiddingBroker(DomainDataStorage.GetInstance()); 
            ////    Person goodPerson = new Person() { Name = "gigica", Phone = "07299544321" };
                 
            ////    goodPerson = broker.RegisterPerson(goodPerson);

            ////    CurrencyConverter converter = broker.GetCurrencyConverter();

            ////    Currency ronCurrency = converter.GetCurrencyByName("ron"); 
                 
            ////    Product goodProduct = new Product() { Name = "Mouse", Description = "Logitech" };

            ////    goodProduct.Category = broker.GetCategoryByName("PC Periferics");
                 
            ////    DateTime startDate = DateTime.Now;
            ////    DateTime endDate = DateTime.Now.AddDays(1);

            ////    double startValue = 123.3;  

            ////    Auction goodAuction = new Auction() { StartDate = startDate, EndDate = endDate, StartValue = startValue };
            ////    goodAuction.Product = goodProduct;
            ////    goodAuction.Currency = ronCurrency;

            ////    Auction registeredAuction = broker.RegisterAuction(goodPerson, goodAuction);

            ////    //// OK TILL HERE !
            ////    Bid bid = new Bid() { Auction = goodAuction, Date = DateTime.Now, Currency = goodAuction.Currency, Value = 124 };

            ////    broker.RegisterBid(goodPerson, bid, registeredAuction);
            ////}
            ////catch (Exception e)
            ////{ 
            ////} 

            System.Console.WriteLine("app ended!");
        }
    }
}
