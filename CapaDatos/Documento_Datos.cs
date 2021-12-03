using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaEntidades;
using System.Web.Mvc;
using System.Text.RegularExpressions;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class Documento_Datos
    {
            ControlDocumentosEntities db = new ControlDocumentosEntities();

            public void agregardoc(documento doc)
            {
            int anio = DateTime.Now.Year;
            var fe = DateTime.Now;
            var fecha = fe.ToShortDateString();


            var code = string.Empty;
            var code2 = string.Empty;

            // ORIGEN DE

            code = Regex.Replace(doc.departamentoorigen, @"[\p{P}\p{S}\p{C}\p{N}]+", "");
            code = Regex.Replace(code, @"\p{Z}+", " ");
            code = Regex.Replace(code.Trim(), @"\s+(?:[JS]R|I{1,3}|I[VX]|VI{0,3})$", "", RegexOptions.IgnoreCase);
            code = Regex.Replace(code, @"^(\p{L})[^\s]*(?:\s+(?:\p{L}+\s+(?=\p{L}))?(?:(\p{L})\p{L}*)?)?$", "$1$2").Trim();


            if (code.Length > 2)
            {
                code = code.Substring(0, 2);
            }

            code = code.ToUpperInvariant();


            // DESTINO DE

            code2 = Regex.Replace(doc.departamentodestino, @"[\p{P}\p{S}\p{C}\p{N}]+", "");
            code2 = Regex.Replace(code2, @"\p{Z}+", " ");
            code2 = Regex.Replace(code2.Trim(), @"\s+(?:[JS]R|I{1,3}|I[VX]|VI{0,3})$", "", RegexOptions.IgnoreCase);
            code2 = Regex.Replace(code2, @"^(\p{L})[^\s]*(?:\s+(?:\p{L}+\s+(?=\p{L}))?(?:(\p{L})\p{L}*)?)?$", "$1$2").Trim();


            if (code2.Length > 2)
            {
                code2 = code2.Substring(0, 2);
            }

            code2 = code2.ToUpperInvariant();


            // SEUENCIA
            int no = 0;

            try
            {
                no = db.documento
                .OrderByDescending(x => x.iddoc)
                .First().iddoc;

                int secuencia = 1 + no;

                string codigo = anio + "-" + code + "-" + code2 + "-" + secuencia;
                doc.coddoc = codigo;
                doc.fechacreacion = Convert.ToString(fecha);


            }
            catch
            {

                no = 0;

                int secuencia = 1 + no;

                string codigo = anio + "-" + code + "-" + code2 + "-" + secuencia;
                doc.coddoc = codigo;
                doc.fechacreacion = Convert.ToString(fecha);

            }

            db.documento.Add(doc);
            db.SaveChanges();
            }
            public List<documento> Mostrardoc()
            {
                return db.documento.ToList();
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
        public List<SelectListItem> Listaced()
        {
            List<Usuario> list = null;

            using (ControlDocumentosEntities db = new ControlDocumentosEntities())
            {
                list = (from d in db.Usuario.AsEnumerable()
                       select new Usuario
                       {
                           Idempleado = d.Idempleado,
                           Cedula = d.Cedula
                       }).ToList();
            }

            //--------------------------------------------------------------------------
            List<SelectListItem> item = list.ConvertAll(d =>
            {
                return new SelectListItem()
                {
                    Text = d.Cedula.ToString(),
                    Value = d.Cedula.ToString(),
                    Selected = false

                };

            });

            return item;

        }
        public documento ObtenerDoc(int id)
        {

            string sql = @"select iddoc, tipodoc, coddoc, cedulaempleado, fechacreacion, departamentoorigen,
                 departamentodestino
                 from documento       
                where iddoc = @iddoc";
            using (var dbq = new ControlDocumentosEntities())
            {
                //return db.Empleado.Where(p => p.ProyectoId == id).FirstOrDefault();
                //return db.Empleado.Find(id);
                return dbq.Database.SqlQuery<documento>(sql,
                    new SqlParameter("@iddoc", id)).FirstOrDefault();
            }
        }
        public void Editar(documento doc)
        {
            using (var db = new ControlDocumentosEntities())
            {
                var origen = db.documento.Find(doc.iddoc);
                origen.tipodoc = doc.tipodoc;
                origen.cedulaempleado = doc.cedulaempleado;
                origen.departamentoorigen = doc.departamentoorigen;
                origen.departamentodestino = doc.departamentodestino;

                int anio = DateTime.Now.Year;

                var code = string.Empty;
                var code2 = string.Empty;

                // ORIGEN DE

                code = Regex.Replace(doc.departamentoorigen, @"[\p{P}\p{S}\p{C}\p{N}]+", "");
                code = Regex.Replace(code, @"\p{Z}+", " ");
                code = Regex.Replace(code.Trim(), @"\s+(?:[JS]R|I{1,3}|I[VX]|VI{0,3})$", "", RegexOptions.IgnoreCase);
                code = Regex.Replace(code, @"^(\p{L})[^\s]*(?:\s+(?:\p{L}+\s+(?=\p{L}))?(?:(\p{L})\p{L}*)?)?$", "$1$2").Trim();


                if (code.Length > 2)
                {
                    code = code.Substring(0, 2);
                }

                code = code.ToUpperInvariant();


                // DESTINO DE

                code2 = Regex.Replace(doc.departamentodestino, @"[\p{P}\p{S}\p{C}\p{N}]+", "");
                code2 = Regex.Replace(code2, @"\p{Z}+", " ");
                code2 = Regex.Replace(code2.Trim(), @"\s+(?:[JS]R|I{1,3}|I[VX]|VI{0,3})$", "", RegexOptions.IgnoreCase);
                code2 = Regex.Replace(code2, @"^(\p{L})[^\s]*(?:\s+(?:\p{L}+\s+(?=\p{L}))?(?:(\p{L})\p{L}*)?)?$", "$1$2").Trim();


                if (code2.Length > 2)
                {
                    code2 = code2.Substring(0, 2);
                }

                code2 = code2.ToUpperInvariant();


                // SEUENCIA
                int no = 0;


                    no = doc.iddoc;



                    string codigo = anio + "-" + code + "-" + code2 + "-" + no;
                    origen.coddoc = codigo;





                
                db.SaveChanges();
            }
        }
        public void Eliminar(int id)
        {
            using (var db = new ControlDocumentosEntities())
            {
                var doc = db.documento.Find(id);
                db.documento.Remove(doc);
                db.SaveChanges();
            }
        }
    }
}
