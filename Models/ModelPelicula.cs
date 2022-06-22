using System.ComponentModel.DataAnnotations;

namespace MoviesDex.Models
{
    public class ModelPelicula
    {
        public int id { get; set; }

        [Required(ErrorMessage = "Ingresar el título es obligatorio")]
        public string titulo { get; set; }

        [Required(ErrorMessage = "Ingresar el director es obligatorio")]
        public string director { get; set; }

        [Required(ErrorMessage = "Ingresar la categoría es obligatorio")]
        public string categoria { get; set; }

        [Required(ErrorMessage = "Ingresar la calificación es obligatorio")]
        public int calificacion { get; set; }

        [Required(ErrorMessage = "Ingresar la fecha de estreno es obligatorio")]
        public DateTime fechaEstreno { get; set; }

    }
}
