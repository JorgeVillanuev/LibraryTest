using System;
using System.Collections.Generic;

#nullable disable

namespace LibreriaProject.Models
{
    public partial class Categoria
    {
        public Categoria()
        {
            Libros = new HashSet<Libro>();
        }

        public int Id { get; set; }
        public string Categoria1 { get; set; }
        public int IdU { get; set; }
        public DateTime FechaModificacion { get; set; }

        public virtual ICollection<Libro> Libros { get; set; }
    }
}
