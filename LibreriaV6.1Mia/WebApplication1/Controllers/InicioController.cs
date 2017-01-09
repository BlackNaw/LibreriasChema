using LibreriaV3._1.Comun;
using LibreriaV3._1.Modelo;
using LibreriaV3._1.Negocio;
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
            List<TLibro> list;
            try
            {
                Util.RellenarDictionarySentencias();
                list=new List<TLibro>();

                foreach (var item in new ControlAccesoDAO<TLibro>().Obtener(new TLibro().GetType()))
                {
                    list.Add((TLibro)item);
                }

            }
            catch (Exception ex)
            {
                throw;
            }
            return View(list);
        }
    public ActionResult Administrar()
        {
            return View("~/Views/Libro/InicioLibro.cshtml");
        }
    }
}