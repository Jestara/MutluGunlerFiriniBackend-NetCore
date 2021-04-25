using Microsoft.AspNetCore.Http;
using MutluGunlerFirini.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MutluGunlerFirini.Entities.Dtos
{
    public class PostDto : IDto
    {
        public int Id { get; set; } 
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public string VideoUrl { get; set; }
        public string Title{ get; set; }
        public IFormFile File { get; set; }
    }
}
