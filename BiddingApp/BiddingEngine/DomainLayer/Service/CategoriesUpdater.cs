//-----------------------------------------------------------------------
// <copyright file="CategoriesUpdater.cs" company="Transilvania University of Brasov"> 
//     Copyright (c) Transilvania University of Brasov. All rights reserved. 
// </copyright> 
// <author>Stoica Mircea</author> 
//-----------------------------------------------------------------------

namespace BiddingApp.BiddingEngine.DomainLayer.Service
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using BiddingApp.BiddingEngine.DomainData;
    using BiddingApp.BiddingEngine.DomainLayer.Model;

    /// <summary>
    /// This is intended in order if you need to add categories directly from a new build
    /// instead of adding them directly into the db.
    /// </summary>
    public class CategoriesUpdater
    {
        /// <summary>
        /// The domain data storage
        /// </summary>
        private static DomainDataStorage domainDataStorage = DomainDataStorage.GetInstance();

        /// <summary>
        /// Gets or sets the tables provider.
        /// </summary>
        /// <value>
        /// The tables provider.
        /// </value>
        public static ITablesProvider TablesProvider { internal get; set; }

        /// <summary>
        /// Gets all available categories.
        /// </summary>
        /// <returns>returns all available categories</returns>
        public static List<Category> GetAllAvailableCategories()
        {
            return TablesProvider.GetCategoryTable().FetchAllCategories();
        }

        /// <summary>
        /// Updates the categories.
        /// </summary>
        /// <param name="tablesProvider">The tables provider.</param>
        public static void UpdateCategories(ITablesProvider tablesProvider)
        {
            TablesProvider = tablesProvider;
            try
            {
                UpdateElectronics();
                UpdateHome();
            } 
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// Updates the electronics.
        /// </summary>
        /// <exception cref="System.Exception">Unable to fetch electronics category item.</exception>
        private static void UpdateElectronics()
        {
            List<Category> electronicCategories = new List<Category>();

            ICategoryTable categoryTable = TablesProvider.GetCategoryTable();

            Category electronics = new Category { Name = "Electronics" };
            //// ELECTRONICS
            try
            {
                categoryTable.InsertCategory(electronics);
                electronics = categoryTable.FetchCategoryByName(electronics.Name);
            } 
            catch (Exception)
            {
                electronics = categoryTable.FetchCategoryByName(electronics.Name);
            }

            if (electronics == null)
            {
                throw new Exception("Unable to fetch electronics category item.");
            }

            electronicCategories.Add(new Category { Name = "Laptops", IdParent = electronics.IdCategory });
            electronicCategories.Add(new Category { Name = "TVs", IdParent = electronics.IdCategory });
            electronicCategories.Add(new Category { Name = "CellPhones", IdParent = electronics.IdCategory });
            electronicCategories.Add(new Category { Name = "PC Periferics", IdParent = electronics.IdCategory });

            InsertCategoryList(electronicCategories);
        }

        /// <summary>
        /// Updates the home.
        /// </summary>
        private static void UpdateHome()
        {
            List<Category> homeCategories = new List<Category>();

            ICategoryTable categoryTable = TablesProvider.GetCategoryTable();

            Category home = new Category { Name = "Home" };
            //// HOME
            try
            {
                categoryTable.InsertCategory(home);
                home = categoryTable.FetchCategoryByName(home.Name);
            } 
            catch (Exception)
            {
                home = categoryTable.FetchCategoryByName(home.Name);
            }

            if (home == null)
            {
                throw new Exception("Unable to fetch home category item.");
            }

            homeCategories.Add(new Category { Name = "Chairs", IdParent = home.IdCategory });
            homeCategories.Add(new Category { Name = "Tables", IdParent = home.IdCategory });
            homeCategories.Add(new Category { Name = "Bolts", IdParent = home.IdCategory });

            InsertCategoryList(homeCategories);
        }

        /// <summary>
        /// Inserts the category list.
        /// </summary>
        /// <param name="list">The list.</param>
        private static void InsertCategoryList(List<Category> list)
        {
            ICategoryTable categoryTable = TablesProvider.GetCategoryTable();

            foreach (Category category in list)
            {
                try
                {
                    categoryTable.InsertCategory(category);
                } 
                catch (Exception)
                {
                }
            }
        }
    }
}
