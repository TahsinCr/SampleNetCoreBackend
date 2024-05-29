using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Core.Business
{
    public interface IEntityManagerRepository<TEntity>
    {
        public IDataResult<List<TEntity>> GetAll();

        public IResult Add(TEntity entity);

        public IResult Update(TEntity entity);

        public IResult Delete(TEntity entity);
    }
}
