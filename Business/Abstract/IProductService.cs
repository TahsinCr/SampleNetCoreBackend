using System.Collections.Generic;
using Core.Business;
using Core.Utilities.Results;
using Entities;

namespace Business.Abstract
{
    public interface IProductService : IEntityManagerRepository<Product>
    {
        public IDataResult<List<Product>> GetAllByCategoryId(int id);
        public IDataResult<Product> GetById(int id);

    }
}
