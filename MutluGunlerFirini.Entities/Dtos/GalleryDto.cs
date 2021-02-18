using Microsoft.AspNetCore.Http;
using MutluGunlerFirini.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MutluGunlerFirini.Entities.Dtos
{
    public class GalleryDto : IDto
    {
        public int Id { get; set; }
        public string ImageUrl { get; set; }
        public IFormFile File { get; set; }
    }
}
