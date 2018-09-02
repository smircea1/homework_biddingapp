using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using BiddingApp.BiddingEngine.DomainLayer.Model;
using System.Collections;
using Xunit.Extensions;

namespace BiddingApp.Tests.EngineTests.DomainLayerTests.ModelTests
{
    public class PersonOfferorMarkTests
    {
        [Fact]
        public void PersonOfferorMark_ShouldInstantiatePersonOfferorMark()
        {
            PersonOfferorMark pom = new PersonOfferorMark();
            pom.DateOccur = new DateTime();
            pom.IdOfferorMark = 1;
            pom.Mark = 5;
            pom.Sender = new Person();
            pom.Receiver = new PersonOfferor();

            pom.ValidateObject();
            Assert.NotNull(pom);
        }

        [Theory, MemberData(nameof(TestDataGenerator))]
        //[InlineData(-1, null, null, null)]
        public void PersonOfferorMark_ShouldThrow(int mark, Person sender, PersonOfferor receiver, DateTime dateOccur)
        {
            PersonOfferorMark pom = new PersonOfferorMark();
            pom.DateOccur = dateOccur;
            pom.Mark = mark;
            pom.Sender = sender;
            pom.Receiver = receiver;

            Assert.ThrowsAny<Exception>(() => pom.ValidateObject());
        }

        public static IEnumerable<object[]> TestDataGenerator
        {
            get
            {
                // Or this could read from a file. :)
                return new[]
                {
                    new object[] {-1, new Person(), new PersonOfferor(), new DateTime()},
                    new object[] {111, new Person(), new PersonOfferor(), new DateTime()},
                    new object[] {111, null, new PersonOfferor(), new DateTime()},
                };
            }
        }
    }
}
