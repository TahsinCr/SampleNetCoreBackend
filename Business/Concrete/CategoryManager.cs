using Business.Abstract;
using Core.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities;

namespace Business.Concrete
{
    public class CategoryManager : EntityManagerRepositoryBase<Category>, ICategoryService
    {
        private readonly ICategoryDal _categoryDal;

        public CategoryManager(ICategoryDal categoryDal) : base(categoryDal)
        {
            _categoryDal = categoryDal;
        }

        public IDataResult<Category> GetById(int id)
        {
            return new SuccessDataResult<Category>(_categoryDal.Get(category=> category.CategoryId == id));
        }
    }
}
