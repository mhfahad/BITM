using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using StockManageWeb.Models;
using StockManage.Models.Models;
using AutoMapper;

namespace StockManageWeb
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            CategoryMapping();
        }
        public void CategoryMapping ()
        {
            Mapper.Initialize(conf =>
            {
                conf.CreateMap<CategoryVM, Category>();
                conf.CreateMap<Category, CategoryVM>();

                conf.CreateMap<SalesVm, Sale>();
                conf.CreateMap<Sale, SalesVm>();
            });
        }
    }
}
