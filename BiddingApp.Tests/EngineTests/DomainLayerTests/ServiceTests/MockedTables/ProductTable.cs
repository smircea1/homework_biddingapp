using BiddingApp.BiddingEngine.DomainData;
using BiddingApp.BiddingEngine.DomainLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiddingApp.Tests.EngineTests.DomainLayerTests.ServiceTests.MockedTables
{
    class ProductTable : IProductTable
    {
        List<Product> list = new List<Product>();
        int index = 0;

        public List<Product> FetchAllProducts()
        {
            return list;
        }

        public Product FetchProductByAllAttributes(int idCategory, Product product)
        {
            foreach(Product inlist in list)
            {
                if (inlist.Name.Equals(product.Name) && inlist.Description.Equals(product.Description))
                {
                    return inlist;
                }
            }

            return null;
        } 

        public void InsertProduct(int idCategory, Product product)
        {
            Product searched = FetchProductByAllAttributes(idCategory, product);
            if(searched != null)
            {
                return;
            }

            product.IdProduct = index++;
            list.Add(product);
        }
    }
}
