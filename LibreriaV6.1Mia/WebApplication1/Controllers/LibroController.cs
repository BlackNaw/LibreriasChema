﻿using Libreria_V6.Filtro;
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
        [FiltroAdmin]
        public ActionResult Insertar()
        {
            return View(control.ObtenerTemas());
        }
        [FiltroAdmin]
        [HttpPost]
        public ActionResult Insertar (TLibro libro)
        {
           
            try
            {
                libro.Precio = libro.Precio.Replace(".", ",");
                libro.CodLibro = Util.GenerarCodigo(libro.GetType());
                libro.Borrado = "0";
                libro.Formatouno = libro.Formatouno == null ? "N/A" : libro.Formatouno;
                libro.Formatodos = libro.Formatodos  == null ? "N/A" : libro.Formatodos;
                libro.Formatotres  = libro.Formatotres == null ? "N/A" : libro.Formatotres;
                if (control.Insertar(libro)) {
                    return Content(Util.mostrarmensaje("Libro insertado correctamente", "Insertar"));
                }
                    
            }catch(Exception e)
            {
                return Content(Util.mostrarmensaje(Errores.ControlErrores(e), "Insertar"));
            }

            return View(control.ObtenerTemas());
        }
        [FiltroAdmin]
        public ActionResult Consultar()
        {
            List<TLibro> list = new List<TLibro>();

            foreach (var item in control.Obtener(new TLibro().GetType()))
            {
                list.Add((TLibro)item);
            }
            
            return View(list);
        }
        public ActionResult Contacto()
        {
            return View();
        }
        [FiltroAdmin]
        public ActionResult Baja()
        {
            List<TLibro> list = new List<TLibro>();

            foreach (var item in control.Obtener(new TLibro().GetType()))
            {
                list.Add((TLibro)item);
            }
            return View(list);
        }
        [FiltroAdmin]
        [HttpPost]
        public ActionResult Baja(TLibro libro)
        {

            try
            {
                libro.Borrado = "0";
                libro.Formatouno = libro.Formatouno == null ? "N/A" : libro.Formatouno;
                libro.Formatodos = libro.Formatodos == null ? "N/A" : libro.Formatodos;
                libro.Formatotres = libro.Formatotres == null ? "N/A" : libro.Formatotres;
                if (control.BorradoVirtual(libro)) {
                    return Content(Util.mostrarmensaje("Libro borrado correctamente", "Baja"));
                }
            }
            catch (Exception e)
            {
                return Content(Util.mostrarmensaje(Errores.ControlErrores(e), "Baja"));
            }

            List<TLibro> list = new List<TLibro>();

            foreach (var item in control.Obtener(new TLibro().GetType()))
            {
                list.Add((TLibro)item);
            }
            return View(list);
        }
        [FiltroAdmin]
        public ActionResult Modificar()
        {
            List<TLibro> list = new List<TLibro>();

            foreach (var item in control.Obtener(new TLibro().GetType()))
            {
                list.Add((TLibro)item);
            }
            object[] cosas = new object[2];
            cosas[0] = list;
            cosas[1] = control.ObtenerTemas();
            return View(cosas);
        }
        [FiltroAdmin]
        [HttpPost]
        public ActionResult Modificar(TLibro libro)
        {

            try
            {
                libro.Precio= libro.Precio.Replace(".",",");
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

            List<TLibro> list = new List<TLibro>();

            foreach (var item in control.Obtener(new TLibro().GetType()))
            {
                list.Add((TLibro)item);
            }
            object[] cosas = new object[2];
            cosas[0] = list;
            cosas[1] = control.ObtenerTemas();
            return View(cosas);
        }
        }
    }