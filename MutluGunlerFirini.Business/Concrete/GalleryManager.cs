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
    public class GalleryManager : IGalleryService
    {
        private readonly IGalleryDal _galleryDal;

        public GalleryManager(IGalleryDal galleryDal)
        {
            _galleryDal = galleryDal;
        }

        [CacheRemoveAspect("IGalleryService.Get")]
        public IResult Add(GalleryDto galleryDto)
        {
            Gallery gallery = new Gallery { ImageUrl = galleryDto.ImageUrl };
            _galleryDal.Add(gallery);
            return new SuccessResult(Messages.GalleryAdded);
        }

        [CacheRemoveAspect("IGalleryService.Get")]
        public IResult Delete(Gallery gallery)
        {
            _galleryDal.Delete(gallery);
            return new SuccessResult(Messages.GalleryDeleted);
        }

        [CacheAspect(1)]
        public IDataResult<Gallery> GetById(int galleryId)
        {
            return new SuccessDataResult<Gallery>(_galleryDal.Get(g => g.Id == galleryId));
        }

        [CacheAspect(1)]
        public IDataResult<List<Gallery>> GetList()
        {
            return new SuccessDataResult<List<Gallery>>(_galleryDal.GetList());
        }

        [CacheRemoveAspect("IGalleryService.Get")]
        public IResult Update(GalleryDto galleryDto)
        {
            Gallery gallery = new Gallery { Id = galleryDto.Id, ImageUrl = galleryDto.ImageUrl };
            _galleryDal.Update(gallery);
            return new SuccessResult(Messages.GalleryUpdated);
        }
    }
}
