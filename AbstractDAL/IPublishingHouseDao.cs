using System.Collections.Generic;
using Entities;

namespace AbstractDAL
{
    public interface IPublishingHouseDao
    {
        IEnumerable<PublishingHouse> GetAll();
        int Create(PublishingHouse publishingHouse);
        int Delete(int idPublishingHouse);
    }
}