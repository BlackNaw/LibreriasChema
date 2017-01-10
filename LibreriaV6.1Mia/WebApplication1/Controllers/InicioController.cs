using Libreria_V6.Controllers;
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
        private ControlAccesoDAO<object> control = new ControlAccesoDAO<object>();
        public ActionResult Inicio()
        {
            try
            {
                Util.RellenarDictionarySentencias();
                
            }
            catch(Exception e)
            {
                Util.mostrarmensaje(Errores.ControlErrores(e), "");
            }
            return View(rellenarLibros());
        }
        public ActionResult Administrar()
        {
            return View("~/Views/Libro/InicioLibro.cshtml");
        }

        public ActionResult Perfil()
        {
            return View();
        }

        public ActionResult Desconectar()
        {
            Session.Clear();
            return Inicio();
        }
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(TUsuario usuario)
        {
            
             TUsuario temporal = control.Buscar(usuario.GetType(), "Nick", usuario.Nick).Count==0? null: (TUsuario)control.Buscar(usuario.GetType(), "Nick", usuario.Nick).First();
           
            if (usuario.Rol == null)
            {
                if (ComprobarUsuario(usuario,temporal))
                {
                    if (temporal.Rol.Equals("admin"))
                    {
                        return View("~/Views/Libro/InicioLibro.cshtml");
                    }
                    else
                    {
                        return View("Inicio", rellenarLibros());

                    }
                }
                return Content(Util.mostrarmensaje("Usuario o contraseña erróneos", ""));
            }
            if (!ComprobarUsuario(usuario,temporal))
            {
                return Content(Util.mostrarmensaje("El usuario ya existe", ""));
            }
            //todo: dar de alta
            return Content(Util.mostrarmensaje("Dado de alta correctamente", ""));
        }

        private bool ComprobarUsuario(TUsuario usuario,TUsuario temporal)
        {

            if (usuario.Rol==null&& temporal!=null){
                if(usuario.Pass.Equals(temporal.Pass))
                {
                    return true;
                }
            }else if(usuario.Rol!= null && temporal==null)
            {
                return true;
            }
            return false;
        }

        private List<TLibro> rellenarLibros()
        {
            List<TLibro> list = new List<TLibro>();
            try
            {

                foreach (var item in control.Obtener(new TLibro().GetType()))
                {
                    list.Add((TLibro)item);
                }

            }
            catch (Exception ex)
            {
                throw;
            }
            return list;
        }
    }
}