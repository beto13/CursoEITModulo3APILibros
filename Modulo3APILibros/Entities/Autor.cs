using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Modulo3APILibros.Entities
{
    public class Autor
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public virtual List<Libro> Libros { get; set; }    
    }
}
