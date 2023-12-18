using System.ComponentModel.DataAnnotations;

namespace MVCRestaurante.Models
{
    public class Usuario
    {
        [Key]
        public int IdUsuario { get; set; }
        public string NombreUsuario { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Clave { get; set; }
        public string Rol { get; set; }

    }
}
