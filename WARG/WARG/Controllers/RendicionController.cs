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
                model.RendicionDetalle(lista);
                var rendicionLN = new RendicionLN();
                //model.RendicionDetalle(lista);
                rendicionLN.Insertar(model);
                return RedirectToAction("Index");

            //}
            //catch (Exception ex)
            //{

            //    @ViewBag.DescripcionError = ex.Message;
            //    @ViewData["Controller"] = ControllerContext.RouteData.Values["Controller"].ToString();
            //    @ViewData["Acción"] = ControllerContext.RouteData.Values["Action"].ToString();

            //    return View("Error");
            //}


            //var rendicionLN = new RendicionLN();
            //string fecha_actual = Hoy.ToString("dd-MM-yyyy"); 
            
            //RendicionCabecera cabecera = new RendicionCabecera();               


            //RendicionDetalle Detalle = new RendicionDetalle();
            //cabecera.RendicionDetalle = lista;
            //cabecera.DETALLERENDICION = lista;                   

            //Rendicion cabecera = new Rendicion();
            //cabecera.PK_RENDICION = model.PK_RENDICION;
            //cabecera.ATRIBUTO1_CABECERA = model.ATRIBUTO1_CABECERA;
            //cabecera.ATRIBUTO2_CABECERA = model.ATRIBUTO2_CABECERA;
            //cabecera.NumeroRendicion = 001000010;
            //cabecera.ESTADO_PLANILLA = "PENDIENTE";
            //cabecera.FECHA_CAMBIO_ESTADO = DateTime.Today;
            //cabecera.FECHA_CREACION = DateTime.Today;
            //cabecera.FECHA_RENDICION_FIN = DateTime.Today;
            //cabecera.FECHA_RENDICION_INI = DateTime.Today;
            //cabecera.FICHA_EMPLEADO = "42085432";
            //cabecera.FONDO_INICIAL = 1000;
            //cabecera.GLOSA_GASTOS = "Prueba1";
            //cabecera.TOTAL_GASTADO = 1000;
            //db.Rendiciones.Add(cabecera);

            //RendicionDetalle detalle = new RendicionDetalle();
            //var lista = (List<RendicionDetalle>)Session["SelectListP"];
            
            //detalle.FECHA_GASTO = DateTime.Today;
            //detalle.GLOSA = "Arroz";
            //detalle.MONTO_LINEA = 100;
            //detalle.NUMERO_DOCTO = "123456789";
            //detalle.RAZON_SOCIAL = "Los Gastos S.A";
            //detalle.SECUENCIA = 1;
            //detalle.TIPO_DOCTO = "Boleta";
            //detalle.NumeroRendicion = 001000010;
            //detalle.MotivoID = 1;
            //db.RendicioneDetalle.Add(lista);
            //db.SaveChanges();

            //if (ModelState.IsValid)
            //{
            //    //db.MotivoGastoes.Add(Rendicion);                    
            //    //  db.SaveChanges();
            //    return RedirectToAction("Index");
            //}

            //CABECERA-DETALLE lista para insertar con ADO, ENTITY,ETC.
            //ModelState.Clear();
            //TempData["Mensaje"] = "REGISTRO COMPLETADO!";
            //return RedirectToAction("Index");


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