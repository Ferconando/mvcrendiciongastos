﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Entidades;
//using WARG.Models;
using Negocio;
//using AccesoDatos;

namespace WARG.Controllers
{

    public class RendicionController : Controller
    {
            
        // GET: /Rendicion/
        public ActionResult Index(RendicionDetalle /*RendicionViewModel*/ model)
        {

            Session["SelectListP"] = null;
            if (TempData["Mensaje"] != null)
            {
                ViewBag.Mensaje = TempData["Mensaje"].ToString();
            }

            var motivoLN = new MotivoLN();
            ViewBag.Categorias = motivoLN.Listar();//productoLN.ListarCategorias();

            return View();
        }
        [HttpPost]
        public ActionResult Grabar(/*RendicionViewModel*/Rendicion model)
        {
            //try
            //{
                //Modelbinding se encarga de buscar en la cabecera del mensaje HTTP POst
                //la informacion del producto enviado desde la vista y construye el objeto
                //Producto que espera el controlador como parametro
                //cabecera.RendicionDetalle = lista;
                var lista = (List<RendicionDetalle>)Session["SelectListP"];
                model.RendicionDetalle=lista;
                var rendicionLN = new RendicionLN();
                //model.RendicionDetalle(lista);
                rendicionLN.Insertar(model);                
                return RedirectToAction("Index");
           
        }

        public ActionResult SessionJSON(String id)
        {
            Session["SelectListP"] = null;
            id = "[" + id + "]";
            var selectList = (List<RendicionDetalle>)Session["SelectListP"] ?? new List<RendicionDetalle>();
            selectList = new System.Web.Script.Serialization.JavaScriptSerializer().Deserialize<List<RendicionDetalle>>(id.Replace("Field", ""));
            Session["SelectListP"] = selectList;
            return View();
        }

        // GET: Lista las rendiciones
        public ActionResult ListarRendicion(string usuarioLogueado)
        {
            var rendicionLN = new RendicionLN();
            return View(rendicionLN.Listar(usuarioLogueado));
        }

        public ActionResult Edit(int id)
        {
            try
            {
                var rendicionLN = new RendicionLN();
                var rendicion = rendicionLN.Obtener(id);
                //@ViewBag.rendicion = rendicionLN.Obtener(id);          
                return View("EditarRendicion",rendicion);
            }
            catch (Exception ex)
            {
                @ViewBag.DescripcionError = ex.Message;
                @ViewData["Controller"] = ControllerContext.RouteData.Values["Controller"].ToString();
                @ViewData["Acción"] = ControllerContext.RouteData.Values["Action"].ToString();

                return View("Error");
            }        
        }

    }
}