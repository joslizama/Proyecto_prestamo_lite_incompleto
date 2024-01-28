using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using PagedList;
using PagedList.Mvc;
using Prestamos.Lite.Models;

namespace Prestamos.Lite.Controllers
{
    public class ClientesController : Controller
    {
        Conexion dbc = new Conexion();
        // GET: Clientes
        public ActionResult Index_cliente()
        {
            return View();
        } 
    //Menu de prestamos 
     public ActionResult Vprestamos(int?p)
     {
      var rut = Convert.ToString(Session["rut"]);
      TempData["lpagos"] = dbc.Tipo_pago.ToList(); 

      int r = 4;
      int np = p ?? 1;

      var lprestamos = dbc.Prestamoes.Where(x=>x.cliente_id.Equals(rut)).ToList();


       return View(lprestamos.ToPagedList(np, r));
     }
   //Nuevo prestamo vista 
   //public ActionResult Nprestamo()
   //{

   //}
   ////



    }
}