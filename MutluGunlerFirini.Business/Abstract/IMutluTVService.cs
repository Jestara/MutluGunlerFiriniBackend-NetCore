using MutluGunlerFirini.Core.Utilities.Results;
using MutluGunlerFirini.Entities.Concrete;
using MutluGunlerFirini.Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace MutluGunlerFirini.Business.Abstract
{
    public interface IMutluTVService
    {


        IDataResult<MutluTV> GetById(int mutluTvId);
        IDataResult<List<MutluTV>> GetList();
        IResult Add(MutluTVDto mutluTv);
        IResult Delete(MutluTV mutluTv);
        IResult Update(MutluTVDto mutluTvDto);
    }
}
