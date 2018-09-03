using BiddingApp.BiddingEngine.DomainData;
using BiddingApp.BiddingEngine.DomainLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiddingApp.Tests.EngineTests.DomainLayerTests.ServiceTests.MockedTables
{
    class AuctionsTable : IAuctionTable
    {
        List<Auction> list = new List<Auction>();

        int index = 0;

        public List<Auction> FetchAllAuctions()
        {
            return list;
        }

        public Auction FetchAuctionByIds(int idOfferor, int idProduct)
        {
            foreach(Auction auction in list)
            {
                if(auction.PersonOfferor.IdOfferor == idOfferor && auction.Product.IdProduct == idProduct)
                {
                    return auction;
                }
            }

            return null;
        }

        public List<Auction> FetchOfferorAuctions(PersonOfferorTable offeror)
        {
            List<Auction> auctions = new List<Auction>();
            foreach(Auction auction in list)
            {
                if(auction.PersonOfferor.IdOfferor == offeror.IdOfferor)
                {
                    auctions.Add(auction);
                }
            }
            return auctions;
        }

        public List<Auction> FetchOfferorAuctionsByCategory(PersonOfferorTable offerer, Category category)
        {
            List<Auction> auctions = new List<Auction>();
            foreach (Auction auction in list)
            {
                if(auction.PersonOfferor.IdOfferor == offerer.IdOfferor && auction.Product.Category.Name.Equals(category.Name))
                {
                    auctions.Add(auction);
                }
            }

            return auctions;
        }

        public void InsertAuction(int idOfferor, int idProduct, int idCurrency, Auction insertauction)
        {
            foreach(Auction auction in list)
            {
                if(auction.PersonOfferor.IdOfferor == idOfferor && auction.Product.IdProduct == idProduct)
                {
                    return;
                }
            }
            insertauction.IdAuction = index++;
            list.Add(insertauction);
        }

        public void UpdateAuction(Auction toupdate)
        {
            Auction found = null;
            foreach (Auction auction in list)
            {
                if (auction.IdAuction == toupdate.IdAuction)
                {
                    found = auction;
                    break;
                }
            }

            if(found == null)
            {
                return;
            }

            found.Product = toupdate.Product;
            found.StartDate = toupdate.StartDate;
            found.EndDate = toupdate.EndDate;
            found.PersonOfferor = toupdate.PersonOfferor;
            found.StartValue = toupdate.StartValue; 
        }
    }
}
