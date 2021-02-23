using MutluGunlerFirini.Business.Abstract;
using MutluGunlerFirini.Business.Constants;
using MutluGunlerFirini.Core.Aspects.Autofac.Caching;
using MutluGunlerFirini.Core.Utilities.Results;
using MutluGunlerFirini.DataAccess.Abstract;
using MutluGunlerFirini.Entities.Concrete;
using MutluGunlerFirini.Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace MutluGunlerFirini.Business.Concrete
{
    public class ProductManager : IProductService
    {
        private IProductDal _productDal;

        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

        [CacheRemoveAspect("IProductService.Get")]
        public IResult Add(ProductDto productDto)
        {
            Product product = new Product { Name = productDto.Name, ImageUrl = productDto.ImageUrl, Description = productDto.Description, CategoryId = productDto.CategoryId, Price = productDto.Price };
            _productDal.Add(product);
            return new SuccessResult(Messages.ProductAdded);
        }

        [CacheRemoveAspect("IProductService.Get")]
        public IResult Delete(Product product)
        {
            _productDal.Delete(product);
            return new SuccessResult(Messages.ProductDeleted);
        }

        [CacheAspect(1)]
        public IDataResult<Product> GetById(int productId)
        {
            return new SuccessDataResult<Product>(_productDal.Get(p => p.Id == productId));
        }

        [CacheAspect(1)]
        public IDataResult<List<Product>> GetList()
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetList());
        }

        [CacheAspect(1)]
        public IDataResult<List<Product>> GetListByCategory(int categoryId)
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetList(p => p.CategoryId == categoryId));
        }

        [CacheRemoveAspect("IProductService.Get")]
        public IResult Update(ProductDto productDto)
        {
            Product product = new Product { Id=productDto.Id, Name = productDto.Name, ImageUrl = productDto.ImageUrl, Description = productDto.Description, CategoryId = productDto.CategoryId, Price = productDto.Price };
            _productDal.Update(product);
            return new SuccessResult(Messages.ProductUpdated);
        }
    }
}
