using Libreria_V6.Filtro;
using LibreriaV3._1.Comun;
using System;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Linq;

namespace Libreria_V6.Controllers
{
    public class LibroController : Controller
    {
        // GET: Libro
        [FiltroAdmin]
        public ActionResult Insertar()
        {
            using (libreriavsEntities context = new libreriavsEntities())
            {
                return View(context.tema);
            }
        }
        [FiltroAdmin]
        [HttpPost]
        public ActionResult Insertar(tlibro libro)
        {
            using (libreriavsEntities context = new libreriavsEntities())
            {
                try
                {
                    libro.Precio = libro.Precio.Replace(".", ",");
                    libro.CodLibro = Util.GenerarCodigo(libro.GetType());
                    libro.Borrado = "0";
                    libro.Formatouno = libro.Formatouno == null ? "N/A" : libro.Formatouno;
                    libro.Formatodos = libro.Formatodos == null ? "N/A" : libro.Formatodos;
                    libro.Formatotres = libro.Formatotres == null ? "N/A" : libro.Formatotres;
                    context.tlibro.Add(libro);

                    if (context.SaveChanges() == 1)
                    {
                        return Content(Util.mostrarmensaje("Libro insertado correctamente", "Insertar"));
                    }
                    context.Database.BeginTransaction().Commit();
                }
                catch (Exception e)
                {
                    context.Database.BeginTransaction().Rollback();
                    return Content(Util.mostrarmensaje(Errores.ControlErrores(e), "Insertar"));
                }
                finally
                {
                    context.Database.BeginTransaction().Dispose();
                }

                return View(context.tema);
            }
        }
        [FiltroAdmin]
        public ActionResult Consultar()
        {
            using (libreriavsEntities context = new libreriavsEntities())
            {
                return View(context.tlibro.Where(o => o.Borrado.Equals("0")).ToList<tlibro>());
            }
        }
        public ActionResult Contacto()
        {
            return View();
        }
        [FiltroAdmin]
        public ActionResult Baja()
        {
            List<tlibro> list = new List<tlibro>();

            foreach (var item in control.Obtener(new tlibro().GetType()))
            {
                list.Add((tlibro)item);
            }
            return View(list);
        }
        [FiltroAdmin]
        [HttpPost]
        public ActionResult Baja(tlibro libro)
        {

            try
            {
                libro.Borrado = "0";
                libro.Formatouno = libro.Formatouno == null ? "N/A" : libro.Formatouno;
                libro.Formatodos = libro.Formatodos == null ? "N/A" : libro.Formatodos;
                libro.Formatotres = libro.Formatotres == null ? "N/A" : libro.Formatotres;
                if (control.BorradoVirtual(libro))
                {
                    return Content(Util.mostrarmensaje("Libro borrado correctamente", "Baja"));
                }
            }
            catch (Exception e)
            {
                return Content(Util.mostrarmensaje(Errores.ControlErrores(e), "Baja"));
            }

            List<tlibro> list = new List<tlibro>();

            foreach (var item in control.Obtener(new tlibro().GetType()))
            {
                list.Add((tlibro)item);
            }
            return View(list);
        }
        [FiltroAdmin]
        public ActionResult Modificar()
        {
            List<tlibro> list = new List<tlibro>();

            foreach (var item in control.Obtener(new tlibro().GetType()))
            {
                list.Add((tlibro)item);
            }
            object[] cosas = new object[2];
            cosas[0] = list;
            cosas[1] = control.Obtenertemas();
            return View(cosas);
        }
        [FiltroAdmin]
        [HttpPost]
        public ActionResult Modificar(tlibro libro)
        {

            try
            {
                libro.Precio = libro.Precio.Replace(".", ",");
                libro.Borrado = "0";
                libro.Formatouno = libro.Formatouno == null ? "N/A" : libro.Formatouno;
                libro.Formatodos = libro.Formatodos == null ? "N/A" : libro.Formatodos;
                libro.Formatotres = libro.Formatotres == null ? "N/A" : libro.Formatotres;
                control.Modificar(libro.CodLibro, libro);
            }
            catch (Exception e)
            {
                return Content(Util.mostrarmensaje(Errores.ControlErrores(e), "Modificar"));
            }

            List<tlibro> list = new List<tlibro>();

            foreach (var item in control.Obtener(new tlibro().GetType()))
            {
                list.Add((tlibro)item);
            }
            object[] cosas = new object[2];
            cosas[0] = list;
            cosas[1] = control.Obtenertemas();
            return View(cosas);
        }
    }
}