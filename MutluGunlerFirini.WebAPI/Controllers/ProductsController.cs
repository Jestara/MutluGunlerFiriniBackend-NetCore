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
    public class ProductsController : ControllerBase
    {
        private IProductService _productService;
        private IHostingEnvironment _hostingEnvironment;

        public ProductsController(IProductService productService, IHostingEnvironment environment)
        {
            _productService = productService;
            _hostingEnvironment = environment;
        }

        [HttpGet("getall")]
        public IActionResult GetList()
        {
            var result = _productService.GetList();
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("getlistbycategory")]
        public IActionResult GetListByCategory(int categoryId)
        {
            var result = _productService.GetListByCategory(categoryId);
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int productId)
        {
            var result = _productService.GetById(productId);
            if (result.Success)
            {
                return Ok(result.Data);
            }

            return BadRequest(result.Message);
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add([FromForm] ProductDto productDto)
        {
            string imageUrl = "";
            if (productDto.File != null)
            {
                var uploads = Path.Combine(_hostingEnvironment.WebRootPath, "Images\\Product");
                if (!Directory.Exists(uploads))
                {
                    Directory.CreateDirectory(uploads);
                }
                if (productDto.File.Length > 0)
                {
                    Guid guid = Guid.NewGuid();
                    string filename = productDto.File.FileName;
                    string[] separate = filename.Split('.');
                    string name = guid + "." + separate[1];
                    var filePath = Path.Combine(uploads, name);
                    imageUrl = "service.mutlugunlerfirini.com.tr/wwwroot/Images/Product/" + name;
                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        await productDto.File.CopyToAsync(fileStream);
                    }
                }
                productDto.ImageUrl = imageUrl;
            }
            var result = _productService.Add(productDto);
            if (result.Success)
            {
                return Ok();
            }

            return BadRequest(result.Message);
        }

        [HttpPost("update")]
        public async Task<IActionResult> Update([FromForm] ProductDto productDto)
        {
            string imageUrl = "";
            if (productDto.File != null)
            {
                try
                {
                    System.IO.File.Delete(productDto.ImageUrl);
                }
                catch (Exception)
                {

                    throw;
                }
                var uploads = Path.Combine(_hostingEnvironment.WebRootPath, "Images\\Product");
                if (!Directory.Exists(uploads))
                {
                    Directory.CreateDirectory(uploads);
                }
                if (productDto.File.Length > 0)
                {
                    Guid guid = Guid.NewGuid();
                    string filename = productDto.File.FileName;
                    string[] separate = filename.Split('.');
                    string name = guid + "." + separate[1];
                    var filePath = Path.Combine(uploads, name);
                    imageUrl = "service.mutlugunlerfirini.com.tr/wwwroot/Images/Product/" + name;
                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        await productDto.File.CopyToAsync(fileStream);
                    }
                }
                productDto.ImageUrl = imageUrl;
            }
            
            var result = _productService.Update(productDto);
            if (result.Success)
            {
                return Ok();
            }

            return BadRequest(result.Message);
        }

        [HttpPost("delete")]
        public IActionResult Delete(Product product)
        {
            try
            {
                System.IO.File.Delete(product.ImageUrl);
            }
            catch (Exception)
            {

                throw;
            }
            var result = _productService.Delete(product);
            if (result.Success)
            {
                return Ok(result.Message);
            }

            return BadRequest(result.Message);
        }
    }
}
