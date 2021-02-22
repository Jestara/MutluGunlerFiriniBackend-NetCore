using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
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
    public class GalleriesController : ControllerBase
    {
        private readonly IGalleryService _galleryService;
        [Obsolete]
        private IHostingEnvironment _hostingEnvironment;

        [Obsolete]
        public GalleriesController(IGalleryService galleryService, IHostingEnvironment environment)
        {
            _galleryService = galleryService;
            _hostingEnvironment = environment;
        }

        [HttpGet("getall")]
        public IActionResult GetList()
        {
            var result = _galleryService.GetList();
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int galleryId)
        {
            var result = _galleryService.GetById(galleryId);
            if (result.Success)
            {
                return Ok(result.Data);
            }

            return BadRequest(result.Message);
        }

        [HttpPost("add")]
        [Obsolete]
        public async Task<IActionResult> AddAsync([FromForm] GalleryDto galleryDto)
        {
            string imageUrl = "";
            if (galleryDto.File != null)
            {
                var uploads = Path.Combine(_hostingEnvironment.WebRootPath, "Images");
                if (!Directory.Exists(uploads))
                {
                    Directory.CreateDirectory(uploads);
                }
                if (galleryDto.File.Length > 0)
                {
                    Guid guid = Guid.NewGuid();
                    string filename = galleryDto.File.FileName;
                    string[] separate = filename.Split('.');
                    string name = guid + "." + separate[1];
                    var filePath = Path.Combine(uploads, name);
                    imageUrl = "service.mutlugunlerfirini.com.tr/wwwroot/Images/" + name;
                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        await galleryDto.File.CopyToAsync(fileStream);
                    }
                }
                galleryDto.ImageUrl = imageUrl;
            }
            var result = _galleryService.Add(galleryDto);
            if (result.Success)
            {
                return Ok(result.Message);
            }

            return BadRequest(result.Message);
        }

        [HttpPost("update")]
        [Obsolete]
        public async Task<IActionResult> UpdateAsync(GalleryDto galleryDto)
        {
            string imageUrl = "";
            if (galleryDto.File != null)
            {
                try
                {
                    System.IO.File.Delete(galleryDto.ImageUrl);
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
                if (galleryDto.File.Length > 0)
                {
                    Guid guid = Guid.NewGuid();
                    string filename = galleryDto.File.FileName;
                    string[] separate = filename.Split('.');
                    string name = guid + "." + separate[1];
                    var filePath = Path.Combine(uploads, name);
                    imageUrl = "service.mutlugunlerfirini.com.tr/wwwroot/Images/" + name;
                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        await galleryDto.File.CopyToAsync(fileStream);
                    }
                }
                galleryDto.ImageUrl = imageUrl;
            }
            var result = _galleryService.Update(galleryDto);
            if (result.Success)
            {
                return Ok(result.Message);
            }

            return BadRequest(result.Message);
        }

        [HttpPost("delete")]
        public IActionResult Delete(Gallery gallery)
        {
            try
            {
                System.IO.File.Delete(gallery.ImageUrl);
            }
            catch (Exception)
            {

                throw;
            }
            var result = _galleryService.Delete(gallery);
            if (result.Success)
            {
                return Ok(result.Message);
            }

            return BadRequest(result.Message);
        }
    }
}
