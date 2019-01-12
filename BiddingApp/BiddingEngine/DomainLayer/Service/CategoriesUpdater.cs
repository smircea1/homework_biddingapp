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
    /// instead of adding them directly into the database.
    /// </summary>
    public class CategoriesUpdater
    {
        /// <summary>
        /// Gets or sets the tables provider.
        /// </summary>
        /// <value>
        /// The tables provider.
        /// </value>
        public static ITablesProvider TablesProvider { get; set; }

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
        /// <exception cref="Exception">Unable to fetch electronics category item.</exception>
        /// <exception cref="System.Exception">Unable to fetch electronics category item.</exception>
        public static void UpdateElectronics()
        {
            List<Category> electronicCategories = new List<Category>();

            ICategoryTable categoryTable = TablesProvider.GetCategoryTable();

            Category electronics = new Category { Name = "Electronics" };

            List<Category> elec_sub = new List<Category>()
            {
                { new Category { Name = "Laptops" } },
                { new Category { Name = "TVs" } },
                { new Category { Name = "CellPhones" } },
                { new Category { Name = "PC Periferics" } },
            };

            electronics.Subcategories = elec_sub;

            electronicCategories.Add(electronics);
            electronicCategories.AddRange(elec_sub);

            InsertCategoryList(electronicCategories);
        }

        /// <summary>
        /// Updates the home.
        /// </summary>
        /// <exception cref="Exception">Unable to fetch home category item.</exception>
        public static void UpdateHome()
        { 
            ICategoryTable categoryTable = TablesProvider.GetCategoryTable();

            Category home = new Category { Name = "Home" };

            List<Category> home_sub = new List<Category>()
            {
                { new Category { Name = "Chairs" } },
                { new Category { Name = "Tables" } },
                { new Category { Name = "Bolts" } },
            };

            home.Subcategories = home_sub;

            List<Category> homeCategories = new List<Category>();

            homeCategories.Add(home);
            homeCategories.AddRange(home_sub);

            InsertCategoryList(homeCategories);
        }

        /// <summary>
        /// Inserts the category list.
        /// </summary>
        /// <param name="list">The list.</param>
        public static void InsertCategoryList(List<Category> list)
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

            foreach (Category category in list)
            {
                try
                {
                    Category fetched_with_id = categoryTable.FetchCategoryByName(category.Name);
                    Category fetched_sub_with_id = categoryTable.FetchCategoryByName(category.Name);
                    foreach (Category sub_category in category.Subcategories)
                    {
                        categoryTable.InsertSubCategory(fetched_with_id.IdCategory, fetched_sub_with_id.IdCategory);
                    }
                } 
                catch (Exception)
                {
                }
            }
        }
    }
}
