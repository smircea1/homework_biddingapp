﻿//-----------------------------------------------------------------------
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
            BiddingBroker broker = BiddingBroker.GetInstance();
            Person badPerson = new Person() { Name = null };
            Person badPerson2 = new Person() { Name = null, Phone = "07299544321" };
            Person badPerson3 = new Person() { Name = "gigica", Phone = null };
            Person goodPerson = new Person() { Name = "gigica", Phone = "07299544321" };

            broker.RegisterPerson(badPerson);
            broker.RegisterPerson(badPerson2);
            broker.RegisterPerson(badPerson3);

            broker.RegisterPerson(goodPerson);
             
            System.Console.WriteLine("app ended!");
        }
    }
}
