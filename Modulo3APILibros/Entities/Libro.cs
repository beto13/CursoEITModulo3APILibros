using System.ComponentModel.DataAnnotations;

namespace Modulo3APILibros.Entities
{
    public class Libro
    {
        public int Id { get; set; }

        [Required]
        public string Titulo { get; set; }

        [Required]
        public int AutorId { get; set; }
        public virtual Autor Autor { get; set; }
    }
}
