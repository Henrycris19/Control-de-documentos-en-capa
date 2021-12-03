using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Capa_Servicios;

namespace CapaPresentacion.Controllers
{
    public class ReportesController : Controller
    {
        DocServicios serv = new DocServicios();
        // GET: Reportes
        public ActionResult VerDocFecha()
        {
            return View();
        }

        [HttpPost]
        public ActionResult VerDocFechaRes(string fechaini, string fechafinal)
        {
            return View(serv.Buscarfecha(fechaini, fechafinal));
        }
    }
}