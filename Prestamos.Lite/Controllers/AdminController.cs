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
    //Eliminar tipo de moneda 
    public ActionResult Etmoneda(int id)
    {
    
     if(id == null)
     {
        return RedirectToAction("Error_admin", "Admin");

     }else{

      var etmoneda = dbc.Tipo_moneda.Find(id);
      var etmoneda2 = Convert.ToInt32(etmoneda.id);


      if(etmoneda == null||etmoneda2 == null)
      {
        return RedirectToAction("Error_admin", "Admin");

      }else{


        var c = dbc.Prestamoes.Where(p => p.tipo_moneda_id == etmoneda2).SingleOrDefault();

        if (c != null)
        {
           c.tipo_moneda_id = 1;
           dbc.SaveChanges();

           dbc.Tipo_moneda.Remove(etmoneda);
           dbc.SaveChanges();

           return RedirectToAction("Ltmonedas", "Admin");



        }else{

         dbc.Tipo_moneda.Remove(etmoneda);
         dbc.SaveChanges();

         return RedirectToAction("Ltmonedas", "Admin");



        }
      }
     }
    } 
    //Listado de tipo de pagos 
    public ActionResult Ltpago(int? p)
    {
      int r = 3;
      int np = p ?? 1;

      var ltpago = dbc.Tipo_pago.ToList();

      return View(ltpago.ToPagedList(np, r));

    } 
    //Nuevo tipo de pago controlador 
    [HttpPost] 
    public JsonResult Ntipopagoc()
    {
            var nombre_tpago = Convert.ToString(Request.Form["nombre_tpago"]);
            var descripcion = Convert.ToString(Request.Form["descripcion"]);
            var valor = Convert.ToInt32(Request.Form["valor"]);


            Tipo_pago tp = new Tipo_pago
            {
                nombre=nombre_tpago,
                descripcion=descripcion,
                valor_dias = valor
            };
            dbc.Tipo_pago.Add(tp);
            dbc.SaveChanges();

            return Json(JsonRequestBehavior.AllowGet);

    }
   //Detalles tipo de pagos 
   public ActionResult Dtpago(int id)
   {
     if(id == null)
     {
       return RedirectToAction("Error_admin", "Admin");

     }else{

      var dtpago = dbc.Tipo_pago.Find(id);

      if(dtpago == null)
      {
       return RedirectToAction("Error_admin", "Admin");
      }else{

        return View(dtpago);

      }
     }
   } 
  //Modificar tipo de pago vista 
   public ActionResult Mtpago(int id)
   {
     if(id == null)
     {
       return RedirectToAction("Error_admin", "Admin");

     }else{

      var mtpago = dbc.Tipo_pago.Find(id);
      TempData["mtpago"] = Convert.ToInt32(mtpago.id);

      if(mtpago == null)
      {
       return RedirectToAction("Error_admin", "Admin");

      }else{

       return View(mtpago);
      }
    }
   }
  //Modificar tipo de pago controlado 
   [HttpPost] 
   public JsonResult Mtpagoc()
   {
      var i = Convert.ToInt32(TempData["mtpago"]);

     var nombre_tpago = Convert.ToString(Request.Form["nombre_tpago"]);
     var descripcion = Convert.ToString(Request.Form["descripcion"]);
     var valor = Convert.ToInt32(Request.Form["valor"]);

      var c = dbc.Tipo_pago.Where(p => p.id == i).SingleOrDefault();

       if(c == null)
       {

         Response.Redirect("~/Admin/Error_admin");


       }else{



                c.nombre = nombre_tpago;
                c.descripcion = descripcion;
                c.valor_dias = valor;

                dbc.SaveChanges();


                return Json(JsonRequestBehavior.AllowGet);



     }
            return Json(JsonRequestBehavior.AllowGet);
   }
   //Eliminar tipo de pago 
   public ActionResult Etpago(int id)
   {
    if(id == null)
    {
      return RedirectToAction("Error_admin", "Admin");

    }else{

     var etpago = dbc.Tipo_pago.Find(id);
     var etpago2 = Convert.ToInt32(etpago.id);

     var c = dbc.Prestamoes.Where(p => p.tipo_pago_id == etpago2).SingleOrDefault();

     if (c != null)
     {
        c.tipo_pago_id = 1;
        dbc.SaveChanges();

        dbc.Tipo_pago.Remove(etpago);

        dbc.SaveChanges();

        return RedirectToAction("Ltpago", "Admin");


     }else{

        dbc.Tipo_pago.Remove(etpago);

        dbc.SaveChanges();

        return RedirectToAction("Ltpago", "Admin");




       }
     } 
   } 
  //


    }
}