using System;
using System.Collections.Generic;

#nullable disable

namespace AFPLibreriaClient.Entities
{
    public partial class Autore
    {
       
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int IdU { get; set; }
        public DateTime FechaModificacion { get; set; }

        public virtual ICollection<Libro> Libros { get; set; }
    }
}
