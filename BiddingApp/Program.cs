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

            Person.Builder personBuilder = new Person.Builder();
            personBuilder.SetId(16);
            personBuilder.SetName("aname");
            personBuilder.SetIsBanned(true);
             
            Person person = personBuilder.Build(); 

            Product.Builder product_builder = new Product.Builder();
            product_builder.SetName("AProduct");
            product_builder.AddCategory(new Category("Food"));
            product_builder.SetDescription("big_description");

            Product productA = product_builder.Build();

            DateTime startDate = DateTime.Now.AddSeconds(5);
            DateTime endDate = DateTime.Now.AddSeconds(8);

            Currency usd_currency = CurrencyConverter.CurrencyRates.GetCurrencyByName("USD");

            Money starting_money = new Money(usd_currency, 20);

            Auction.Builder auction_builder = new Auction.Builder();
            auction_builder.SetOwner(person.Id);
            auction_builder.SetStartDate(startDate);
            auction_builder.SetEndDate(endDate);
            auction_builder.SetProduct(productA);
            auction_builder.SetStartingMoney(starting_money);

            Auction auctionA = auction_builder.Build();

            IAuctionTable auctionTable = DomainDataStorage.GetInstance().AuctionTable;
            auctionTable.InsertAuction(auctionA);

            System.Console.WriteLine("inserted!");
        }
    }
}
