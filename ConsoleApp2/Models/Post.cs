using System;
using System.Collections.Generic;

namespace ConsoleApp2.Models
{   
    /// <summary>
    /// Esta clase modela la informacion relevante de un Post Perteneciente a un Blog
    /// </summary>
    public partial class Post

    {   /// <summary>
        /// Construcctor de la clase, crea una nueva instancia de Post
        /// </summary>
        /// <param name="id"></param>
        /// <param name="content"></param>
        /// <param name="blog"></param>
        public Post(int id, string content,Blog blog)
        {
            Id = id;
            Content = content;
            Blog = blog;
            Blogid = Blog.Id;
        }

        /// </summary>
        /// Construcctor de la clase, crea una nueva instancia de Post
        /// </summary>
        public Post()
        {
        }

        /// <summary>
        /// Identificador del Post
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Contenido del Post
        /// </summary>
        public string? Content { get; set; }

        /// <summary>
        /// Identificador que hace referencia al Blog al cual pertenece el Post
        /// </summary>
        public int Blogid { get; set; }

        /// <summary>
        /// Blog al cual pertenece el Post
        /// </summary>
        public virtual Blog Blog { get; set; } = null!;
    }
}
