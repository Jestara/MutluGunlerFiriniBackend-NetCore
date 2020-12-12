using MutluGunlerFirini.Core.Entities;
using MutluGunlerFirini.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace MutluGunlerFirini.Entities.Dtos
{
    public class CategoryWithProductsDto : IDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public int MenuId { get; set; }
        public List<Product> Products { get; set; }
    }
}
