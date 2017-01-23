using Libreria_V6;
using Libreria_V6.Controllers;
using Libreria_V6.Filtro;
using LibreriaV3._1.Comun;
using LibreriaV3._1.Negocio;
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
        //private ControlAccesoDAO<object> control = new ControlAccesoDAO<object>();
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
            using (libreriavsEntities context = new libreriavsEntities()) {
                tusuario temporal = context.tusuario.Find(usuario)/*.Equals(null)?null:context.tusuario.Find(usuario)*/;
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
                    control.Insertar(usuario);
                }
                catch (Exception e)
                {
                    return Content(Util.mostrarmensaje(Errores.ControlErrores(e), "Login"));
                }
                return Content(Util.mostrarmensaje("Dado de alta correctamente", "Login"));
            } }
        [FiltroUser]
        [HttpPost]
        public ActionResult Detalle(TFactura factura)
        {
            string usuario = ((TUsuario)Session["usuario"]).Nick;
            TFactura facturaAux = (TFactura)control.Buscar(factura.GetType(), factura.CodFactura);
            List<TLineaFactura> list = new List<TLineaFactura>();
            foreach (TLineaFactura item in control.Buscar(new TLineaFactura().GetType(), "CodFactura", factura.CodFactura))
            {
                list.Add(item);
            }

            object[] obj = { usuario, list, facturaAux };
            return View(obj);
        }
        [FiltroUser]
        [HttpPost]
        public ActionResult Perfil(TFactura factura)
        {
            TFactura facturaAux = (TFactura)control.Buscar(factura.GetType(), factura.CodFactura);
            control.BorradoVirtual(facturaAux);
            return View(datosPerfil());
        }
        [FiltroUser]
        [HttpPost]
        public ActionResult Inicio(string a)
        {

            HttpCookie cookie = Request.Cookies.Get("CODIGO");
            cookie.Path = "/Inicio";
            if (cookie != null)
            {
                TUsuario usuario = (TUsuario)Session["usuario"];

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
            TUsuario usuario = (TUsuario)Session["usuario"];
            List<TFactura> facturas = new List<TFactura>();
            Dictionary<string, decimal> totales = new Dictionary<string, decimal>();
            decimal aux;
            foreach (TFactura item in control.Buscar(new TFactura().GetType(), "Cliente", usuario.Nick))
            {
                if (item.Borrado.Equals("0"))
                {
                    aux = 0;
                    facturas.Add(item);
                    foreach (TLineaFactura linea in control.Buscar(new TLineaFactura().GetType(), "CodFactura", item.CodFactura))
                    {
                        aux += decimal.Parse(linea.Total);
                    }
                    totales.Add(item.CodFactura, aux);

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
                using(libreriavsEntities context=new libreriavsEntities())
                {
                    list = context.tlibro.ToList<tlibro>();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return list;
        }

        private List<TLibro> buscarLibros(String[] codigos)
        {
            List<TLibro> listLibro = new List<TLibro>();

            foreach (string cod in codigos)
            {
                if (!cod.Equals(""))
                {
                    listLibro.Add((TLibro)control.Buscar(new TLibro().GetType(), "CodLibro", cod)[0]);
                }
            }
            return listLibro;
        }

        private void crearFactura(List<TLibro> listLibro, TUsuario usuario)
        {
            List<TLineaFactura> listAux = new List<TLineaFactura>();
            TFactura factura = new TFactura(usuario.Nick);
            control.Insertar(factura);
            foreach (TLibro libro in listLibro)
            {
                int contador = 0;
                for (int i = 0; i < listLibro.Count; i++)
                {
                    if (listLibro[i].CodLibro.Equals(libro.CodLibro))
                    {
                        contador++;
                    }
                }
                TLineaFactura lineaFactura = new TLineaFactura(factura.CodFactura, libro.Titulo, Convert.ToString(contador), Convert.ToString(double.Parse(libro.Precio) * contador));

                try
                {
                    if (!listAux.Contains(lineaFactura))
                    {
                        listAux.Add(lineaFactura);
                        //Si inserta un libro repetido dará fallo, así que lo meto en un try catch
                        control.Insertar(lineaFactura);
                    }
                }
                catch (Exception e) { }
            }
        }
    }
}