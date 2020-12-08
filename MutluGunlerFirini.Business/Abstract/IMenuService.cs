using MutluGunlerFirini.Core.Utilities.Results;
using MutluGunlerFirini.Entities.Concrete;
using MutluGunlerFirini.Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace MutluGunlerFirini.Business.Abstract
{
    public interface IMenuService
    {
        IDataResult<Menu> GetById(int menuId);
        IDataResult<List<Menu>> GetList();
        IResult Add(MenuDto menuDto);
        IResult Delete(Menu menu);
        IResult Update(MenuDto menuDto);
    }
}
