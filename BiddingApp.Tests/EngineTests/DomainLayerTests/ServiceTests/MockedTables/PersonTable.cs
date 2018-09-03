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

        int index = 0;

        public PersonTable()
        {

        }

        public Person FetchPersonByPhone(string phone)
        {
            foreach(Person person in persons)
            {
                if (person.Phone.Equals(phone))
                {
                    return person;
                }
            }
            return null;
        }

        public void InsertPerson(Person person)
        {
            if(FetchPersonByPhone(person.Phone) == null)
            {
                person.IdPerson = index++;
                persons.Add(person);
            }
        }

        public void UpdatePerson(Person person)
        {
            foreach(Person list_person in persons)
            {
                if (list_person.Phone.Equals(person.Phone))
                {
                    list_person.Name = person.Name;
                }
            }
        }
    }
}
