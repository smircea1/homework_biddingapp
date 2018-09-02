using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BiddingApp.BiddingEngine.DomainLayer.Model;
using BiddingApp.BiddingEngine.DomainLayer.Service; 
using Xunit;

namespace BiddingApp.Tests.EngineTests.DomainLayerTests.ServiceModelTests
{
    public class PersonOfferorServiceTests
    {
        [Fact]
        public void CreatePersonOfferrorService_ShouldInstantiatePersonOfferorService()
        {
            var personOfferorService = InstanceHelper.GetPersonOfferorService(null);
            Assert.NotNull(personOfferorService);
        }

        [Fact]
        public void DidPersonHitMaxCategoryListLimit_ShoulNotHitLimit()
        {
            var personOfferorService = InstanceHelper.GetPersonOfferorService(null);
            var offeror = personOfferorService.Offeror;
            List<Auction> auctions = new List<Auction>();
            auctions.Add(InstanceHelper.GetAuction());

            var result = personOfferorService.DidPersonHitMaxCategoryListLimit(offeror, InstanceHelper.GetCategory(), auctions);
            Assert.False(result);
        }

        [Fact]
        public void DidPersonHitMaxListLimit_ShoulNotHitLimit()
        {
            var personOfferorService = InstanceHelper.GetPersonOfferorService(null);
            var offeror = personOfferorService.Offeror;
            List<Auction> auctions = new List<Auction>();
            auctions.Add(InstanceHelper.GetAuction());

            var result = personOfferorService.DidPersonHitMaxListLimit(offeror, auctions);
            Assert.False(result);
        }
    }
}
