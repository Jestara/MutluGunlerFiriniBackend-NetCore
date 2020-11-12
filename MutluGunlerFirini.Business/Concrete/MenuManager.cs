using MutluGunlerFirini.Business.Abstract;
using MutluGunlerFirini.Business.Constants;
using MutluGunlerFirini.Core.Utilities.Results;
using MutluGunlerFirini.DataAccess.Abstract;
using MutluGunlerFirini.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace MutluGunlerFirini.Business.Concrete
{
    public class MenuManager : IMenuService
    {
        private IMenuDal _menuDal;

        public MenuManager(IMenuDal menuDal)
        {
            _menuDal = menuDal;
        }

        public IResult Add(Menu menu)
        {
            _menuDal.Add(menu);
            return new SuccessResult(Messages.MenuAdded);
        }

        public IResult Delete(Menu menu)
        {
            _menuDal.Delete(menu);
            return new SuccessResult(Messages.MenuDeleted);
        }

        public IDataResult<Menu> GetById(int menuId)
        {
            return new SuccessDataResult<Menu>(_menuDal.Get(m => m.Id == menuId));
        }

        public IDataResult<List<Menu>> GetList()
        {
            return new SuccessDataResult<List<Menu>>(_menuDal.GetList());
        }

        public IResult Update(Menu menu)
        {
            _menuDal.Update(menu);
            return new SuccessResult(Messages.MenuUpdated);
        }
    }
}
