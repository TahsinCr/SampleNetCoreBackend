using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Business.Abstract;
using Business.BusinessAspect.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Aspects.Caching;
using Core.Business;
using Core.Entities;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities;

namespace Business.Concrete
{
    public class ProductManager : EntityManagerRepositoryBase<Product>, IProductService
    {
        private readonly IProductDal _productDal;

        public ProductManager(IProductDal productDal) : base(productDal)
        {
            _productDal = productDal;
        }

        public IDataResult<List<Product>> GetAllByCategoryId(int id)
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(product => product.CategoryId == id));
        }

        [CacheAspect]
        public IDataResult<Product> GetById(int id)
        {
            return new SuccessDataResult<Product>(_productDal.Get(product=> product.ProductId == id));
        }

        [SecuredOperationAspect("product.add","admin")]
        [ValidationAspect(typeof(ProductValidator))]
        public override IResult Add(Product product)
        {
            BusinessRules.Run(
                CheckIfProductCountOfCategoryCorrect(product.CategoryId),
                CheckIfProductNameAlreadyExists(product.ProductName),
                CheckIfCategoryLimitExceded(product.CategoryId)
            );
            return base.Add(product);
        }

        private IResult CheckIfProductCountOfCategoryCorrect(int categoryId)
        {
            int result = _productDal.GetAll(p => p.CategoryId == categoryId).Count;
            if (result == 15)
            {
                return new ErrorResult(Messages.ProductCountOfCategoryError);
            }

            return new SuccessResult();
        }

        private IResult CheckIfProductNameAlreadyExists(string productName)
        {
            bool result = _productDal.GetAll(p => p.ProductName == productName).Any();
            if (result)
            {
                return new ErrorResult(Messages.ProductNameAlreadyExistsError);
            }

            return new SuccessResult();
        }

        private IResult CheckIfCategoryLimitExceded(int categoryId)
        {
            var result = GetAll();
            if (result.Data.Count > 15)
            {
                return new ErrorResult(Messages.CategoryLimitExcededError);
            }

            return new SuccessResult();
        }
    }
}
