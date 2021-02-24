using MutluGunlerFirini.Core.Utilities.Results;
using MutluGunlerFirini.Entities.Concrete;
using MutluGunlerFirini.Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace MutluGunlerFirini.Business.Abstract
{
    public interface IPostService
    {
        IDataResult<Post> GetById(int galleryId);
        IDataResult<List<Post>> GetList();
        IResult Add(PostDto galleryDto);
        IResult Delete(Post gallery);
        IResult Update(PostDto galleryDto);
    }
}
