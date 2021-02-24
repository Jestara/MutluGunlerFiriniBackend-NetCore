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
    public class PostManager : IPostService
    {
        private IPostDal _postDal;

        public PostManager(IPostDal postDal)
        {
            _postDal = postDal;
        }
        [CacheRemoveAspect("IPostService.Get")]
        public IResult Add(PostDto postDto)
        {
            Post post = new Post { ImageUrl = postDto.ImageUrl, Description=postDto.Description,VideoUrl=postDto.VideoUrl,CreatedDate=DateTime.Now };
            _postDal.Add(post);
            return new SuccessResult(Messages.GalleryAdded);
        }

        [CacheRemoveAspect("IPostService.Get")]
        public IResult Delete(Post post)
        {
            _postDal.Delete(post);
            return new SuccessResult(Messages.GalleryDeleted);
        }

        [CacheAspect(1)]
        public IDataResult<Post> GetById(int postId)
        {
            return new SuccessDataResult<Post>(_postDal.Get(p => p.Id == postId));
        }

        [CacheAspect(1)]
        public IDataResult<List<Post>> GetList()
        {
            return new SuccessDataResult<List<Post>>(_postDal.GetList());
        }

        [CacheRemoveAspect("IPostService.Get")]
        public IResult Update(PostDto postDto)
        {
            Post post = new Post { Id=postDto.Id, ImageUrl = postDto.ImageUrl, Description = postDto.Description, VideoUrl = postDto.VideoUrl, CreatedDate = DateTime.Now };
            _postDal.Update(post);
            return new SuccessResult(Messages.GalleryUpdated);
        }
    }
}
