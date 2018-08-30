//-----------------------------------------------------------------------
// <copyright file="Program.cs" company="Transilvania University of Brasov"> 
//     Copyright (c) Transilvania University of Brasov. All rights reserved. 
// </copyright> 
// <author>Stoica Mircea</author> 
//-----------------------------------------------------------------------
namespace BiddingApp
{
    using System.Data;
    using BiddingApp.BiddingEngine.DomainData;
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
            string databaseUrl = "localhost";
            string databaseName = "biddingdb";
            string databaseUsername = "root";
            string databasePassword = "root";
            string connstring = string.Format("SERVER={0}; DATABASE={1}; UID={2}; password={3}; SslMode=none", databaseUrl, databaseName, databaseUsername, databasePassword);

            MySqlConnection conn = new MySqlConnection(connstring);  

            Person.Builder personBuilder = new Person.Builder();
            personBuilder.SetName("aname");
            personBuilder.SetIsBanned(true); 
             
            IPersonTable persons = conn.As<IPersonTable>(); 
            persons.InsertPerson(personBuilder.Build());

            System.Console.WriteLine("inserted!");
        }
    }
}
