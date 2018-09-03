using BiddingApp.BiddingEngine.DomainData;
using BiddingApp.BiddingEngine.DomainLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiddingApp.Tests.EngineTests.DomainLayerTests.ServiceTests.MockedTables
{
    class CategoryTable : ICategoryTable
    {
        List<Category> categories = new List<Category>();
        int index = 3;

        public CategoryTable()
        {
            categories.Add(new Category() { Name = "blah", IdCategory = 1 });
            categories.Add(new Category() { Name = "blahh", IdParent = 1, IdCategory = 2 });
        }

        public List<Category> FetchAllCategories()
        {
            return categories;
        }

        public Category FetchCategoryByName(string name)
        {
            foreach (Category category in categories)
            {
                if (category.Name.Equals(name))
                {
                    return category;
                }
            }

            return null;
        }

        public List<Category> FetchSubCategories(Category category)
        {
            List<Category> subcategories = new List<Category>();
            foreach (Category list_category in categories)
            {
                if (category.IdParent == category.IdCategory)
                {
                    subcategories.Add(list_category);
                }
            }

            return subcategories;
        }

        public void InsertCategory(Category category)
        {
            if (FetchCategoryByName(category.Name) != null)
            {
                return; // uniq by name
            }

            category.IdCategory = index++;
            categories.Add(category);
        }
    };
}
