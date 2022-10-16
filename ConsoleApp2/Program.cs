

using System;
using Microsoft.EntityFrameworkCore;
using ConsoleApp2.Models;

namespace ConsoleApp2


    {
    /// <summary>
    /// Programa Principal de la aplicacion
    /// </summary>
    public class Program
    {   
        /// <summary>
        /// Funcion principal, se pueden probar aqui los metodos de la fachada
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {   //Un pequeño ejemplo de Lectura y actualizacion
            Fachada fachada=new Fachada();
            Console.Write("Ingrese el numero de blog que sea actualizar:");
            int id = Int32.Parse(Console.ReadLine());
            Blog blogAntiguo =fachada.LeerBlog(id);
            Console.WriteLine("Informacion actual del blog \nid: {0} Url: {1}",blogAntiguo.Id,blogAntiguo.Url);
            Console.Write("Ingrese la nueva url del blog: ");
            string nuevaUrl = Console.ReadLine();
            fachada.ActualizarBlog(id, nuevaUrl);
            Blog blogActualizado = fachada.LeerBlog(id);
            Console.WriteLine("Informacion anterior del blog \nid: {0} Url: {1}", blogAntiguo.Id, blogAntiguo.Url);
            Console.WriteLine("Informacion actual del blog \nid: {0} Url: {1}", blogActualizado.Id, blogActualizado.Url);

        }

    }
}