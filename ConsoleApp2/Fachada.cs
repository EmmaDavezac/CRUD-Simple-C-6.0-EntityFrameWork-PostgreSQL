using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApp2.Models;

namespace ConsoleApp2
{   /// <summary>
/// Esta clase es la fachada principal del programa, permite que podamos usar las funciones del sistema sin dar a conocer la implementacion interna
/// </summary>
    public  class Fachada
    {
        /// <summary>
        /// Agrega un Blog a la Base de Datos
        /// </summary>
        /// <param name="url"></param>
        public void AgregarBlog(string url)
        {
                using (PostgreSQLDBContext PGDBContext = new PostgreSQLDBContext())
                {
                    int id=0;
                    if (PGDBContext.Blogs is null) { id = 1; } else { id = PGDBContext.Blogs.Count() + 1; }
                    Models.Blog blog = new Models.Blog(id, url);
                    PGDBContext.Blogs.Add(blog);
                    PGDBContext.SaveChanges();
                }

        }
        /// <summary>
        /// Actualiza un Blog de la Base de Datos
        /// </summary>
        /// <param name="id"></param>
        /// <param name="url"></param>
        public void ActualizarBlog(int id,string url)
        {
            using (PostgreSQLDBContext PGDBContext = new PostgreSQLDBContext())
            {
                if (PGDBContext.Blogs is not null)
                {
                    Models.Blog resultado = PGDBContext.Find<Models.Blog>(id);
                    if (resultado is not null)
                    { resultado.ActualizarBlog(url); }
                    PGDBContext.SaveChanges();
                }
            }
        }

        /// <summary>
        /// Actualiza un Blog de la Base de Datos
        /// </summary>
        /// <param name="id"></param>
        /// <param name="url"></param>
        public void RemoverBlog(int id)
        {
            using (PostgreSQLDBContext PGDBContext = new PostgreSQLDBContext())
            {
                if (PGDBContext.Blogs is not null)
                {
                    Models.Blog resultado = PGDBContext.Find<Models.Blog>(id);
                    if (resultado is not null)
                    { PGDBContext.Remove(resultado); }
                    PGDBContext.SaveChanges();
                }
            }
        }

        /// <summary>
        /// Leer un Blog de la Base de Datos
        /// </summary>
        /// <param name="id"></param>
        /// <param name="url"></param>
        public Models.Blog LeerBlog(int id)
        {
            Models.Blog resultado = new Models.Blog();
            using (PostgreSQLDBContext PGDBContext = new PostgreSQLDBContext())
            {
                if (PGDBContext.Blogs is not null)
                {
                    resultado = PGDBContext.Find<Models.Blog>(id);

                }
                return resultado;
            }
        }
    }
}
