using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Entidades;
//using WARG.Models;
using Negocio;

namespace WARG.Controllers
{    

    public class RendicionController : Controller
    {        
        //private ApplicationDbContext db = new ApplicationDbContext();
        //private RendicionContext db = new RendicionContext();
       
        //
        // GET: /Rendicion/
        public ActionResult Index(RendicionViewModel model)
        {
           
             Session["SelectListP"] = null;
             if (TempData["Mensaje"] != null)
             {
                 ViewBag.Mensaje = TempData["Mensaje"].ToString();
             }
            
            return View();
        }
        [HttpPost]
        public ActionResult Grabar(/*RendicionViewModel*/Rendicion model)
        {
            //var Hoy = DateTime.Today;
            //string fecha_actual = Hoy.ToString("dd-MM-yyyy");
 
                var lista = (List<RendicionDetalle>)Session["SelectListP"];
                //RendicionCabecera cabecera = new RendicionCabecera();
                Rendicion cabecera = new Rendicion();
                //cabecera.PK_RENDICION = model.PK_RENDICION;
                //cabecera.ATRIBUTO1_CABECERA = model.ATRIBUTO1_CABECERA;
                //cabecera.ATRIBUTO2_CABECERA = model.ATRIBUTO2_CABECERA;
                cabecera.RendicionID = 001000010;
                cabecera.ESTADO_PLANILLA = "PENDIENTE";
                cabecera.FECHA_CAMBIO_ESTADO = DateTime.Today;
                cabecera.FECHA_CREACION = DateTime.Today;
                cabecera.FECHA_RENDICION_FIN = DateTime.Today;
                cabecera.FECHA_RENDICION_INI = DateTime.Today;
                cabecera.FICHA_EMPLEADO = "42085432";
                cabecera.FONDO_INICIAL = 1000;
                cabecera.GLOSA_GASTOS = "Prueba1";
                cabecera.TOTAL_GASTADO = 1000;
                RendicionDetalle Rendiciondetalle = new RendicionDetalle();
                cabecera.RendicionDetalle = lista;
                //cabecera.DETALLERENDICION = lista;
                Rendiciondetalle.FECHA_GASTO = DateTime.Today;
                Rendiciondetalle.GLOSA = "Arroz";
                Rendiciondetalle.MONTO_LINEA = 100;
                Rendiciondetalle.NUMERO_DOCTO = "123456789";
                Rendiciondetalle.RAZON_SOCIAL = "Los Gastos S.A";
                Rendiciondetalle.SECUENCIA = 1;
                Rendiciondetalle.TIPO_DOCTO = "Boleta";
                Rendiciondetalle.RendicionID = 001000010;
                Rendiciondetalle.MotivoID = 1;

                

                if (ModelState.IsValid)
                {       
                    
                    //db.MotivoGastoes.Add(Rendicion);
                    
                  //  db.SaveChanges();
                    return RedirectToAction("Index");
                }
                
                //CABECERA-DETALLE lista para insertar con ADO, ENTITY,ETC.
                ModelState.Clear();
                TempData["Mensaje"] = "REGISTRO COMPLETADO!";
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
	}
}