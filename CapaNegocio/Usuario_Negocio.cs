
using CapaDatos;
using CapaEntidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;


namespace CapaNegocio
{

    public class Usuario_Negocio
    {

        Usuario_Datos ejecutor = new Usuario_Datos();
        public void agregarUsuario(Usuario elemento)
        {
            ejecutor.agregarusuario(elemento);
        }
        public List<Usuario> mostrarUsuario()
        {
            return ejecutor.MostrarUsuario();
        }
        public List<SelectListItem> llenarlista()
        {
            return ejecutor.Listadepto().ToList();

        }


        Usuario_Datos exe = new Usuario_Datos();

        public Usuario ObtenerUsuario(int id)
        {
            return exe.ObtenerUsuario(id);
        }
        public void Editar(Usuario usuario)
        {
            exe.Editar(usuario);
        }

        public void Eliminar(int id)
        {
            exe.Eliminar(id);
        }
        public Usuario validar(string correo, string clave) 
        {
            return ejecutor.validar(correo, clave);
        }

    }
}
