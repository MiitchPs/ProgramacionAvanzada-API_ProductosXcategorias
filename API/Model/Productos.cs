namespace API.Model
{
    public class Productos
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public int Precio { get; set; }
        public int stock { get; set; }
        public string Imagen { get; set; }
        public int CategoriasId { get; set; }
        public virtual Categorias Categorias { get; set; }


    }
}
