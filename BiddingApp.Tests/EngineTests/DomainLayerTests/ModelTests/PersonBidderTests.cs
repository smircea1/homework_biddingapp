using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using BiddingApp.BiddingEngine.DomainLayer.Model;

namespace BiddingApp.Tests.EngineTests.DomainLayerTests.ModelTests
{
    public class PersonBidderTests
    {
        [Fact]
        public void CreatePersonBidder_ShouldInstantiatePersonBidder()
        {
            Person person = new Person();
            var personBidder = new PersonBidder();
            personBidder.Person = person;

            personBidder.ValidateObject();
            Assert.NotNull(personBidder);
        }

        [Fact]
        public void CreatePersonBidder_ShouldThrow()
        {
            var personBidder = new PersonBidder();
            personBidder.Person = null;

            Assert.ThrowsAny<Exception>(() => personBidder.ValidateObject());
        }

        [Theory]
        [InlineData(412)]
        [InlineData(1)]
        [InlineData(23)]
        [InlineData(90092)]
        public void CreatePersonBidder_ShouldInstantiatePersonBidderTheory(int id)
        {
            Person person = new Person();
            var personBidder = new PersonBidder();
            personBidder.Person = person;
            personBidder.IdBidder = id;

            personBidder.ValidateObject();
            Assert.NotNull(personBidder);
        }

        public PersonBidder GetPersonBidder()
        {
            Person person = new Person();
            var personBidder = new PersonBidder();
            personBidder.Person = person;

            return personBidder;
        }
    }
}
