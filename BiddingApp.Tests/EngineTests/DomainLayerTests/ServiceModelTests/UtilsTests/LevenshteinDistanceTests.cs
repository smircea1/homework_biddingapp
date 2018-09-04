using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BiddingApp.BiddingEngine.DomainLayer.Service.Utils;
using Xunit;

namespace BiddingApp.Tests.EngineTests.DomainLayerTests.ServiceModelTests.UtilsTests
{
    public class LevenshteinDistanceTests
    {
        [Theory]
        [InlineData("book", "back", 2)]
        [InlineData("test", "tent", 1)]
        [InlineData("fiat", "infiat", 2)]
        [InlineData("deea", "andreea", 3)]
        [InlineData("geanta", "janta", 2)]
        [InlineData("brick", "drik", 2)]
        [InlineData("asd", "dsa", 2)]
        [InlineData("", "a", 1)]
        [InlineData("a", "", 1)]
        public void LevenshteinDistance_ShouldCerifyExpectedResults(string firstString, string secondString, int expectedResult)
        {
            int result = LevenshteinDistance.ComputeDistance(firstString, secondString);
            Assert.Equal(expectedResult, result);
        }
    }
}
