using MVCRestaurante.Models;

namespace MVCRestaurante.ViewModels
{
    public class OrdenViewModel
    {
        public List<Mesa> mesas { get; set; }
        public Usuario usuario { get; set; }
        public List<PlatoOrden> pedido { get; set; }
        public List<Plato> menu {  get; set; }
    }
}
