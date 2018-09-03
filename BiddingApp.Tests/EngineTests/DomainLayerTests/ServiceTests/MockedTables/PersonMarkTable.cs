using BiddingApp.BiddingEngine.DomainData;
using BiddingApp.BiddingEngine.DomainLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiddingApp.Tests.EngineTests.DomainLayerTests.ServiceTests.MockedTables
{
    class PersonMarkTable : IPersonMarkTable
    {
        List<PersonOfferorMark> list = new List<PersonOfferorMark>();
        int index = 1;

        public List<PersonOfferorMark> FetchPersonOfferorMarks(PersonOfferor offeror)
        {
            List<PersonOfferorMark> result = new List<PersonOfferorMark>();
            foreach (PersonOfferorMark mark in list)
            {
                if(mark.Receiver.IdOfferor == offeror.IdOfferor)
                {
                    result.Add(mark);
                }
            }

            return result;
        }

        public void InsertPersonMark(PersonOfferorMark personMark)
        {
            personMark.IdOfferorMark = index++;
            list.Add(personMark);
        }
    }
}
