using MutluGunlerFirini.Core.Utilities.Results;
using MutluGunlerFirini.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace MutluGunlerFirini.Business.Abstract
{
    public interface IMenuService
    {
        IDataResult<Menu> GetById(int menuId);
        IDataResult<List<Menu>> GetList();
        IResult Add(Menu menu);
        IResult Delete(Menu menu);
        IResult Update(Menu menu);
    }
}
