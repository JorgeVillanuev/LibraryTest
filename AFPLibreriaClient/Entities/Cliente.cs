using System;
using System.Collections.Generic;

#nullable disable

namespace AFPLibreriaClient.Entities
{
    public partial class Cliente
    {
        public int Id { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Dui { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public int IdU { get; set; }
        public DateTime FechaModificacion { get; set; }

        public virtual ICollection<DetalleOperacion> DetalleOperacions { get; set; }
    }
}
