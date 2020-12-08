using MutluGunlerFirini.Core.Utilities.Results;
using MutluGunlerFirini.Entities.Concrete;
using MutluGunlerFirini.Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace MutluGunlerFirini.Business.Abstract
{
    public interface ICategoryService
    {
        IDataResult<Category> GetById(int categoryId);
        IDataResult<List<Category>> GetList();
        IDataResult<List<Category>> GetListByMenu(int menuId);
        IResult Add(CategoryDto categoryDto);
        IResult Delete(Category category);
        IResult Update(CategoryDto categoryDto);
    }
}
