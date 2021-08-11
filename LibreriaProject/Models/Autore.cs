using System;
using System.Collections.Generic;

#nullable disable

namespace LibreriaProject.Models
{
    public partial class Autore
    {
        public Autore()
        {
            Libros = new HashSet<Libro>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }
        public int IdU { get; set; }
        public DateTime FechaModificacion { get; set; }

        public virtual ICollection<Libro> Libros { get; set; }
    }
}
