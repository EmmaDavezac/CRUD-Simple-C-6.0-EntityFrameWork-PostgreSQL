using System;
using System.Collections.Generic;

namespace ConsoleApp2.Models
{   /// <summary>
    /// Esta clase modela la informacion relevante de un Blog
    /// </summary>
    public partial class Blog

    {   /// <summary>
        /// Constructor de una instancia de Blog
        /// </summary>
        /// <param name="id" ></param>
        /// <param name="url"></param>
        public Blog(int id,string url)
        
        {
            Id = id;
            Url = url;
            Posts = new HashSet<Post>();
        }

        /// Constructor de una instancia de Blog
        /// </summary>
        public Blog()

        {
            Posts = new HashSet<Post>();
        }

        /// Actualiza una Instancia de Blog
        /// </summary>
        public void ActualizarBlog(string url)

        {
            Url = url;    
        }

        /// <summary>
        /// Numero que identifica al Blog
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Direccion del sitio web del Blog
        /// </summary>
        public string? Url { get; set; }

        /// <summary>
        /// Coleccion de Posts del Blog
        /// </summary>
        public virtual ICollection<Post> Posts { get; set; }
    }
}
