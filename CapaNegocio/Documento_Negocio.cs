using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using CapaEntidades;
using System.Web.Mvc;

namespace CapaNegocio
{
    public class Documento_Negocio
    {
        Documento_Datos ejecutor = new Documento_Datos();
        public void agregardoc(documento elemento)
        {

            ejecutor.agregardoc(elemento);
        }
      
        public List<documento> mostrardoc()
        {
            return ejecutor.Mostrardoc();
            
        }

        public List<SelectListItem> llenarlista()
        {
            return ejecutor.Listadepto().ToList();

        }
        public List<SelectListItem> llenarlista2()
        {
            return ejecutor.Listaced().ToList();

        }

        Documento_Datos exe = new Documento_Datos();

        public documento ObtenerDoc(int id)
        {
            return exe.ObtenerDoc(id);
        }
        public void Editar(documento usuario)
        {
            exe.Editar(usuario);
        }

        public void Eliminar(int id)
        {
            exe.Eliminar(id);
        }


    }
}
