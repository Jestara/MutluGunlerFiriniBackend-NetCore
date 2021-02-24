using Autofac;
using MutluGunlerFirini.Business.Abstract;
using MutluGunlerFirini.Business.Concrete;
using MutluGunlerFirini.DataAccess.Abstract;
using MutluGunlerFirini.DataAccess.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace MutluGunlerFirini.Business.DependencyResolvers.Autofac
{
    public class AutofacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {

            builder.RegisterType<UserManager>().As<IUserService>();
            builder.RegisterType<EfUserDal>().As<IUserDal>();

            builder.RegisterType<CategoryManager>().As<ICategoryService>();
            builder.RegisterType<EfCategoryDal>().As<ICategoryDal>();

            builder.RegisterType<ProductManager>().As<IProductService>();
            builder.RegisterType<EfProductDal>().As<IProductDal>();

            builder.RegisterType<MenuManager>().As<IMenuService>();
            builder.RegisterType<EfMenuDal>().As<IMenuDal>();

            builder.RegisterType<GalleryManager>().As<IGalleryService>();
            builder.RegisterType<EfGalleryDal>().As<IGalleryDal>();

            builder.RegisterType<PostManager>().As<IPostService>();
            builder.RegisterType<EfPostDal>().As<IPostDal>();

        }
    }
}