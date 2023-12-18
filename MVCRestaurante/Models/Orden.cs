using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MVCRestaurante.Models
{
    public class Orden
    {
        [Key]
        public int IdOrden { get; set; }
        public int IdMesa { get; set; }
        public bool Estado { get; set; }

    }
}
