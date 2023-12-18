    using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MVCRestaurante.Models
{
    public class Plato
    {
        [Key]
        public int IdPlato { get; set; }
        public string NombrePlato { get; set; }
        public string DescripcionPlato { get; set; }
        public double Precio { get; set; }


    }
}
