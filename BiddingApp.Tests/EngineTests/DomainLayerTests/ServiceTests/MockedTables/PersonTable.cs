using BiddingApp.BiddingEngine.DomainData;
using BiddingApp.BiddingEngine.DomainLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiddingApp.Tests.EngineTests.DomainLayerTests.ServiceTests.MockedTables
{
    class PersonTable : IPersonTable
    {
        List<Person> persons = new List<Person>();

        public Person FetchPersonById(int id)
        {
            throw new NotImplementedException();
        }

        public Person FetchPersonByPhone(string phone)
        {
            throw new NotImplementedException();
        }

        public void InsertPerson(Person person)
        {
            throw new NotImplementedException();
        }

        public void UpdatePerson(Person person)
        {
            throw new NotImplementedException();
        }
    }
}
