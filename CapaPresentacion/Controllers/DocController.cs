using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CapaNegocio;
using CapaEntidades;

namespace CapaPresentacion.Controllers
{
    public class DocController : Controller
    {

        // GET: Doc
        public ActionResult Index()
        {
            return View();
        }

        // GET: Doc/Details/5
        public ActionResult Detalles(int id)
        {
            Documento_Negocio negocio = new Documento_Negocio();
            var empleado = negocio.ObtenerDoc(id);
            return View(empleado);
        }

        public ActionResult VerDoc()
        {

            Documento_Negocio negocio = new Documento_Negocio();

            return View(negocio.mostrardoc());

        }
        public ActionResult VerDocEm()
        {

            Documento_Negocio negocio = new Documento_Negocio();

            return View(negocio.mostrardoc());

        }
        public ActionResult VerDocDepO()
        {

            Documento_Negocio negocio = new Documento_Negocio();

            return View(negocio.mostrardoc());

        }
        public ActionResult VerDocDepD()
        {

            Documento_Negocio negocio = new Documento_Negocio();

            return View(negocio.mostrardoc());

        }


        // GET: Doc/Create
        public ActionResult Creardoc()
        {
            Documento_Negocio negocio = new Documento_Negocio();

            ViewData["lista"] = negocio.llenarlista().ToList();
            ViewData["lista2"] = negocio.llenarlista2().ToList();
            return View();
        }

        // POST: Doc/Create
        [HttpPost]
        public ActionResult Creardoc(documento parametro)
        {
            try
            {
                // TODO: Add insert logic here
                //ViewData["item"] = negocio.llenarlista();
                Documento_Negocio negocio = new Documento_Negocio();

                ViewData["lista"] = negocio.llenarlista().ToList();
                ViewData["lista2"] = negocio.llenarlista2().ToList();
                negocio.agregardoc(parametro);
                return RedirectToAction("menu","Usuario");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Editar(int id)
        {
            Documento_Negocio negocio = new Documento_Negocio();

            ViewData["lista"] = negocio.llenarlista().ToList();
            ViewData["lista2"] = negocio.llenarlista2().ToList();
            var doc = negocio.ObtenerDoc(id);
            return View(doc);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar(documento doc)
        {
            Documento_Negocio negocio = new Documento_Negocio();
            try
            {


                ViewData["lista"] = negocio.llenarlista().ToList();
                ViewData["lista2"] = negocio.llenarlista2().ToList();
                negocio.Editar(doc);
                return RedirectToAction("menu", "Usuario");
            }
            catch (Exception ex)
            {
                return View();
            }
        }
        // GET: Doc/Delete/5
       
        [HttpPost]
        public ActionResult Eliminar(int idd)
        {
            Documento_Negocio negocio = new Documento_Negocio();
            try
            {
                
                negocio.Eliminar(idd);
                return RedirectToAction("VerDoc", "Doc");
            }
            catch (Exception ex)
            {
                return View();
            }
        }
    }
}
