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
            Category blah = new Category() { Name = "blah", IdCategory = 1 };
            Category blahh = new Category() { Name = "blahh", IdCategory = 2 };

            blah.Subcategories.Add(blahh);
            categories.Add(blah);
            categories.Add(blahh); 
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
            foreach(Category listed_category in categories)
            {
                if(listed_category.IdCategory == category.IdCategory)
                {
                    return listed_category.Subcategories;
                }
            }

            return new List<Category>();
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

        public void InsertSubCategory(int idParent, int idSon)
        {
            foreach(Category category in categories)
            {
                foreach(Category subcategory in categories)
                {
                    if(category.IdCategory == idParent && subcategory.IdCategory == idSon)
                    {
                        category.Subcategories.Add(subcategory);
                    }
                } 
            }
        }
    };
}
