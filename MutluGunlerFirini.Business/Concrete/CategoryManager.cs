using AutoMapper;
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
    public class CategoryManager : ICategoryService
    {
        private ICategoryDal _categoryDal;
        private IMapper _mapper;
        private IProductDal _productDal;

        public CategoryManager(ICategoryDal categoryDal, IMapper mapper, IProductDal productDal)
        {
            _categoryDal = categoryDal;
            _mapper = mapper;
            _productDal = productDal;
        }

        [CacheRemoveAspect("ICategoryService.Get")]
        public IResult Add(CategoryDto categoryDto)
        {
            Category category = new Category { Description = categoryDto.Description, ImageUrl = categoryDto.ImageUrl, Name = categoryDto.Name, MenuId = categoryDto.MenuId };
            _categoryDal.Add(category);
            return new SuccessResult(Messages.CategoryAdded);
        }

        [CacheRemoveAspect("ICategoryService.Get")]
        public IResult Delete(Category category)
        {
            _categoryDal.Delete(category);
            return new SuccessResult(Messages.CategoryDeleted);
        }

        [CacheAspect(1)]
        public IDataResult<List<CategoryWithProductsDto>> GetAll(int menuId)
        {
            List<CategoryWithProductsDto> categoryWithProductsDtos = _mapper.Map<List<CategoryWithProductsDto>>(_categoryDal.GetList(c => c.MenuId==menuId));
            foreach (var categoryWithProductsDto in categoryWithProductsDtos)
            {
                categoryWithProductsDto.Products = GetProducts(categoryWithProductsDto.Id);
            }
            return new SuccessDataResult<List<CategoryWithProductsDto>>(categoryWithProductsDtos);
        }

        [CacheAspect(1)]
        private List<Product> GetProducts(int categoryId)
        {
            return _productDal.GetList(p => p.CategoryId == categoryId);
        }

        [CacheAspect(1)]
        public IDataResult<Category> GetById(int categoryId)
        {
            return new SuccessDataResult<Category>(_categoryDal.Get(c => c.Id == categoryId));
        }

        [CacheAspect(1)]
        public IDataResult<List<Category>> GetList()
        {
            return new SuccessDataResult<List<Category>>(_categoryDal.GetList());
        }

        [CacheAspect(1)]
        public IDataResult<List<Category>> GetListByMenu(int menuId)
        {
            return new SuccessDataResult<List<Category>>(_categoryDal.GetList(c => c.MenuId== menuId));
        }

        [CacheRemoveAspect("ICategoryService.Get")]
        public IResult Update(CategoryDto categoryDto)
        {
            Category category = new Category { Id=categoryDto.Id,Description = categoryDto.Description, ImageUrl = categoryDto.ImageUrl, Name = categoryDto.Name, MenuId = categoryDto.MenuId };
            _categoryDal.Update(category);
            return new SuccessResult(Messages.CategoryUpdated);
        }
    }
}
