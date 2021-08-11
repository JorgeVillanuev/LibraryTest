using System;
using System.Collections.Generic;

#nullable disable

namespace AFPLibreriaClient.Entities
{
    public partial class Categoria
    {      

        public int Id { get; set; }
        public string Categoria1 { get; set; }
        public int IdU { get; set; }
        public DateTime FechaModificacion { get; set; }

        public virtual ICollection<Libro> Libros { get; set; }
    }
}
