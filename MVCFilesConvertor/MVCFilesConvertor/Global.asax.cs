using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Autofac;
using Autofac.Integration.Mvc;
using MVCFilesConvertor.Models;
using MVCFilesConvertor.Models.Interfaces;
using MVCFilesConvertor.Controllers;

namespace MVCFilesConvertor
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            var builder = new ContainerBuilder();
            builder.RegisterControllers(typeof(MvcApplication).Assembly);

            builder.RegisterType<CSVtoXMLController>().InstancePerLifetimeScope();

            builder.RegisterType<CSVtoXMLViewModel>().As<ICSVtoXMLViewModel>().InstancePerLifetimeScope();
            builder.RegisterType<CSVtoXMLConvertor>().As<ICSVtoXMLConvertor>().InstancePerLifetimeScope();

            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}
