using NetShop.Models;
using System.Collections.Generic;

namespace NetShop.Repository.Interface
{
    public interface IRegionRepository
    {
        List<Region> GetAll();
    }
}
