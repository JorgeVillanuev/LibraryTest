using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace AFPLibreriaClient.Entities
{
    public partial class Libro
    {        
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "El titulo es obligatorio.")]
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public string Imagen { get; set; }
        public int CategoriaId { get; set; }
        public int AutorId { get; set; }
        public DateTime FechaPublicacion { get; set; }
        public int Stock { get; set; }
        public int IdU { get; set; }
        public DateTime FechaModificacion { get; set; }

        public virtual Autore Autor { get; set; }
        public virtual Categoria Categoria { get; set; }
        public virtual ICollection<DetalleOperacion> DetalleOperacions { get; set; }
    }
}
