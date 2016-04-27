using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Entidades;
using Negocio;

namespace WARG.Controllers
{
    public class MotivoController : Controller
    {
        // GET: Motivo
        public ActionResult Index()
        {
            try
            {
                //   throw new Exception("Prueba de Error");
                var motivoLN = new MotivoLN();
                var motivo = motivoLN.Listar();
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
    }
}