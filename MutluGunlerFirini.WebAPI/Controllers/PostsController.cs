using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MutluGunlerFirini.Business.Abstract;
using MutluGunlerFirini.Entities.Concrete;
using MutluGunlerFirini.Entities.Dtos;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MutluGunlerFirini.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class PostsController : ControllerBase
    {
        private readonly IPostService _postService;
        [Obsolete]
        private IHostingEnvironment _hostingEnvironment;

        [Obsolete]
        public PostsController(IPostService postService, IHostingEnvironment environment)
        {
            _postService = postService;
            _hostingEnvironment = environment;
        }

        [HttpGet("getall")]
        public IActionResult GetList()
        {
            var result = _postService.GetList();
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int galleryId)
        {
            var result = _postService.GetById(galleryId);
            if (result.Success)
            {
                return Ok(result.Data);
            }

            return BadRequest(result.Message);
        }

        [HttpPost("add")]
        [Obsolete]
        public async Task<IActionResult> AddAsync([FromForm] PostDto postDto)
        {
            string imageUrl = "";
            if (postDto.File != null)
            {
                var uploads = Path.Combine(_hostingEnvironment.WebRootPath, "Images");
                if (!Directory.Exists(uploads))
                {
                    Directory.CreateDirectory(uploads);
                }
                if (postDto.File.Length > 0)
                {
                    Guid guid = Guid.NewGuid();
                    string filename = postDto.File.FileName;
                    string[] separate = filename.Split('.');
                    string name = guid + "." + separate[1];
                    var filePath = Path.Combine(uploads, name);
                    imageUrl = "service.mutlugunlerfirini.com.tr/wwwroot/Images/" + name;
                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        await postDto.File.CopyToAsync(fileStream);
                    }
                }
                postDto.ImageUrl = imageUrl;
            }
            var result = _postService.Add(postDto);
            if (result.Success)
            {
                return Ok(result.Message);
            }

            return BadRequest(result.Message);
        }

        [HttpPost("update")]
        [Obsolete]
        public async Task<IActionResult> UpdateAsync(PostDto postDto)
        {
            string imageUrl = "";
            if (postDto.File != null)
            {
                try
                {
                    var deletes = Path.Combine(_hostingEnvironment.WebRootPath, "Images");
                    string[] paths = postDto.ImageUrl.Split('/');
                    string name = paths[paths.Length - 1];
                    if (Directory.Exists(deletes))
                    {

                        var filePath = Path.Combine(deletes, name);
                        System.IO.File.Delete(filePath);
                    }

                }
                catch (Exception)
                {

                    throw;
                }
                var uploads = Path.Combine(_hostingEnvironment.WebRootPath, "Images");
                if (!Directory.Exists(uploads))
                {
                    Directory.CreateDirectory(uploads);
                }
                if (postDto.File.Length > 0)
                {
                    Guid guid = Guid.NewGuid();
                    string filename = postDto.File.FileName;
                    string[] separate = filename.Split('.');
                    string name = guid + "." + separate[1];
                    var filePath = Path.Combine(uploads, name);
                    imageUrl = "service.mutlugunlerfirini.com.tr/wwwroot/Images/" + name;
                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        await postDto.File.CopyToAsync(fileStream);
                    }
                }
                postDto.ImageUrl = imageUrl;
            }
            var result = _postService.Update(postDto);
            if (result.Success)
            {
                return Ok(result.Message);
            }

            return BadRequest(result.Message);
        }

        [HttpPost("delete")]
        [Obsolete]
        public IActionResult Delete(Post post)
        {
            try
            {
                var deletes = Path.Combine(_hostingEnvironment.WebRootPath, "Images");
                string[] paths = post.ImageUrl.Split('/');
                string name = paths[paths.Length - 1];
                if (Directory.Exists(deletes))
                {

                    var filePath = Path.Combine(deletes, name);
                    System.IO.File.Delete(filePath);
                }

            }
            catch (Exception)
            {

                throw;
            }
            var result = _postService.Delete(post);
            if (result.Success)
            {
                return Ok(result.Message);
            }

            return BadRequest(result.Message);
        }
    }
}

