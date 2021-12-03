using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CapaNegocio;
using CapaEntidades;

namespace CapaPresentacion.Controllers
{
    public class DeptoController : Controller
    {
       Deptos_Negocio negocio = new Deptos_Negocio();

        // GET: CrearDepto/Create
        public ActionResult CrearDepto()
        {
            return View();
        }


        // POST: CrearDepto/Create
        [HttpPost]
        public ActionResult CrearDepto(departamentos parametro)
        {
            try
            {
                // TODO: Add insert logic here
                negocio.agregardepartamentos(parametro);
                return RedirectToAction("menu","Usuario");
            }
            catch
            {
                return View();
            }
        }


        public ActionResult Editar(int id)
        {
            Deptos_Negocio negocio = new Deptos_Negocio();

            var depto = negocio.ObtenerDepto(id);
            return View(depto);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar(departamentos depto)
        {
            Deptos_Negocio negocio = new Deptos_Negocio();
            try
            {

                negocio.Editar(depto);
                return RedirectToAction("VerDeptos");
            }
            catch (Exception ex)
            {
                return View();
            }
        }
        public ActionResult VerDeptos()
        {

            Deptos_Negocio negocio = new Deptos_Negocio();

            return View(negocio.mostrardepartamentos());

        }

        public ActionResult Eliminar(int idd)
        {
            Deptos_Negocio negocio = new Deptos_Negocio();
            try
            {
                negocio.Eliminar(idd);
                return RedirectToAction("VerDeptos", "Depto");
            }
            catch (Exception ex)
            {
                return View();
            }
        }
    }
}
