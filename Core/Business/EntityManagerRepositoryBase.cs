using Core.DataAccess;
using Core.Entities;
using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Core.Aspects.Caching;

namespace Core.Business
{
    public class EntityManagerRepositoryBase<TEntity> : IEntityManagerRepository<TEntity>
        where TEntity: class, IEntity, new()
    {
        private readonly IEntityRepository<TEntity> _entityDal;

        public EntityManagerRepositoryBase(IEntityRepository<TEntity> entityDal)
        {
            _entityDal = entityDal;
        }

        public virtual IDataResult<List<TEntity>> GetAll()
        {
            return new SuccessDataResult<List<TEntity>>(_entityDal.GetAll());
        }

        [CacheRemoveAspect("Service.Get")]
        public virtual IResult Add(TEntity entity)
        {
            _entityDal.Add(entity);
            return new SuccessResult();
        }

        [CacheRemoveAspect("Service.Get")]
        public virtual IResult Delete(TEntity entity)
        {
            _entityDal.Delete(entity);
            return new SuccessResult();
        }

        [CacheRemoveAspect("Service.Get")]
        public virtual IResult Update(TEntity entity)
        {
            _entityDal.Update(entity);
            return new SuccessResult();
        }
    }
}
