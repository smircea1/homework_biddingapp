using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace BiddingApp.Tests.EngineTests
{
    public class ProgramMainTest
    {
        public ProgramMainTest()
        {

        }

        [Fact]
        public void Main_NotThrows()
        {
            string[] args = { };
            bool throwed = false;
            try
            {
                Program.Main(args);
            }
            catch (Exception)
            {
                throwed = true;
            }

            Assert.False(throwed);
        }
    }
}
