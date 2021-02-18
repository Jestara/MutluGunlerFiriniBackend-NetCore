using MutluGunlerFirini.Core.Utilities.Results;
using MutluGunlerFirini.Entities.Concrete;
using MutluGunlerFirini.Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace MutluGunlerFirini.Business.Abstract
{
    public interface IGalleryService
    {
        IDataResult<Gallery> GetById(int galleryId);
        IDataResult<List<Gallery>> GetList();
        IResult Add(GalleryDto galleryDto);
        IResult Delete(Gallery gallery);
        IResult Update(GalleryDto galleryDto);
    }
}
