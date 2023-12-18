using System.ComponentModel.DataAnnotations;

namespace MVCRestaurante.Models
{
    public class Factura
    {
        [Key]
        public int IdFactura { get; set; }
        public int IdOrden { get; set; }
        public double Total { get; set; }
        public string Nombre { get; set; }
        public string Cedula { get; set; }
        public string Direccion { get; set; }
        public DateTime Fecha { get; set; }
    }
}
