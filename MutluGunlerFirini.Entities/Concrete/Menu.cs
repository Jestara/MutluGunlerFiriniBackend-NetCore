﻿using MutluGunlerFirini.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MutluGunlerFirini.Entities.Concrete
{
    public class Menu : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
    }
}
