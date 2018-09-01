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
            var personOfferor = new PersonOfferor(person);
            personOfferor.ValidateObject();
            Assert.NotNull(personOfferor);
        }

        [Fact]
        public void CreatePersonOfferor_ShouldThrow()
        {
            var personOfferor = new PersonOfferor(null);

            Assert.ThrowsAny<Exception>(() => personOfferor.ValidateObject());
        }
    }
}
