using System.Collections.Generic;

namespace NetShop.Repository.Interface
{
	public interface IBaseRepository<T>
	{
		List<T>	GetAll();
	}
}
