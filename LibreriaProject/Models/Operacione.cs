using System;
using System.Collections.Generic;

#nullable disable

namespace LibreriaProject.Models
{
    public partial class Operacione
    {
        public Operacione()
        {
            DetalleOperacions = new HashSet<DetalleOperacion>();
        }

        public int Id { get; set; }
        public string Operacion { get; set; }
        public int IdU { get; set; }
        public DateTime FechaModificacion { get; set; }

        public virtual ICollection<DetalleOperacion> DetalleOperacions { get; set; }
    }
}
