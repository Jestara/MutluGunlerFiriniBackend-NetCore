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
    class MutluTVManager : IMutluTVService
    {
        private IMutluTVDal _mutluTvDal;


        public MutluTVManager(IMutluTVDal mutluTvDal)
        {
            _mutluTvDal = mutluTvDal;
        }

        [CacheRemoveAspect("IMutluTVService.Get")]
        public IResult Add(MutluTVDto mutluTvDto)
        {
            MutluTV mutluTV = new MutluTV { VideoUrl = mutluTvDto .VideoUrl, Description = mutluTvDto .Description};
            _mutluTvDal.Add(mutluTV);
            return new SuccessResult(Messages.MutluTVAdded);
        }

        [CacheRemoveAspect("IMutluTVService.Get")]
        public IResult Delete(MutluTV mutluTv)
        {
            _mutluTvDal.Delete(mutluTv);
            return new SuccessResult(Messages.MutluTVDeleted);
        }
        [CacheAspect(1)]
        public IDataResult<MutluTV> GetById(int mutluTvId)
        {
            return new SuccessDataResult<MutluTV>(_mutluTvDal.Get(m => m.Id == mutluTvId));
        }
        [CacheAspect(1)]
        public IDataResult<List<MutluTV>> GetList()
        {
            return new SuccessDataResult<List<MutluTV>>(_mutluTvDal.GetList());
        }
        [CacheRemoveAspect("IMutluTVService.Get")]
        public IResult Update(MutluTVDto mutluTvDto)
        {
            MutluTV mutluTV = new MutluTV { Id = mutluTvDto.Id,VideoUrl = mutluTvDto.VideoUrl, Description = mutluTvDto.Description };

            _mutluTvDal.Update(mutluTV);
            return new SuccessResult(Messages.MutluTVUpdated);
        }
    }
}
