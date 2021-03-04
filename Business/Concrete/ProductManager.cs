using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business.Abstract;

using Business.BusinessAspects.Autofac;
using Business.CCS;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using FluentValidation;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        IProductDal _ProductDal;
        ICategoryService _categoryService;

       

        public ProductManager(IProductDal productDal,ICategoryService categoryService)
        {
            _ProductDal = productDal;
            _categoryService = categoryService;
          
        }

        [SecuredOperation("product.add,admin")]
       [ValidationAspect(typeof(ProductValidator))]
       [CacheRemoveAspect("IProductService.Get")]
        public IResult Add(Product product)
        {
            IResult result=BusinessRules.Run(CheckIfProductNameExists(product.ProductName), 
                CheckIfProductCountOfCategoryCorrect(product.CategoryId),CheckIfCategoryLimitExceded());
            if (result!=null)
            {
                return result;
            } 



            if(CheckIfProductCountOfCategoryCorrect(product.CategoryId).Success)
            {
                if (CheckIfProductNameExists(product.ProductName).Success)
                {
                    _ProductDal.Add(product);
                    return new SuccessResult(Messages.ProductAdded);
                }
                

            }
            return new ErrorResult();



        }
        [CacheAspect]
        public IDataResult<List<Product> >GetAll()
        {
            if (DateTime.Now.Hour==20)
            {
                return new ErrorDataResult<List<Product>>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<List<Product>> (_ProductDal.GetAll(),Messages.ProductsListed);

        }

        public IDataResult<List<Product>> GetAllByCategoryId(int id)
        {
            throw new NotImplementedException();
        }
        [CacheAspect]
        public IDataResult<Product> GetById(int productId)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<Product>> GetByUnitPrice(decimal min, decimal max)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<ProductDetailDto>> GetProductDetails()
        {
            throw new NotImplementedException();
        }

        [ValidationAspect(typeof(ProductValidator))]
        [CacheRemoveAspect("IProductService.Get")]
        public IResult Update(Product product)
        {
            throw new NotImplementedException();
        }
        private IResult CheckIfProductCountOfCategoryCorrect(int categoryId)
        {
            var result = _ProductDal.GetAll(p => p.CategoryId == categoryId).Count;
            if (result >= 15)
            {
                return new ErrorResult(Messages.ProductCountOfCategoryError);
            }
            return new SuccessResult();
        }
        private IResult CheckIfProductNameExists(string productName)
        {
            var result = _ProductDal.GetAll(p => p.ProductName == productName).Any();
            if (result)
            {
                return new ErrorResult(Messages.ProductNameAlreadyExists);
            }
            return new SuccessResult();
        }
       
        private IResult CheckIfCategoryLimitExceded()
        {
            var result = _categoryService.GetAll();
            if (result.Data.Count>15)
            {
                return new ErrorResult(Messages.CategoryError);
            }
            return new SuccessResult();
        }

        public IResult AddTransactionalTest(Product product)
        {
            throw new NotImplementedException();
        }
    }
}
