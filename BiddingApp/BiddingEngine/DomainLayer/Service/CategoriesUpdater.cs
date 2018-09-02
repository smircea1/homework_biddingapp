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
        /// Gets all available categories.
        /// </summary>
        /// <returns>returns all available categories</returns>
        public static List<Category> GetAllAvailableCategories()
        {
            return domainDataStorage.CategoryTable.FetchAllCategories();
        }

        /// <summary>
        /// Updates the categories.
        /// </summary>
        public static void UpdateCategories()
        {
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

            Category electronics = new Category { Name = "Electronics" };
            //// ELECTRONICS
            try
            {
                domainDataStorage.CategoryTable.InsertCategory(electronics);
                electronics = domainDataStorage.CategoryTable.FetchCategoryByName(electronics.Name);
            } 
            catch (Exception)
            {
                electronics = domainDataStorage.CategoryTable.FetchCategoryByName(electronics.Name);
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

            Category home = new Category { Name = "Home" };
            //// HOME
            try
            {
                domainDataStorage.CategoryTable.InsertCategory(home);
                home = domainDataStorage.CategoryTable.FetchCategoryByName(home.Name);
            } 
            catch (Exception)
            {
                home = domainDataStorage.CategoryTable.FetchCategoryByName(home.Name);
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
            foreach (Category category in list)
            {
                try
                {
                    domainDataStorage.CategoryTable.InsertCategory(category);
                } 
                catch (Exception e)
                {
                }
            }
        }
    }
}
