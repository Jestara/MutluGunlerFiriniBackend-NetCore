using MutluGunlerFirini.Core.DataAccess.EntityFramework;
using MutluGunlerFirini.DataAccess.Abstract;
using MutluGunlerFirini.DataAccess.Concrete.EntityFramework.Contexts;
using MutluGunlerFirini.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace MutluGunlerFirini.DataAccess.Concrete
{
    public class EfMutluTVDal : EfEntityRepositoryBase<MutluTV, MutluGunlerFiriniContext>, IMutluTVDal
    {
    }
}
