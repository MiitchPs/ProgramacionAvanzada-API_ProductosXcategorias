﻿namespace API.Model
{
    public class Categorias
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public virtual List<Productos> Productos { get; set; }
    }
}
