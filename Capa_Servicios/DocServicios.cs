using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using CapaEntidades;

namespace Capa_Servicios
{
    public class DocServicios
    {
        ControlDocumentosEntities db = new ControlDocumentosEntities();

        public List<date_range_Result> Buscarfecha(string fechainici, string fechafini)
        {
            return db.date_range(fechainici, fechafini).ToList();
        }
    }
}
