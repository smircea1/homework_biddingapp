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
        public void BuildPerson_ShouldBuildPerson()
        {
            var personBuilder = new Person.Builder();
            personBuilder.SetName("Gigi");
            personBuilder.SetId(1);

            var person = personBuilder.Build();

            Assert.NotNull(person);
            Assert.Equal("Gigi", person.Name);
            Assert.Equal(1, person.Id);
        }

        [Fact]
        public void BuildPerson_ShouldFailBuildPerson()
        {
            var personBuilder = new Person.Builder();
            personBuilder.SetId(1);

            var person = personBuilder.Build();
            Assert.Null(person);
        }

        [Theory]
        [InlineData("")]
        [InlineData(" ")]
        [InlineData(null)]
        public void BuildPerson_ShouldFailBuildPersonWrongName(string name)
        {
            var personBuilder = new Person.Builder();
            personBuilder.SetId(1);
            personBuilder.SetName(name);

            var person = personBuilder.Build();
            Assert.Null(person);
        }
    }
}
