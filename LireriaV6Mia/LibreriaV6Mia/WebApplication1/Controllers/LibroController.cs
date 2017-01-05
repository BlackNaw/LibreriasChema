using LibreriaV3._1.Comun;
using LibreriaV3._1.Modelo;
using LibreriaV3._1.Negocio;
using LibreriaV3._1.Persistencia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Libreria_V6.Controllers
{
    public class LibroController : Controller
    {   private ControlAccesoDAO<TLibro> control = new ControlAccesoDAO<TLibro>();
        // GET: Libro
        public ActionResult Insertar()
        {
            return View(control.ObtenerTemas());
        }
        [HttpPost]
        public ActionResult Insertar (TLibro libro)
        {
           
            try
            {
                libro.CodLibro = Util.GenerarCodigo(libro.GetType());
                libro.Borrado = "0";
                libro.Formatouno = libro.Formatouno == null ? "N/A" : libro.Formatouno;
                libro.Formatodos = libro.Formatodos  == null ? "N/A" : libro.Formatodos;
                libro.Formatotres  = libro.Formatotres == null ? "N/A" : libro.Formatotres;
                control.Insertar(libro);
            }catch(Exception e)
            {
                throw;
            }

            return View(control.ObtenerTemas());
        }

        public ActionResult Consultar()
        {
            List<TLibro> list = new List<TLibro>();

            foreach (var item in control.Obtener(new TLibro().GetType()))
            {
                list.Add((TLibro)item);
            }
            
            return View(list);
        }
    }
}