using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using PagedList;
using PagedList.Mvc;
using Prestamos.Lite.Models;


namespace Prestamos.Lite.Controllers
{
    public class AdminController : Controller
    {
        Conexion dbc = new Conexion();
        // GET: Admin
        public ActionResult Index_admin()
        {
            return View();
        }
        //Listado de tipo de monedas 
        public ActionResult Ltmonedas(int?p)
        {
          int r = 2;
          int np = p ?? 1;

          var ltmonedas = dbc.Tipo_moneda.ToList();

            return View(ltmonedas.ToPagedList(np, r));

        }
    //Nueva moneda controlador 
    [HttpPost] 
    public JsonResult Ntmonedasc()
    {
            var nombre = Convert.ToString(Request.Form["nombre"]);
            var abreviatura = Convert.ToString(Request.Form["abreviatura"]);

            Tipo_moneda tm = new Tipo_moneda
            {
                nombre_divisa=nombre,
                abreviatura=abreviatura
            };

            dbc.Tipo_moneda.Add(tm);
            dbc.SaveChanges();

            return Json(JsonRequestBehavior.AllowGet);

    } 
   //Modificar tipo de moneda vista
    public ActionResult Mtmoneda(int id)
    {
      if(id == null)
      {
        return RedirectToAction("Error_admin", "Admin");

      }else{

       var tmoneda = dbc.Tipo_moneda.Find(id);

       TempData["tipo_moneda"] = Convert.ToInt32(tmoneda.id);


        if(tmoneda == null)
        {
         return RedirectToAction("Error_admin", "Admin");

        }else{

          return View(tmoneda);



        }
      }
    } 
   //Modificar tipo de monedas controlador 
   [HttpPost] 
    public JsonResult Mtmonedac()
    {

       var i = Convert.ToInt32(TempData["tipo_moneda"]);
       var nombre = Convert.ToString(Request.Form["nombre"]);
       var abreviatura = Convert.ToString(Request.Form["abreviatura"]);


       var c = dbc.Tipo_moneda.Where(p => p.id == i).SingleOrDefault();

       if(c == null)
       {
           Response.Redirect("~/Admin/Error_admin");
       }else{

                c.nombre_divisa = nombre;
                c.abreviatura = abreviatura;

                dbc.SaveChanges();

                return Json(JsonRequestBehavior.AllowGet);

       }
            return Json(JsonRequestBehavior.AllowGet);
    }
    //




    }
}