using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using TiendaVirtual.Models;
using TiendaVirtual.Models.Bilders;

namespace TiendaVirtual
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            ///Binder de sesion
            ModelBinders.Binders.Add(typeof(CarritoCompra), new CarritoCompraModelBilder());
        }
    }
}
