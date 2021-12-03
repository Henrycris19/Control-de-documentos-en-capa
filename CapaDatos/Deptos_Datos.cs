using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaEntidades;
using System.Web.Mvc;
using System.Data.SqlClient;
using System.Text.RegularExpressions;

namespace CapaDatos
{
    public class Deptos_Datos
    {
        ControlDocumentosEntities db = new ControlDocumentosEntities();

        public void agregardeptod (departamentos depto)
        {
            string code = Regex.Replace(depto.nombredepto, @"[\p{P}\p{S}\p{C}\p{N}]+", "");
            code = Regex.Replace(code, @"\p{Z}+", " ");
            code = Regex.Replace(code.Trim(), @"\s+(?:[JS]R|I{1,3}|I[VX]|VI{0,3})$", "", RegexOptions.IgnoreCase);
            code = Regex.Replace(code, @"^(\p{L})[^\s](?:\s+(?:\p{L}+\s+(?=\p{L}))?(?:(\p{L})\p{L})?)?$", "$1$2").Trim();


            if (code.Length > 2)
            {
                code = code.Substring(0, 2);
            }

            code = code.ToUpperInvariant();

            depto.codigodepto = code;

            db.departamentos.Add(depto);
            db.SaveChanges();
        }
        public List<departamentos> Mostrardepartamentos()
        {
            return db.departamentos.ToList();
        }
        public departamentos ObtenerDeptos(int id)
        {

            string sql = @"select Iddepto, codigodepto, nombredepto
                 from departamentos       
                where Iddepto = @Iddepto";
            using (var dbq = new ControlDocumentosEntities())
            {
               
                return dbq.Database.SqlQuery<departamentos>(sql,
                    new SqlParameter("@Iddepto", id)).FirstOrDefault();
            }
        }

        public void Editar(departamentos depto)
        {
            using (var db = new ControlDocumentosEntities())
            {
                var eje = db.departamentos.First(a => a.iddepto == depto.iddepto);
                
                string code = Regex.Replace(depto.nombredepto, @"[\p{P}\p{S}\p{C}\p{N}]+", "");
                code = Regex.Replace(code, @"\p{Z}+", " ");
                code = Regex.Replace(code.Trim(), @"\s+(?:[JS]R|I{1,3}|I[VX]|VI{0,3})$", "", RegexOptions.IgnoreCase);
                code = Regex.Replace(code, @"^(\p{L})[^\s](?:\s+(?:\p{L}+\s+(?=\p{L}))?(?:(\p{L})\p{L})?)?$", "$1$2").Trim();


                if (code.Length > 2)
                {
                    code = code.Substring(0, 2);
                }

                code = code.ToUpperInvariant();

                depto.codigodepto = code;

                var origen = db.departamentos.Find(depto.iddepto);

                eje.codigodepto = code;
                origen.nombredepto = depto.nombredepto;
                db.SaveChanges();
            }
        }
        public void Actualizardepto(departamentos depto)
        {
            var registro = db.departamentos.First(a => a.iddepto == depto.iddepto);

        }
        public void Eliminar(int id)
        {
            using (var db = new ControlDocumentosEntities())
            {
                var depto = db.departamentos.Find(id);
                db.departamentos.Remove(depto);
                db.SaveChanges();
            }
        }
    }
}
