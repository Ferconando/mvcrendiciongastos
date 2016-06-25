using System;
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
            var tipodocumentoLogicaNegocio = new TipoDocumentoLogicaNegocio();
            ViewBag.Categorias = motivoLN.Listar();//productoLN.ListarCategorias();
            ViewBag.TipoDocumentos = tipodocumentoLogicaNegocio.Listar();

            return View();
        }
        [HttpPost]
        public ActionResult Grabar(/*RendicionViewModel*/Rendicion model)
        {
          
                var lista = (List<RendicionDetalle>)Session["SelectListP"];
                model.RendicionDetalle=lista;
                var rendicionLN = new RendicionLN();                
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
                //var tipodocumentLogica = new TipoDocumentoLogica();
                var rendicion = rendicionLN.Obtener(id);
                //@ViewBag.rendicion = rendicionLN.Obtener(id);  
                var motivoLN = new MotivoLN();
                var tipodocumentoLogicaNegocio = new TipoDocumentoLogicaNegocio();
                ViewBag.Categorias = motivoLN.Listar();//productoLN.ListarCategorias();
                ViewBag.TipoDocumentos = tipodocumentoLogicaNegocio.Listar();
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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Rendicion rendicion)
        {
            try
            {
                var rendicionLN = new RendicionLN();
                if (rendicionLN.Editar(rendicion))
                    return RedirectToAction("Index");
                else
                {
                    //ViewBag.Categorias = rendicionLN.Listar();// ListarCategorias();
                    return View(rendicion);
                }
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