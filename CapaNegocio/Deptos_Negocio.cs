using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using CapaEntidades;

namespace CapaNegocio
{
    public class Deptos_Negocio
    {
        Deptos_Datos ejecutor = new Deptos_Datos();
        public void agregardepartamentos(departamentos elemento)
        {
            ejecutor.agregardeptod(elemento);
        }
        public List<departamentos> mostrardepartamentos()
        {
            return ejecutor.Mostrardepartamentos();
        }
        Deptos_Datos exe = new Deptos_Datos();

        public departamentos ObtenerDepto(int id)
        {
            return exe.ObtenerDeptos(id);
        }

        public void Editar(departamentos depto)
        {
            exe.Editar(depto);
        }

        public void Eliminar(int id)
        {
            exe.Eliminar(id);
        }

    }
}
