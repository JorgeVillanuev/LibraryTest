using System;
using System.Collections.Generic;

#nullable disable

namespace LibreriaProject.Models
{
    public partial class DetalleOperacion
    {
        public int Id { get; set; }
        public int Cantidad { get; set; }
        public int Precio { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public int IdU { get; set; }
        public DateTime FechaModificacion { get; set; }
        public int LibroId { get; set; }
        public int ClienteId { get; set; }
        public int OperacionId { get; set; }

        public virtual Cliente Cliente { get; set; }
        public virtual Libro Libro { get; set; }
        public virtual Operacione Operacion { get; set; }
    }
}
