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
            BiddingBroker broker = new BiddingBroker(DomainDataStorage.GetInstance());
            Person badPerson = new Person() { Name = null };
            Person badPerson2 = new Person() { Name = null, Phone = "07299544321" };
            Person badPerson3 = new Person() { Name = "gigica", Phone = null };
            Person goodPerson = new Person() { Name = "gigica", Phone = "07299544321" };

            broker.RegisterPerson(badPerson);
            broker.RegisterPerson(badPerson2);
            broker.RegisterPerson(badPerson3);

            broker.RegisterPerson(goodPerson);

            CurrencyConverter converter = broker.GetCurrencyConverter();
            Currency ronCurrency = converter.GetCurrencyByName("ron");
            Currency eurCurrency = converter.GetCurrencyByName("eur");

            double rons = 54;
            double eurs = converter.DoExchange(ronCurrency, eurCurrency, rons);

            Product badProduct = new Product() { Name = null };
            Product goodProduct = new Product() { Name = "Mouse" , Description = "Logitech"};

            goodProduct.Category = broker.GetCategoryByName("PC Periferics");


            DateTime startDate = DateTime.Now;
            DateTime endDate = DateTime.Now.AddSeconds(10);

            double startValue = 123.3;

            Auction badAuction = new Auction() { EndDate = endDate, StartDate = startDate, StartValue = startValue}; 
            badAuction.Product = badProduct;

            Auction badAuction2 = new Auction() { EndDate = startDate, StartDate = endDate, StartValue = startValue };
            badAuction2.Product = goodProduct;
             
            Auction goodAuction = new Auction() { EndDate = startDate, StartDate = endDate, StartValue = startValue };
            goodAuction.Product = goodProduct;
            goodAuction.Currency = eurCurrency;

            broker.RegisterAuction(goodPerson, badAuction);
            broker.RegisterAuction(goodPerson, goodAuction);


            

            System.Console.WriteLine("app ended!");
        }
    }
}
