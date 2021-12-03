using CapaEntidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class Usuario_Datos
    {
        ControlDocumentosEntities db = new ControlDocumentosEntities();

        public void agregarusuario(Usuario usuario)
        {
            db.Usuario.Add(usuario);
            db.SaveChanges();
        }
        public List<Usuario> MostrarUsuario()
        {
            return db.Usuario.ToList();
        }

        public Usuario ObtenerUsuario(int id)
        {
            
            string sql = @"select Idempleado, Nombre, Cedula, Correo, Clave, Departamento,
                 Cargo
                 from Usuario       
                where Idempleado = @Idempleado";
            using (var dbq = new ControlDocumentosEntities())
            {
                //return db.Empleado.Where(p => p.ProyectoId == id).FirstOrDefault();
                //return db.Empleado.Find(id);
                return dbq.Database.SqlQuery<Usuario>(sql,
                    new SqlParameter("@Idempleado", id)).FirstOrDefault();
            }
        }
        public void Editar(Usuario usuario)
        {
            using (var db = new ControlDocumentosEntities())
            {
                var origen = db.Usuario.Find(usuario.Idempleado);
                origen.Nombre = usuario.Nombre;
                origen.Cedula = usuario.Cedula;
                origen.Correo = usuario.Correo;
                origen.Clave = usuario.Clave;
                origen.Departamento = usuario.Departamento;
                origen.Cargo = usuario.Cargo;
                db.SaveChanges();
            }
        }
        public void ActualizarUsuario(Usuario usuario)
        {
            var registro = db.Usuario.First(a => a.Cedula == usuario.Cedula);

        }

        public List<SelectListItem> Listadepto()
        {
            List<departamentos> lst = null;

            using (ControlDocumentosEntities db = new ControlDocumentosEntities())
            {
                lst = (from d in db.departamentos.AsEnumerable()
                       select new departamentos
                       {
                           iddepto = d.iddepto,
                           nombredepto = d.nombredepto
                       }).ToList();
            }

            //--------------------------------------------------------------------------
            List<SelectListItem> item = lst.ConvertAll(d =>
            {
                return new SelectListItem()
                {
                    Text = d.nombredepto.ToString(),
                    Value = d.nombredepto.ToString(),
                    Selected = false

                };

            });

            return item;

        }
        public void Eliminar(int id)
        {
            using (var db = new ControlDocumentosEntities())
            {
                var usuario = db.Usuario.Find(id);
                db.Usuario.Remove(usuario);
                db.SaveChanges();
            }
        }
        public Usuario validar(string correo, string clave)
        {
            var usuario = db.Usuario.FirstOrDefault(a => a.Correo == correo && a.Clave == clave);
            
            return usuario;

        }
    }
}
