namespace proyectoWebAPI.Models
{
    public class ArticuloViewModel
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string Categoria { get; set; }
        public bool Disponibilidad { get; set; }
        public List<ImagenArticuloViewModel> Imagenes { get; set; }
    }
}
