using LibreriaV3._1.Comun;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace WebApplication1
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            //try
            //{
            //    Util.RellenarDictionarySentencias();

            //}
            //catch (Exception e)
            //{
            //    Util.mostrarmensaje(Errores.ControlErrores(e), "");
            //}
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        protected void Application_End()
        {
            //Util.EscribirDictionarySentenciasFichero();            
        }
    }
}
