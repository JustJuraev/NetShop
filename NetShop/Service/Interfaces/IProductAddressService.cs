using System.Collections.Generic;

namespace NetShop.Service.Interfaces
{
    public interface IProductAddressService
    {
        List<int> ReturnProductRegions(int id);
    }
}
