using System.ComponentModel.DataAnnotations;

namespace MVCRestaurante.Models.Dto
{
    public class UsuarioDto
    {
        [Key]
        public int IdUsuario { get; set; }
        public string NombreUsuario { get; set; }
        public string Rol { get; set; }
    }
}
