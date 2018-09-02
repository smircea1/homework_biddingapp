using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BiddingApp.BiddingEngine.DomainLayer.Model;
using Xunit;

namespace BiddingApp.Tests.EngineTests.DomainLayerTests.ModelTests
{
    public class PersonTests
    {
        [Fact]
        public void CreatePerson_ShouldInstantiatePerson()
        {
            Person person = new Person();
            person.IdPerson = 1;
            person.Name = "Gigi";
            person.Phone = "0728818282";
           
            person.ValidateObject();
            Assert.NotNull(person);
        }

        [Theory]
        [InlineData(-1, "Gigi", "0728818282")]
        [InlineData(-1, "", "0728818282")]
        [InlineData(-1, " ", "0728818282")]
        [InlineData(-1, "Gigi", "")]
        [InlineData(1, null, null)]
        [InlineData(1, null, "0728818282")]
        [InlineData(1, "Gigi", null)]
        [InlineData(1, "Gigi", " ")]
        public void CreatePerson_ShouldThrow(int id, string name, string phone)
        {
            var person = new Person
            {
                IdPerson = id,
                Name = name,
                Phone = phone
            };

            Assert.ThrowsAny<Exception>(() => person.ValidateObject());
        }
    }
}
