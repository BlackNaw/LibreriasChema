using Libreria_V6;
using Libreria_V6.Controllers;
using Libreria_V6.Filtro;
using LibreriaV3._1.Comun;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{
    public class InicioController : Controller
    {
        public ActionResult Inicio()
        {

            return View("~/Views/Inicio/Inicio.cshtml", rellenarLibros());
        }
        [FiltroAdmin]
        public ActionResult Administrar()
        {
            return View("~/Views/Libro/InicioLibro.cshtml");
        }
        [FiltroUser]
        public ActionResult Perfil()
        {
            return View(datosPerfil());
        }

        [FiltroUser]
        public ActionResult Desconectar()
        {
            Session.Clear();
            return View("Inicio", rellenarLibros());
        }
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(tusuario usuario)
        {
            using (libreriavsEntities contex = new libreriavsEntities())
            {
                tusuario temporal = contex.tusuario.Where(o => o.Nick.Equals(usuario.Nick)).First<tusuario>();
                if (usuario.Rol == null)
                {
                    if (ComprobarUsuario(usuario, temporal))
                    {
                        Session.Add("usuario", temporal);
                        if (temporal.Rol.Equals("admin"))
                        {
                            return View("~/Views/Libro/InicioLibro.cshtml");
                        }
                        else
                        {
                            return View("Inicio", rellenarLibros());
                        }
                    }
                    return Content(Util.mostrarmensaje("Usuario o contraseña erróneos", "Login"));
                }
                if (!ComprobarUsuario(usuario, temporal))
                {
                    return Content(Util.mostrarmensaje("El usuario ya existe", "Login"));
                }
                try
                {
                    usuario.CodUsuario = Util.GenerarCodigo(usuario.GetType());
                    contex.tusuario.Add(usuario);
                    contex.SaveChanges();
                    contex.Database.BeginTransaction().Commit();

                }
                catch (Exception e)
                {
                    contex.Database.BeginTransaction().Rollback();
                    return Content(Util.mostrarmensaje(Errores.ControlErrores(e), "Login"));
                }
                return Content(Util.mostrarmensaje("Dado de alta correctamente", "Login"));
            }
        }

        [FiltroUser]
        [HttpPost]
        public ActionResult Detalle(tfactura factura)
        {
            string usuario = ((tusuario)Session["usuario"]).Nick;
            using (libreriavsEntities context = new libreriavsEntities())
            {
                try
                {
                    tfactura facturaAux = context.tfactura.Find(factura.CodFactura);
                    List<tlineafactura> list = context.tlineafactura.Where(o => o.CodFactura.Equals(factura.CodFactura)).ToList<tlineafactura>();
                    object[] obj = { usuario, list, facturaAux };
                    return View(obj);
                }
                catch (Exception e)
                {
                    return Content(Util.mostrarmensaje(Errores.ControlErrores(e), "Inicio"));
                }
            }
        }

        [FiltroUser]
        [HttpPost]
        public ActionResult Perfil(tfactura factura)
        {
            using (libreriavsEntities context = new libreriavsEntities())
            {
                try
                {
                    context.tfactura.Find(factura.CodFactura).Borrado = "1";
                    context.SaveChanges();
                    context.Database.BeginTransaction().Commit();

                }
                catch (Exception e)
                {
                    context.Database.BeginTransaction().Rollback();
                    return Content(Util.mostrarmensaje(Errores.ControlErrores(e), "Perfil"));
                }
                return View(datosPerfil());
            }
        }

        [FiltroUser]
        [HttpPost]
        public ActionResult Inicio(string a)
        {

            HttpCookie cookie = Request.Cookies.Get("CODIGO");
            cookie.Path = "/Inicio";
            if (cookie != null)
            {
                tusuario usuario = (tusuario)Session["usuario"];
                String[] codigos = (cookie.Value).Split('_');
                cookie.Expires = DateTime.Parse("Thu, 01 Jan 1970 00:00:00 GMT");
                Response.Cookies.Add(cookie);

                try
                {
                    crearFactura(buscarLibros(codigos), usuario);
                }
                catch (Exception e)
                {
                    return Content(Util.mostrarmensaje(Errores.ControlErrores(e), "Inicio"));
                }


                //return View("Perfil", datosPerfil());
            }

            return View(rellenarLibros());

        }
        private object[] datosPerfil()
        {
            tusuario usuario = (tusuario)Session["usuario"];
            List<tfactura> facturas = new List<tfactura>();
            Dictionary<string, decimal> totales = new Dictionary<string, decimal>();
            decimal aux;
            using (libreriavsEntities context = new libreriavsEntities())
            {
                try
                {
                    foreach (tfactura item in context.tfactura.Where(o => o.Cliente.Equals(usuario.Nick) && o.Borrado.Equals("0")).ToList<tfactura>())
                    {
                        if (item.Borrado.Equals("0"))
                        {
                            aux = 0;
                            facturas.Add(item);
                            foreach (tlineafactura linea in context.tlineafactura.Where(o => o.CodFactura.Equals(item.CodFactura)).ToList<tlineafactura>())
                            {
                                aux += decimal.Parse(linea.Total);
                            }
                            totales.Add(item.CodFactura, aux);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Util.mostrarmensaje(Errores.ControlErrores(ex), "Inicio");
                }
            }

            object[] obj = { facturas, totales, usuario.Nick };
            return obj;
        }

        private bool ComprobarUsuario(tusuario usuario, tusuario temporal)
        {

            if (usuario.Rol == null && temporal != null)
            {
                if (usuario.Pass.Equals(temporal.Pass))
                {
                    return true;
                }
            }
            else if (usuario.Rol != null && temporal == null)
            {
                return true;
            }
            return false;
        }

        private List<tlibro> rellenarLibros()
        {
            List<tlibro> list = new List<tlibro>();
            try
            {
                using (libreriavsEntities contex = new libreriavsEntities())
                {
                    list = contex.tlibro.ToList<tlibro>();
                }
            }
            catch (Exception ex)
            {
                Util.mostrarmensaje(Errores.ControlErrores(ex), "Inicio");
            }

            return list;
        }

        private List<tlibro> buscarLibros(String[] codigos)
        {
            List<tlibro> listlibro = new List<tlibro>();
            try
            {
                using (libreriavsEntities contex = new libreriavsEntities())
                {
                    foreach (var codigo in codigos)
                    {
                        if (!codigo.Equals(""))
                        {
                            listlibro.Add((tlibro)contex.tlibro.Where<tlibro>(o => o.CodLibro.Equals(codigo)));
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                Util.mostrarmensaje(Errores.ControlErrores(ex), "Inicio");
            }
            return listlibro;
        }

        private void crearFactura(List<tlibro> listlibro, tusuario usuario)
        {
            List<tlineafactura> listAux = new List<tlineafactura>();

            using (libreriavsEntities context = new libreriavsEntities())
            {
                tfactura factura = new tfactura();
                factura.Cliente = usuario.Nick;
                factura.Borrado = "0";
                factura.CodFactura = Util.GenerarCodigo(factura.GetType());
                factura.FechaFactura = Convert.ToString(DateTime.Now);
                try
                {
                    context.tfactura.Add(factura);
                    foreach (tlibro libro in listlibro)
                    {
                        int contador = 0;
                        for (int i = 0; i < listlibro.Count; i++)
                        {
                            if (listlibro[i].CodLibro.Equals(libro.CodLibro))
                            {
                                contador++;
                            }
                        }
                        tlineafactura lineaFactura = new tlineafactura();
                        lineaFactura.CodFactura = factura.CodFactura;
                        lineaFactura.Libro = libro.Titulo;
                        lineaFactura.Cantidad = Convert.ToString(contador);
                        lineaFactura.Total = Convert.ToString(double.Parse(libro.Precio) * contador);
                        if (!listAux.Contains(lineaFactura))
                        {
                            listAux.Add(lineaFactura);
                            //Si inserta un libro repetido dará fallo, así que lo meto en un try catch
                            context.tlineafactura.Add(lineaFactura);
                        }

                    }
                    context.SaveChanges();
                    context.Database.BeginTransaction().Commit();
                }
                catch (Exception ex)
                {
                    context.Database.BeginTransaction().Rollback();
                    Util.mostrarmensaje(Errores.ControlErrores(ex), "Inicio");
                }

            }

        }
    }
}