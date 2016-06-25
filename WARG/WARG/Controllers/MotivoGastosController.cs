using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Entidades;
using Negocio;

namespace WARG.Models
{
   // [Authorize]
    public class MotivoGastosController : Controller
    {    

        // GET: MotivoGastos
        [Authorize(Roles = "Admin,Administracion,Cobranzas,Comercial,Compras,Contabilidad,PostVenta,Registros,Sistemas")]
        public ActionResult Index()
        {
            var motivoLN = new MotivoLN();
            return View(motivoLN.Listar());
        }
                
        public ActionResult Details(int id)
        {            
            try
            {
                var motivoLN = new MotivoLN();
                var motivo = motivoLN.Obtener(id);
                return View(motivo);
            }
            catch (Exception ex)
            {
                @ViewBag.DescripcionError = ex.Message;
                @ViewData["Controller"] = ControllerContext.RouteData.Values["Controller"].ToString();
                @ViewData["Acción"] = ControllerContext.RouteData.Values["Action"].ToString();

                return View("Error");
            }

        }

        // GET: MotivoGastos/Create
        public ActionResult Create()
        {
            return View();
        }
                
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MotivoID,Motivo")] MotivoGasto motivoGasto)
        {            
            try
            {
                var motivoLN = new MotivoLN();
                motivoLN.Insertar(motivoGasto);               
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {

                @ViewBag.DescripcionError = ex.Message;
                @ViewData["Controller"] = ControllerContext.RouteData.Values["Controller"].ToString();
                @ViewData["Acción"] = ControllerContext.RouteData.Values["Action"].ToString();

                return View("Error");
            }            
        }
                
        public ActionResult Edit(int id)
        {            
            try
            {
                var motivoLN = new MotivoLN();
                var motivo = motivoLN.Obtener(id);               
                return View(motivo);
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
        public ActionResult Edit([Bind(Include = "MotivoID,Motivo")] MotivoGasto motivoGasto)
        {     
            try
            {
                var motivoLN = new MotivoLN();
                if (motivoLN.Actualizar(motivoGasto))
                    return RedirectToAction("Index");
                else
                {
                    ViewBag.Categorias = motivoLN.Listar();// ListarCategorias();
                    return View(motivoGasto);
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
                
        public ActionResult Delete(int id)
        {
            try
            {
                var motivoLN = new MotivoLN();                
                var motivo = motivoLN.Obtener(id);                
                return View(motivo);

            }
            catch (Exception ex)
            {

                @ViewBag.DescripcionError = ex.Message;
                @ViewData["Controller"] = ControllerContext.RouteData.Values["Controller"].ToString();
                @ViewData["Acción"] = ControllerContext.RouteData.Values["Action"].ToString();

                return View("Error");
            }
        }
                
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {            
            try
            {         
                var motivoLN = new MotivoLN();
                if (!motivoLN.Eliminar(id))

                    throw new Exception("Error al eliminar el Motivo");
                return RedirectToAction("Index");


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
