using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MVCRestaurante.Models
{
    public class Mesa
    {
        [Key]
        public int IdMesa { get; set; }
        public bool estado { get; set; }
    }
}
