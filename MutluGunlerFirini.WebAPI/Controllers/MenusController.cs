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
    public class MenusController : ControllerBase
    {
        private IMenuService _menuService;
        
        private IHostingEnvironment _hostingEnvironment;

        public MenusController(IMenuService menuService, IHostingEnvironment environment)
        {
            _menuService = menuService;
            _hostingEnvironment = environment;
        }

        [HttpGet("getall")]
        public IActionResult GetList()
        {
            var result = _menuService.GetList();
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }


        [HttpGet("getbyid")]
        public IActionResult GetById(int menuId)
        {
            var result = _menuService.GetById(menuId);
            if (result.Success)
            {
                return Ok(result.Data);
            }

            return BadRequest(result.Message);
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add(MenuDto menuDto)
        {
            string imageUrl = "";
            var uploads = Path.Combine(_hostingEnvironment.WebRootPath, "Images");
            if (!Directory.Exists(uploads))
            {
                Directory.CreateDirectory(uploads);
            }
            if (menuDto.File.Length > 0)
            {
                var filePath = Path.Combine(uploads, menuDto.File.FileName);
                imageUrl = filePath;
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await menuDto.File.CopyToAsync(fileStream);
                }
            }
            menuDto.ImageUrl = imageUrl;
            var result = _menuService.Add(menuDto);
            if (result.Success)
            {
                return Ok();
            }

            return BadRequest(result.Message);
        }

        [HttpPost("update")]
        public IActionResult Update(Menu menu)
        {
            var result = _menuService.Update(menu);
            if (result.Success)
            {
                return Ok();
            }

            return BadRequest(result.Message);
        }

        [HttpPost("delete")]
        public IActionResult Delete(Menu menu)
        {
            var result = _menuService.Delete(menu);
            if (result.Success)
            {
                return Ok();
            }

            return BadRequest(result.Message);
        }
    }
}
