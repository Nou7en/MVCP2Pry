using MVCRestaurante.Models;
using MVCRestaurante.Models.Dto;

namespace MVCRestaurante.Service
{
    public interface IAPIService
    {
        //Factura
        public Task<List<Factura>> ObtenerFacturas();
        public Task<Factura> ObtenerFactura(int idFactura);
        public Task<Factura> CrearFactura(Factura nuevaFactura);
        public Task<double> CalcularTotal(int idFactura, int idOrden);


        //Mesa 
        public Task<List<Mesa>> ObtenerMesas();
        public Task<Mesa> ObtenerMesa(int idMesa);
        public Task<bool> CambiarEstadoMesa(int idMesa);


        //Orden
        public Task<List<Orden>> ObtenerOrdenes();
        public Task<Orden> ObtenerOrdenMesa(int idMesa);
        public Task<Orden> ObtenerOrden(int idOrden);
        public Task<List<Orden>> ObtenerOrdenesUsuario(int idUsuario);
        public Task<Orden> CrearOrden(Orden nOrden);
        public Task<bool> CambiarEstadoOrden(int idOrden);
        public Task<bool> EliminarOrden(int idOrden);

        //Plato 

        public Task<List<Plato>> ObtenerListaPlatos();
        public Task<Plato> ObtenerPlato(int idPlato);
        public Task<Plato> CrearPlato(Plato nPlato);
        public Task<Plato> EditarPlato(Plato nPlato,int IdPlato);
        public Task<bool> EliminarPlato(int idPlato);



        //Plato Orden 

        public Task<PlatoOrden> ObtenerPlatoOrden(int idPlatoOrden);
        public Task<List<PlatoOrden>> ObtenerPedido(int idOrden);
        public Task<PlatoOrden> CrearPlatoOrden(int idPlato);
        public Task<PlatoOrden> SumarCantidad(int idPlatoOrden);
        public Task<PlatoOrden> ActualizarCantidad(int idPlatoOrden, int cantidad);
        public Task<List<PlatoOrden>> CambiarEstados(int idOrden);
        public Task<List<PlatoOrden>> EliminarPlatosOrden(int IdOrden);
        public Task<bool> EliminarPlatoOrden(int IdPlatoOrden);

        //Usuario

        public Task<List<UsuarioDto>> ObtenerListaUsuarios();
        public Task<List<UsuarioDto>> ObtenerListaEmpleados();
        public Task<List<UsuarioDto>> ObtenerListaClientes();
        public Task<UsuarioDto> ObtenerUsuario(int IdUsuario);
        public Task<Usuario> RegistrarCliente();
        public Task<Usuario> RegistrarEmpleado(Usuario nEmpleado);
        public Task<bool> EliminarUsuario(int IdUsuario);

        //UsuarioCredencial
        public Task<Usuario> ValidarUsuario(UsuarioCredencial credenciales);

    }   
}
