using Libreria_V6.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Libreria_V6.Filtro
{
    public class FiltroUser:ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            tusuario usuario = (tusuario)filterContext.HttpContext.Session["usuario"];

            if (usuario == null)
            {
                Redirigir(filterContext);
            }


        }

        private void Redirigir(ActionExecutingContext filterContext)
        {
            filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary
            {
                { "controller","Inicio" },
                {"action","Login" }
            });
        }
    }
}