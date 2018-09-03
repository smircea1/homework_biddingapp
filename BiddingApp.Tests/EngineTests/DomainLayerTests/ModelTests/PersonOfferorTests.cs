using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using BiddingApp.BiddingEngine.DomainLayer.Model;

namespace BiddingApp.Tests.EngineTests.DomainLayerTests.ModelTests
{
    public class PersonOfferorTests
    {
        [Fact]
        public void CreatePersonOfferor_ShouldInstantiatePersonOfferor()
        {
            Person person = new Person();
            var personOfferor = new PersonOfferor();
            personOfferor.Person = person;

            personOfferor.ValidateObject();
            Assert.NotNull(personOfferor);
        }

        [Fact]
        public void CreatePersonOfferor_ShouldThrow()
        {
            var personOfferor = new PersonOfferor();
            personOfferor.Person = null;

            Assert.ThrowsAny<Exception>(() => personOfferor.ValidateObject());
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(-12000)]
        [InlineData(-12)]
        [InlineData(-231)]
        public void CreatePersonOfferor_ShouldThrowBadId(int id)
        {
            var personOfferor = new PersonOfferor {
                IdOfferor = id,
                LastBannedDate = DateTime.Now,
                Person = new Person()
            };

            Assert.ThrowsAny<Exception>(() => personOfferor.ValidateObject());
        }
    }
}
