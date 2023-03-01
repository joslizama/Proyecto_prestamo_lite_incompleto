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
        public ActionResult Ltmonedas(int? p)
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
                nombre_divisa = nombre,
                abreviatura = abreviatura
            };

            dbc.Tipo_moneda.Add(tm);
            dbc.SaveChanges();

            return Json(JsonRequestBehavior.AllowGet);

        }
        //Modificar tipo de moneda vista
        public ActionResult Mtmoneda(int id)
        {
            if (id == null)
            {
                return RedirectToAction("Error_admin", "Admin");

            }
            else
            {

                var tmoneda = dbc.Tipo_moneda.Find(id);

                TempData["tipo_moneda"] = Convert.ToInt32(tmoneda.id);


                if (tmoneda == null)
                {
                    return RedirectToAction("Error_admin", "Admin");

                }
                else
                {

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

            if (c == null)
            {
                Response.Redirect("~/Admin/Error_admin");
            }
            else
            {

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

            if (id == null)
            {
                return RedirectToAction("Error_admin", "Admin");

            }
            else
            {

                var etmoneda = dbc.Tipo_moneda.Find(id);
                var etmoneda2 = Convert.ToInt32(etmoneda.id);


                if (etmoneda == null || etmoneda2 == null)
                {
                    return RedirectToAction("Error_admin", "Admin");

                }
                else
                {


                    var c = dbc.Prestamoes.Where(p => p.tipo_moneda_id == etmoneda2).SingleOrDefault();

                    if (c != null)
                    {
                        c.tipo_moneda_id = 1;
                        dbc.SaveChanges();

                        dbc.Tipo_moneda.Remove(etmoneda);
                        dbc.SaveChanges();

                        return RedirectToAction("Ltmonedas", "Admin");



                    }
                    else
                    {

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
                nombre = nombre_tpago,
                descripcion = descripcion,
                valor_dias = valor
            };
            dbc.Tipo_pago.Add(tp);
            dbc.SaveChanges();

            return Json(JsonRequestBehavior.AllowGet);

        }
        //Detalles tipo de pagos 
        public ActionResult Dtpago(int id)
        {
            if (id == null)
            {
                return RedirectToAction("Error_admin", "Admin");

            }
            else
            {

                var dtpago = dbc.Tipo_pago.Find(id);

                if (dtpago == null)
                {
                    return RedirectToAction("Error_admin", "Admin");
                }
                else
                {

                    return View(dtpago);

                }
            }
        }
        //Modificar tipo de pago vista 
        public ActionResult Mtpago(int id)
        {
            if (id == null)
            {
                return RedirectToAction("Error_admin", "Admin");

            }
            else
            {

                var mtpago = dbc.Tipo_pago.Find(id);
                TempData["mtpago"] = Convert.ToInt32(mtpago.id);

                if (mtpago == null)
                {
                    return RedirectToAction("Error_admin", "Admin");

                }
                else
                {

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

            if (c == null)
            {

                Response.Redirect("~/Admin/Error_admin");


            }
            else
            {



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
            if (id == null)
            {
                return RedirectToAction("Error_admin", "Admin");

            }
            else
            {

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


                }
                else
                {

                    dbc.Tipo_pago.Remove(etpago);

                    dbc.SaveChanges();

                    return RedirectToAction("Ltpago", "Admin");




                }
            }
        }
        //Listado de clientes 
        public ActionResult Lclientes(int? p)
        {
            TempData["ltipo"] = dbc.tipo_usuario.ToList();
            int r = 4;
            int np = p ?? 1;

            var lc = dbc.Clientes.ToList();


            return View(lc.ToPagedList(np, r));

        }
        //Listado de clientes filtrado
        public ActionResult Lclientes2(int?p)
        {
            TempData["ltipo"] = dbc.tipo_usuario.ToList();

            var tipo = Convert.ToInt32(Request.Form["tipo"]);

            int r = 4;
            int np = p ?? 1;

            if (tipo == 2)
            {

                var c = dbc.Usuarios.Where(x => x.tipo_id == tipo).SingleOrDefault();

                if (c == null)
                {
                    return RedirectToAction("Error_admin", "Admin");

                }
                else
                {

                    var idusuario = Convert.ToString(c.cliente_id);

                    var lcajeros = dbc.Clientes.Where(x => x.rut.Equals(idusuario)).ToList();


                    return View(lcajeros.ToPagedList(np,r));


                }

            }
            else if (tipo == 3){


                var c = dbc.Usuarios.Where(x => x.tipo_id == tipo).SingleOrDefault();

                if (c == null)
                {
                    return RedirectToAction("Error_admin", "Admin");

                }
                else
                {

                    var idusuario = Convert.ToString(c.cliente_id);

                    var lcliente = dbc.Clientes.Where(x => x.rut.Equals(idusuario)).ToList();


                    return View(lcliente.ToPagedList(np,r));






                }

                


            }
            else if (tipo == 1)
            {

                return RedirectToAction("Lclientes", "Admin");

            }

            
                return View();

        }
    //Detalle del cliente 
    public ActionResult Dcliente(string id)
    {

      if(id == null)
      {
       return RedirectToAction("Error_admin", "Admin");

      }else{

       var dcliente = dbc.Clientes.Find(id);

       if(dcliente == null)
       {
        return RedirectToAction("Error_admin", "Admin");

       }else{

        return View(dcliente);

       }
      }
    }
    //Nuevo cajero vista 
    public ActionResult Ncajero()
    {
      return View();
    } 
   //Nuevo cajero controlador 
   [HttpPost]
    public JsonResult Ncajeroc()
    {
            var rut =Convert.ToString(Request.Form["rut"]);
            var fecha = Convert.ToDateTime(Request.Form["fecha"]);
            var nombre = Convert.ToString(Request.Form["nombre"]);
            var apellido = Convert.ToString(Request.Form["apellido"]);
            var direccion = Convert.ToString(Request.Form["direccion"]);
            var comuna = Convert.ToString(Request.Form["comuna"]);
            var ciudad =Convert.ToString(Request.Form["ciudad"]);
            var correo = Convert.ToString(Request.Form["correo"]);
            var telefono = Convert.ToString(Request.Form["telefono"]);
            var contraseña =Convert.ToString(Request.Form["contraseña"]);


            Cliente c = new Cliente
            {
                rut=rut,
                fecha_nacimiento=fecha,
                nombre=nombre,
                apellido=apellido,
                direccion=direccion,
                comuna=comuna,
                ciudad=ciudad,
                correo=correo,
                telefono=telefono
            };
            dbc.Clientes.Add(c);
            dbc.SaveChanges();

            Usuario us = new Usuario
            {
                cliente_id=rut,
                contraseña=contraseña,
                tipo_id=2
            };
            dbc.Usuarios.Add(us);
            dbc.SaveChanges();


            return Json(JsonRequestBehavior.AllowGet);


    }
    //Eliminar cliente y cajero 
     public ActionResult Ecliente(string id)
     {
        if(id == null)
        {
          return RedirectToAction("Error_admin", "Admin");

        }else{

          var ecliente = dbc.Clientes.Find(id);
          var ec = Convert.ToString(ecliente.rut);

          //Obtener la id del usuario 

          var i = dbc.Usuarios.Where(p => p.cliente_id.Equals(ec)).SingleOrDefault();
          var i2 = Convert.ToInt32(i.id);
          var i3 = dbc.Usuarios.Find(i2);
          if(i == null)
          {
             return RedirectToAction("Error_admin", "Admin");

          }else{

                    //Eliminar cliente y cajero 
                    //Eliminar usuario

                    dbc.Clientes.Remove(ecliente);
                    dbc.SaveChanges();

                    dbc.Usuarios.Remove(i3);
                    dbc.SaveChanges();

                    return RedirectToAction("Lclientes", "Admin");
                    


          }

        }
     } 
    //Detalle del usuario 
     public ActionResult Dusuario(string id)
     {
       if(id == null)
       {
        return RedirectToAction("Error_admin", "Admin");

       }else{

        var dc = dbc.Clientes.Find(id);
        var dc2 = Convert.ToString(dc.rut);

        if (dc == null)
        {
          return RedirectToAction("Error_admin", "Admin");
        }else{

          var c = dbc.Usuarios.Where(p => p.cliente_id.Equals(dc2)).SingleOrDefault();

          var c2 = Convert.ToInt32(c.id);

          var usuario = dbc.Usuarios.Find(c2);


         if(usuario == null)
         {
          return RedirectToAction("Error_admin", "Admin");
         }else{


          return View(usuario);


         }      
        }
      }
    } 
    //Listado de prestamos 
    public ActionResult Lprestamos(int?p)
    {

     TempData["lpagos"] = dbc.Tipo_pago.ToList();



     int r = 4;
     int np = p ?? 1;

     var lp = dbc.Prestamoes.ToList();

     return View(lp.ToPagedList(np, r));

    } 
   //Detalle del prestamo vista 
    public ActionResult Dprestamos(int id)
    {

     if(id  == null)
     {
       return RedirectToAction("Error_admin", "Admin");

     }else{

       var dp = dbc.Prestamoes.Find(id);
       TempData["lpago"] = dbc.Tipo_pago.ToList();
       TempData["lmoneda"] = dbc.Tipo_moneda.ToList();
       TempData["lcliente"] = dbc.Clientes.ToList();


       if(dp == null)
       {
        return RedirectToAction("Error_admin", "Admin");

       }else{

        return View(dp);
       }
     }
    } 
   //Filtar los prestamos 
   [HttpPost] 
   public ActionResult LPrestamos2(int?p)
   {
        var fecha = Convert.ToString(Request.Form["fecha"]);
        var estados = Convert.ToString(Request.Form["estados"]);

            TempData["lpagos"] = dbc.Tipo_pago.ToList();

            int r = 4;
            int np = p ?? 1;


            if (fecha.Equals("Reciente"))
            {

                if (estados.Equals("Pagado"))
                {


                    var c = dbc.Prestamoes.SqlQuery("SELECT * FROM(SELECT * FROM Prestamo WHERE estado_prestamo = '" + estados + "') Prestamo ORDER BY fecha_registro_prestamo ASC ").ToList();


                    return View(c.ToPagedList(np, r));


                }else if (estados.Equals("Cancelado"))
                {
                    var c = dbc.Prestamoes.SqlQuery("SELECT * FROM(SELECT * FROM Prestamo WHERE estado_prestamo = '" + estados + "') Prestamo ORDER BY fecha_registro_prestamo ASC ").ToList();

                    return View(c.ToPagedList(np, r));
                    
                }
                else if(estados == null)
                {

                    var c = dbc.Prestamoes.SqlQuery("SELECT * FROM Prestamo ORDER BY fecha_registro_prestamo ASC").ToList();

                    return View(c.ToPagedList(np, r));






                }




            }
            else if (fecha.Equals("Antiguas"))
            {


                if (estados.Equals("Pagado"))
                {



                    var c = dbc.Prestamoes.SqlQuery("SELECT * FROM(SELECT * FROM Prestamo WHERE estado_prestamo = " + estados +  ") Prestamo ORDER BY fecha_registro_prestamo DESC").ToList();

                    return View(c.ToPagedList(np, r));








                }
                else if (estados.Equals("Cancelado"))
                {
                    var c = dbc.Prestamoes.SqlQuery("SELECT * FROM(SELECT * FROM Prestamo WHERE estado_prestamo = " + estados + ") Prestamo ORDER BY fecha_registro_prestamo DESC").ToList();

                    return View(c.ToPagedList(np, r));

                }
                else if (estados == null)
                {
                    var c = dbc.Prestamoes.SqlQuery("SELECT * FROM Prestamo ORDER BY fecha_registro_prestamo DESC").ToList();

                    return View(c.ToPagedList(np, r));

                }




            }
            else if (fecha == null){


                if (estados.Equals("Pagado"))
                {
                    var c = dbc.Prestamoes.SqlQuery("SELECT * FROM Prestamo WHERE estado_prestamo='" + estados + "'").ToList();

                    return View(c.ToPagedList(np, r));

                }
                else if (estados.Equals("Cancelado"))
                {
                    var c = dbc.Prestamoes.SqlQuery("SELECT * FROM Prestamo WHERE estado_prestamo='" + estados + "'").ToList();

                    return View(c.ToPagedList(np, r));

                }
                else if (estados == null)
                {

                    return RedirectToAction("Lprestamos", "Admin");

                }
                
            }

            return View();

        } 
   //Nuevo prestamo vista 

    public ActionResult Nprestamos()
    {
      TempData["lpago"] = dbc.Tipo_pago.ToList();
      TempData["lmoneda"] = dbc.Tipo_moneda.ToList();

      return View();

    }
        //Nuevo prestamos controlador
        [HttpPost]
        public JsonResult Nprestamosc()
        {
            var tmoneda = Convert.ToInt32(Request.Form["tmoneda"]);
            var tpago = Convert.ToInt32(Request.Form["tpago"]);
            var monto = Convert.ToDouble(Request.Form["monto"]);
            var cuotas = Convert.ToInt32(Request.Form["cuotas"]);
            var fechainicio = Convert.ToString(Request.Form["fechainicio"]);
            var fechafin = Convert.ToString(Request.Form["fechafin"]);
            var interes = Convert.ToDouble(Request.Form["interes"]);
            var mcuotassininteres = Convert.ToDouble(Request.Form["mcuotassininteres"]);
            var mcuotasconinteres = Convert.ToDouble(Request.Form["mcuotasconinteres"]);
            var total = Convert.ToDouble(Request.Form["total"]);
            var rcliente = Convert.ToString(Request.Form["rcliente"]);
            var clausulas = Convert.ToString(Request.Form["clausulas"]);



            //Modificar la fecha de inicio de pago 

            var fechainicio2 = DateTime.UtcNow.ToString(fechainicio);
            var fechainicio3 = Convert.ToDateTime(fechainicio2);


            var fechafin2 = DateTime.UtcNow.ToString(fechafin);
            var fechafin3 = Convert.ToDateTime(fechafin2);


            //Agregar prestamos 

            Prestamo p = new Prestamo
            {
                fecha_registro_prestamo = DateTime.Today,
                tipo_moneda_id = tmoneda,
                tipo_pago_id = tpago,
                fecha_inicio_pago = fechainicio3,
                fecha_fin_pago = fechafin3,
                monto_prestamo = monto,
                numero_cuotas = cuotas,
                intereses = interes,
                monto_cuotas_sin_interes = mcuotassininteres,
                monto_cuotas_con_interes = mcuotasconinteres,
                total_prestamo = total,
                cliente_id = rcliente,
                estado_prestamo = "En proceso",
                clausulas = clausulas


            };

            dbc.Prestamoes.Add(p);
            dbc.SaveChanges();

            var pid = Convert.ToInt32(p.numero_operacion);

            //Obtener el mes de la fecha 
            var m = Convert.ToInt32(fechainicio3.Month);
            ////Obtener la fecha separada 
            //var d = Convert.ToString(fechainicio3.Day);
            ////var m2 = Convert.ToString(fechafin3.Month);
            //var a = Convert.ToString(fechafin3.Year);

            //Hacer el for para crear registros de cuotas 

            var ncuotas = Convert.ToInt32(cuotas);

            //Obtener la fecha separada 
            var d = Convert.ToString(fechainicio3.Day);
            //var m2 = Convert.ToString(fechafin3.Month);
            var a = Convert.ToString(fechafin3.Year);

            //Generar la fecha 

            //var m2 = Convert.ToInt32(i);

            //var fc = Convert.ToString(a + "-" + m + "-" + d);

            //var fc2 = DateTime.UtcNow.ToString(fc);
            ////Fecha valida 
            //var fc3 = Convert.ToDateTime(fc2);

            //Hacer un for de cuotas 
            
            for(int i = 1; i <= ncuotas; i++)
            {
                //Sumar los meses a la cutoa 
                var m2 = Convert.ToInt32(m + i);

                //Generar el año mediante string 

                var s = Convert.ToString(a + " - " + m2 + " - " + d);

                var s2 = Convert.ToDateTime(DateTime.UtcNow.ToString(s));


                Cuota c = new Cuota
                {
                    prestamo_id = pid,
                    numero_cuota=i,
                    fecha_pago_cuota=s2,
                    monto_cuota=mcuotasconinteres,
                    estado_cuota="Por pagar",
                    fecha_pago_cliente=null

                };

                dbc.Cuotas.Add(c);
                dbc.SaveChanges();

            }




            return Json(JsonRequestBehavior.AllowGet);

    }
   //Listado de cuotas del prestamo 
   public ActionResult Lcuotas(int?p,int id)
   {

      int r = 4;
      int np = p ?? 1;


      var idp = Convert.ToInt32(id);


      //var lcuotas = dbc.Cuotas.Where(x=> x.prestamo_id == idp).SingleOrDefault(); 


     //if(lcuotas == null)
     //{
     //  return RedirectToAction("Error_admin", "Admin");

     //}else{

      var lcuotas2 = dbc.Cuotas.Where(x => x.prestamo_id == idp).ToList();


       return View(lcuotas2.ToPagedList(np, r));


     //}
   }
  //Pagar la cuota 
  public ActionResult Pcuotas(int id)
  {

    if(id == null)
    {
      return RedirectToAction("Error_admin", "Admin");

    }else{

     var pcuota = dbc.Cuotas.Find(id);
     var pcuota2 = Convert.ToInt32(pcuota.numero_cuota);

     if(pcuota == null)
     {
      return RedirectToAction("Error_admin", "Admin");

     }else{

      var c = dbc.Cuotas.Where(p => p.numero_cuota== pcuota2).SingleOrDefault();

      if(c == null)
      {
       return RedirectToAction("Error_admin", "Admin");

      }else{

       c.estado_cuota = "Pagado";
       dbc.SaveChanges();

       return RedirectToAction("Lcuotas", "Admin");



      }
     }
    }
  } 
 //Cancelar prestamos 
  public ActionResult Cprestamo(int id)
  {
    if(id == null)
    {
      return RedirectToAction("Error_admin", "Admin");

    }else{

     var cp = dbc.Prestamoes.Find(id);
     var cp2 = Convert.ToInt32(cp.numero_operacion);

     if (cp == null)
     {
      return RedirectToAction("Error_admin", "Admin");

     }else{




       var x = dbc.Prestamoes.Where(p => p.numero_operacion == cp2).SingleOrDefault();

       x.estado_prestamo = "Cancelado";

       var cadena = Convert.ToString("Cancelado");

       var z = dbc.Database.ExecuteSqlCommand("UPDATE Cuotas SET estado_cuota = '" + cadena + "' WHERE prestamo_id ='" + cp2 + "' ");

       dbc.SaveChanges();

       return RedirectToAction("Lprestamos","Admin");


     }
     
   }
  }
 //



    }
}