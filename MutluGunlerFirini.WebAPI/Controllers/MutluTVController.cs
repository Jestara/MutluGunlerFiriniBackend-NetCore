using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MutluGunlerFirini.Business.Abstract;
using MutluGunlerFirini.Entities.Concrete;
using MutluGunlerFirini.Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MutluGunlerFirini.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class MutluTVController : ControllerBase
    {
        private IMutluTVService _mutluTvService;
       

            public MutluTVController(IMutluTVService mutluTVService){
            _mutluTvService = mutluTVService;

        }

        [HttpGet("getall")]
        public IActionResult GetList()
        {
            var result = _mutluTvService.GetList();
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int mutluTVId)
        {
            var result = _mutluTvService.GetById(mutluTVId);
            if (result.Success)
            {
                return Ok(result.Data);
            }

            return BadRequest(result.Message);
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddAsync(MutluTVDto mutluTVDto)
        {
            var result = _mutluTvService.Add(mutluTVDto);
            if (result.Success)
            {
                return Ok(result.Message);
            }

            return BadRequest(result.Message);
        }

        [HttpPost("update")]
        public async Task<IActionResult> UpdateAsync(MutluTVDto mutluTvDto)
        {
            var result = _mutluTvService.Update(mutluTvDto);
            if (result.Success)
            {
                return Ok(result.Message);
            }

            return BadRequest(result.Message);

        }
        [HttpPost("delete")]

        public async Task<IActionResult> Delete(MutluTV mutluTv)
        {

            var result = _mutluTvService.Delete(mutluTv);
            if (result.Success)
            {
                return Ok(result.Message);
            }

            return BadRequest(result.Message);
        }

    }
}
