﻿using MutluGunlerFirini.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MutluGunlerFirini.Entities.Concrete
{
   public  class MutluTV : IEntity
    {

        public int Id { get; set; }

        public string VideoUrl { get; set; }

        public string Description { get; set; }

    }
}