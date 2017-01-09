using LibreriaV3._1.Comun;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{
    public class InicioController : Controller
    {      
         
public ActionResult Inicio()
        {
            try
            {
                Util.RellenarDictionarySentencias();
            }
            catch (Exception ex)
            {
                throw;
            }
            return View();
        }

    }
}