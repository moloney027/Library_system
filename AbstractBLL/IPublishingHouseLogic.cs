using System.Collections.Generic;
using Entities;

namespace AbstractBLL
{
    public interface IPublishingHouseLogic
    {
        List<PublishingHouse> GetAll();
        string Create(PublishingHouse publishingHouse);
        string Delete(int idPublishingHouse);
    }
}