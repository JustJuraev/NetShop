using System.Collections.Generic;

namespace NetShop.Repository.Interface
{
    public interface IProductAddressRepository
    {
        List<int> ReturnProductRegions(int id);
    }
}
