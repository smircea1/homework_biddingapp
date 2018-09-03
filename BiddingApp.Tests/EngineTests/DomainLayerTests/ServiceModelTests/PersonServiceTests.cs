using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BiddingApp.BiddingEngine.DomainLayer.Model;
using BiddingApp.BiddingEngine.DomainLayer.ServiceModel;
using Xunit;

namespace BiddingApp.Tests.EngineTests.DomainLayerTests.ServiceModelTests
{
    public class PersonServiceTests
    {
        private static Person GetPerson()
        {
            return new Person
            {
                IdPerson = 1,
                Name = "Gigi",
                Phone = "0728838128"
            };
        }

        private static PersonService GetPersonService()
        {
            return new PersonService(GetPerson());
        }

        [Fact]
        public void CreateService_ShouldInstantiatePersonService()
        {
            var personService = GetPersonService();
            Assert.NotNull(personService);
        }

        [Fact]
        public void CreateService_ShouldHaveValidPerson()
        {
            var personService = GetPersonService();
            Assert.NotNull(personService.Person);
        }

        [Theory]
        [InlineData("")]
        [InlineData("     ")]
        [InlineData(null)]
        public void CreatePersonService_ShouldThrowInvalidPersonName(string name)
        {
            var personService = GetPersonService();
            personService.Person.Name = name;
            Assert.ThrowsAny<Exception>(() => personService.Person.ValidateObject());
        }

        [Theory]
        [InlineData("")]
        [InlineData("     ")]
        [InlineData(null)]
        public void CreatePersonService_ShouldThrowInvalidPersonPhone(string phone)
        {
            var personService = GetPersonService();
            personService.Person.Phone = phone;
            Assert.ThrowsAny<Exception>(() => personService.Person.ValidateObject());
        }
    }
}
