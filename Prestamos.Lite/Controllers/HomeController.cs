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
    public class HomeController : Controller
    {
        Conexion dbc = new Conexion(); 
        // GET: Home
        public ActionResult Index()
        {
            return View();
        } 
    //Iniciar sesion vista 
     public ActionResult Login()
     {
      return View(); 

     } 
    //Login controlador 
    [HttpPost] 
    public ActionResult Logc()
    {
            var rut = Convert.ToString(Request.Form["rut"]);
            var contraseña = Convert.ToString(Request.Form["contraseña"]);

            //Hacer login del usuario 
            var c = dbc.Usuarios.Where(p => p.cliente_id == rut && p.contraseña == contraseña).SingleOrDefault();

            if(c == null)
            {
                return RedirectToAction("Error", "Home");
            }
            else
            {
                //Opcion de tipo de usuario 

                var op = Convert.ToInt32(c.tipo_id);


                switch (op)
                {

                    case 1:

                        var x = dbc.Clientes.Where(p => p.rut == rut).SingleOrDefault();

                        if (x == null)
                        {
                            return RedirectToAction("Error", "Home");
                        }
                        else
                        {

                            Session["rut"] = Convert.ToString(x.rut);
                            Session["nombre"] = Convert.ToString(x.nombre);
                            Session["apellido"] = Convert.ToString(x.apellido);
                            Session["tipo"] = Convert.ToInt32(1);

                            return RedirectToAction("Index_admin", "Admin");
                            

                        }




                        break;
                    case 2:
                        var f = dbc.Clientes.Where(p => p.rut == rut).SingleOrDefault();

                        if (f == null)
                        {
                            return RedirectToAction("Error", "Home");
                        }
                        else
                        {

                            Session["rut"] = Convert.ToString(f.rut);
                            Session["nombre"] = Convert.ToString(f.nombre);
                            Session["apellido"] = Convert.ToString(f.apellido);
                            Session["tipo"] = Convert.ToInt32(2); 

                            return RedirectToAction("Index_cajero", "Cajero");

                            
                        }

                        break;

                    case 3:
                        var g = dbc.Clientes.Where(p => p.rut == rut).SingleOrDefault();

                        if (g == null)
                        {
                            return RedirectToAction("Error", "Home");
                        }
                        else
                        {

                            Session["rut"] = Convert.ToString(g.rut);
                            Session["nombre"] = Convert.ToString(g.nombre);
                            Session["apellido"] = Convert.ToString(g.apellido);
                            Session["tipo"] = Convert.ToInt32(3);

                            return RedirectToAction("Index_cliente", "Cliente");

                        }

                        break;
                        
                    default:
                        return RedirectToAction("Error", "Home");
                        break;

                }
                
            }

            return View();
    }
    //



    }
}