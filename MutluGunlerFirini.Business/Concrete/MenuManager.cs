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
    public class MenuManager : IMenuService
    {
        private IMenuDal _menuDal;

        public MenuManager(IMenuDal menuDal)
        {
            _menuDal = menuDal;
        }

        [CacheRemoveAspect("IMenuService.Get")]
        public IResult Add(MenuDto menuDto)
        {
            Menu menu = new Menu { Name = menuDto.Name, Description = menuDto.Description, ImageUrl = menuDto.ImageUrl };
            _menuDal.Add(menu);
            return new SuccessResult(Messages.MenuAdded);
        }

        [CacheRemoveAspect("IMenuService.Get")]
        public IResult Delete(Menu menu)
        {
            _menuDal.Delete(menu);
            return new SuccessResult(Messages.MenuDeleted);
        }

        [CacheAspect(1)]
        public IDataResult<Menu> GetById(int menuId)
        {
            return new SuccessDataResult<Menu>(_menuDal.Get(m => m.Id == menuId));
        }

        [CacheAspect(1)]
        public IDataResult<List<Menu>> GetList()
        {
            return new SuccessDataResult<List<Menu>>(_menuDal.GetList());
        }

        [CacheRemoveAspect("IMenuService.Get")]
        public IResult Update(MenuDto menuDto)
        {
            Menu menu = new Menu { Id=menuDto.Id, Name = menuDto.Name, Description = menuDto.Description, ImageUrl = menuDto.ImageUrl };
            _menuDal.Update(menu);
            return new SuccessResult(Messages.MenuUpdated);
        }
    }
}
