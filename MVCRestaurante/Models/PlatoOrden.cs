using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MVCRestaurante.Models
{
    public class PlatoOrden
    {
        [Key]
        public int IdPlatoOrden { get; set; }
        public int IdOrden { get; set; }
        public int IdPlato { get; set; }
        public int Cantidad { get; set; }
        public bool Estado { get; set; }

    }
}
