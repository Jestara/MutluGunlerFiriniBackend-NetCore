using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MutluGunlerFirini.Business.Abstract;
using MutluGunlerFirini.Entities.Concrete;
using MutluGunlerFirini.Entities.Dtos;

namespace MutluGunlerFirini.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CategoriesController : ControllerBase
    {
        private ICategoryService _categoryService;
        private IHostingEnvironment _hostingEnvironment;

        public CategoriesController(ICategoryService categoryService, IHostingEnvironment environment)
        {
            _categoryService = categoryService;
            _hostingEnvironment = environment;
        }

        [HttpGet("getallwithproducts")]
        public IActionResult GetList(int menuId)
        {
            var result = _categoryService.GetAll(menuId);
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _categoryService.GetList();
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("getlistbymenu")]
        public IActionResult GetListByMenu(int menuId)
        {
            var result = _categoryService.GetListByMenu(menuId);
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }


        [HttpGet("getbyid")]
        public IActionResult GetById(int categoryId)
        {
            var result = _categoryService.GetById(categoryId);
            if (result.Success)
            {
                return Ok(result.Data);
            }

            return BadRequest(result.Message);
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add([FromForm] CategoryDto categoryDto)
        {
            string imageUrl = "";
            if (categoryDto.File != null)
            {
                var uploads = Path.Combine(_hostingEnvironment.WebRootPath, "Images\\Category");
                if (!Directory.Exists(uploads))
                {
                    Directory.CreateDirectory(uploads);
                }
                if (categoryDto.File.Length > 0)
                {
                    Guid guid = Guid.NewGuid();
                    string filename = categoryDto.File.FileName;
                    string[] separate = filename.Split('.');
                    string name = guid + "." + separate[1];
                    var filePath = Path.Combine(uploads, name);
                    imageUrl = "service.mutlugunlerfirini.com.tr/wwwroot/Images/Category/" + name;
                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        await categoryDto.File.CopyToAsync(fileStream);
                    }
                }
                categoryDto.ImageUrl = imageUrl;
            }
            var result = _categoryService.Add(categoryDto);
            if (result.Success)
            {
                return Ok();
            }

            return BadRequest(result.Message);
        }

        [HttpPost("update")]
        public async Task<IActionResult> Update([FromForm] CategoryDto categoryDto)
        {
            string imageUrl = "";
            if (categoryDto.File != null)
            {
                try
                {
                    var deletes = Path.Combine(_hostingEnvironment.WebRootPath, "Images\\Category");
                    string[] paths = categoryDto.ImageUrl.Split('/');
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

                var uploads = Path.Combine(_hostingEnvironment.WebRootPath, "Images\\Category");
                if (!Directory.Exists(uploads))
                {
                    Directory.CreateDirectory(uploads);
                }
                if (categoryDto.File.Length > 0)
                {
                    Guid guid = Guid.NewGuid();
                    string filename = categoryDto.File.FileName;
                    string[] separate = filename.Split('.');
                    string name = guid + "." + separate[1];
                    var filePath = Path.Combine(uploads, name);
                    imageUrl = "service.mutlugunlerfirini.com.tr/wwwroot/Images/Category/" + name;
                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        await categoryDto.File.CopyToAsync(fileStream);
                    }
                }
                categoryDto.ImageUrl = imageUrl;
            }
            
            var result = _categoryService.Update(categoryDto);
            if (result.Success)
            {
                return Ok();
            }

            return BadRequest(result.Message);
        }

        [HttpPost("delete")]
        public IActionResult Delete(Category category)
        {
            try
            {
                var deletes = Path.Combine(_hostingEnvironment.WebRootPath, "Images\\Category");
                string[] paths = category.ImageUrl.Split('/');
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

            var result = _categoryService.Delete(category);
            if (result.Success)
            {
                return Ok(result.Message);
            }

            return BadRequest(result.Message);
        }
    }
}
