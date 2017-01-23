using Libreria_V6.Filtro;
using LibreriaV3._1.Comun;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

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
                return View(context.tema.ToList<tema>());
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
                        context.Database.BeginTransaction().Commit();
                        return Content(Util.mostrarmensaje("Libro insertado correctamente", "Insertar"));
                    }
                }
                catch (Exception e)
                {
                    context.Database.BeginTransaction().Rollback();
                    return Content(Util.mostrarmensaje(Errores.ControlErrores(e), "Insertar"));
                }
                return View(context.tema);
            }
        }

        [FiltroAdmin]
        public ActionResult Consultar()
        {

            using (libreriavsEntities context = new libreriavsEntities())
            {
                try
                {
                    return View(context.tlibro.Where(o => o.Borrado.Equals("0")).ToList<tlibro>());
                }
                catch (Exception e)
                {
                    return Content(Util.mostrarmensaje(Errores.ControlErrores(e), "Insertar"));
                }

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
            using (libreriavsEntities context = new libreriavsEntities())
            {
                try
                {
                    return View(context.tlibro.Where(o => o.Borrado.Equals("0")).ToList<tlibro>());
                }
                catch (Exception e)
                {
                    return Content(Util.mostrarmensaje(Errores.ControlErrores(e), "Insertar"));
                }

            }
        }
        [FiltroAdmin]
        [HttpPost]
        public ActionResult Baja(tlibro libro)
        {
            using (libreriavsEntities context = new libreriavsEntities())
            {
                try
                {
                    context.tlibro.Find(libro.CodLibro).Borrado = "1";
                    context.tlibro.Find(libro.CodLibro).Formatouno = libro.Formatouno == null ? "N/A" : libro.Formatouno;
                    context.tlibro.Find(libro.CodLibro).Formatodos = libro.Formatodos == null ? "N/A" : libro.Formatodos;
                    context.tlibro.Find(libro.CodLibro).Formatotres = libro.Formatotres == null ? "N/A" : libro.Formatotres;
                    if (context.SaveChanges() == 1)
                    {
                        context.Database.BeginTransaction().Commit();
                        return Content(Util.mostrarmensaje("Libro borrado correctamente", "Baja"));
                    }
                }
                catch (Exception e)
                {
                    context.Database.BeginTransaction().Rollback();
                    return Content(Util.mostrarmensaje(Errores.ControlErrores(e), "Baja"));
                }
                return View(context.tlibro.ToList<tlibro>());
            }

        }
        [FiltroAdmin]
        public ActionResult Modificar()
        {
            using (libreriavsEntities context = new libreriavsEntities())
            {
                object[] cosas = new object[2];
                cosas[0] = context.tlibro.ToList<tlibro>();
                cosas[1] = context.tema.ToList<tema>();
                return View(cosas);
            }

        }
        [FiltroAdmin]
        [HttpPost]
        public ActionResult Modificar(tlibro libro)
        {
            using (libreriavsEntities context = new libreriavsEntities())
            {
                try
                {
                    context.tlibro.Find(libro.CodLibro).Titulo = libro.Titulo;
                    context.tlibro.Find(libro.CodLibro).Autor = libro.Autor;
                    context.tlibro.Find(libro.CodLibro).tema = libro.tema;
                    context.tlibro.Find(libro.CodLibro).Paginas = libro.Paginas;
                    context.tlibro.Find(libro.CodLibro).Precio = libro.Precio.Replace(".", ",");
                    context.tlibro.Find(libro.CodLibro).Borrado = "0";
                    context.tlibro.Find(libro.CodLibro).Formatouno = libro.Formatouno == null ? "N/A" : libro.Formatouno;
                    context.tlibro.Find(libro.CodLibro).Formatodos = libro.Formatodos == null ? "N/A" : libro.Formatodos;
                    context.tlibro.Find(libro.CodLibro).Formatotres = libro.Formatotres == null ? "N/A" : libro.Formatotres;
                    context.tlibro.Find(libro.CodLibro).Estado = libro.Estado;
                    context.SaveChanges();
                    context.Database.BeginTransaction().Commit();
                }
                catch (Exception e)
                {
                    context.Database.BeginTransaction().Rollback();
                    return Content(Util.mostrarmensaje(Errores.ControlErrores(e), "Modificar"));
                }
                object[] cosas = new object[2];
                cosas[0] = context.tlibro.ToList<tlibro>(); ;
                cosas[1] = context.tema.ToList<tema>();
                return View(cosas);
            }

        }
    }
}