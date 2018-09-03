using BiddingApp.BiddingEngine.DomainData;
using BiddingApp.BiddingEngine.DomainLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiddingApp.Tests.EngineTests.DomainLayerTests.ServiceTests.MockedTables
{
    class PersonOfferorTable : IPersonOfferorTable
    {
        List<PersonOfferor> list = new List<PersonOfferor>();
        int index = 0;

        public PersonOfferor FetchPersonOfferorByPerson(Person person)
        { 
            foreach (PersonOfferor offeror in list)
            {
                if(offeror.Person.IdPerson == person.IdPerson)
                {
                    return offeror;
                }
            }
            return null;
        }

        public void InsertPersonOfferor(int idPerson, PersonOfferor personOfferor)
        {
            personOfferor.IdOfferor = index++;

        }

        public void UpdatePersonOfferor(PersonOfferor personOfferor)
        {
            throw new NotImplementedException();
        }
    }
}
