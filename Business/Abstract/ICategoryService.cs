using Core.Business;
using Core.Utilities.Results;
using Entities;

namespace Business.Abstract
{
    public interface ICategoryService : IEntityManagerRepository<Category>
    {
        IDataResult<Category> GetById(int id);
    }
}
