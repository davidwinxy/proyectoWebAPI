using proyectoWebAPI.Models;
using System;

namespace ProductosWEB.Models;

public class Articulo
{
        public int Id { get; set; } // Clave primaria
        public string Nombre { get; set; } 
        public string Descripcion { get; set; } 
        public string Categoria { get; set; } 
        public bool Disponibilidad { get; set; } = true;
    public List<ImagenArticulo> Imagenes { get; set; }
}
