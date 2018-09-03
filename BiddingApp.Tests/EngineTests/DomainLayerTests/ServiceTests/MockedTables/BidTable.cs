using BiddingApp.BiddingEngine.DomainData;
using BiddingApp.BiddingEngine.DomainLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiddingApp.Tests.EngineTests.DomainLayerTests.ServiceTests.MockedTables
{
    class BidTable : IBidTable
    {
        public List<Bid> list = new List<Bid>();

        int index = 0;

        public BidTable()
        {

        }

        public Bid FetchBidByIdBid(int idBid)
        {
            foreach(Bid bid in list)
            {
                if(bid.IdBid == idBid)
                {
                    return bid;
                }
            }

            return null;
        }

        public List<Bid> FetchAuctionBidds(Auction auction)
        {
            List<Bid> auction_bidds = new List<Bid>();
            foreach(Bid bid in list)
            {
                if(bid.Auction.IdAuction == auction.IdAuction)
                {
                    auction_bidds.Add(bid);
                }
            }

            return auction_bidds;
        }

        public Bid FetchAuctionHighestBid(Auction auction)
        {
            Bid highest = null;

            foreach(Bid bid in list)
            {
                if(bid.Auction.IdAuction == auction.IdAuction)
                {
                    if(highest == null)
                    {
                        highest = bid;
                    }
                    else
                    {
                        if(highest.Value < bid.Value)
                        {
                            highest = bid;
                        }
                    }
                }
            }

            return highest;
        }

        public void InsertBid(int idBidder, int idAuction, int idCurrency, Bid bid)
        {
            bid.IdBid = index++;
            list.Add(bid);
        }
    }
}
