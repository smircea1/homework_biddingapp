using BiddingApp.BiddingEngine.DomainData;
using BiddingApp.BiddingEngine.DomainLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiddingApp.Tests.EngineTests.DomainLayerTests.ServiceTests.MockedTables
{
    class PersonBidderTable : IPersonBidderTable
    {
        List<PersonBidder> list = new List<PersonBidder>();

        int index = 1;

        IBidTable bidTable;

        public PersonBidderTable(IBidTable bidTable)
        {
            this.bidTable = bidTable;
        }

        public PersonBidder FetchPersonBidderByIdPerson(int idPerson)
        {
            foreach(PersonBidder bidder in list){
                if(bidder.Person.IdPerson == idPerson)
                {
                    return bidder;
                }
            }
            return null;
        }

        public PersonBidder FetchPersonByIdBid(int idBid)
        {
            Bid bid = bidTable.FetchBidByIdBid(idBid);
            if(bid == null)
            {
                return null;
            }
            return bid.PersonBidder; 
        }

        public void InsertPersonBidder(int idPerson, PersonBidder personBidder)
        {
            personBidder.IdBidder = index++;
            list.Add(personBidder);
        }
    }
}
