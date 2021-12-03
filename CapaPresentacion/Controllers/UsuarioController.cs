using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CapaNegocio;
using CapaEntidades;

namespace CapaPresentacion.Controllers
{
    public class UsuarioController : Controller
    {
        // GET: CrearUsuario
        
        public ActionResult menu()
        {

            return View();
        }
        public ActionResult menu2()
        {

            return View();
        }


        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(String correo, string clave)
        {
            Usuario_Negocio negocio = new Usuario_Negocio();

            var user = negocio.validar(correo, clave);

            if (user != null)
            {
                return View("menu");
            }

            else
            {

                ViewBag.Mensaje = "Datos Incorrectos";
                return View();
            }
        }

        public ActionResult CrearUsuario()
        {
            Usuario_Negocio negocio = new Usuario_Negocio();

            ViewData["lista"] = negocio.llenarlista().ToList();
            return View();
        }
        [HttpPost]
        public ActionResult CrearUsuario(Usuario parametro)
        {
            try
            {
                // TODO: Add insert logic here
                Usuario_Negocio negocio = new Usuario_Negocio();

                ViewData["lista"] = negocio.llenarlista().ToList();
                negocio.agregarUsuario(parametro);
                return RedirectToAction("menu","Usuario");
            }
            catch
            {
                return View();
            }
            
        }
 
        public ActionResult VerUsuario()
        {

            Usuario_Negocio negocio = new Usuario_Negocio();

            return View(negocio.mostrarUsuario());

        }


        public ActionResult Editar(int id)
        {
            Usuario_Negocio negocio = new Usuario_Negocio();

            ViewData["lista"] = negocio.llenarlista().ToList();
            var usuario = negocio.ObtenerUsuario(id);
            return View(usuario);
        }
        [HttpPost]
        public ActionResult Editar(Usuario usuario)
        {
            Usuario_Negocio negocio = new Usuario_Negocio();
            try
            {
                

                ViewData["lista"] = negocio.llenarlista().ToList();
                negocio.Editar(usuario);
                return RedirectToAction("VerUsuario", "Usuario");
            }
            catch (Exception ex)
            {
               return View();
            }
        }
   
        [HttpPost]
        public ActionResult Eliminar(int idd)
        {
            Usuario_Negocio negocio = new Usuario_Negocio();
            try
            {
                
                negocio.Eliminar(idd);
                return RedirectToAction("VerUsuario", "Usuario");
            }
            catch (Exception ex)
            {
                return View();
            }
        }

    }
}