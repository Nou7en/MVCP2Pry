using MVCRestaurante.Models;
using MVCRestaurante.Models.Dto;
using Newtonsoft.Json;
using System.Net;
using System.Text;

namespace MVCRestaurante.Service
{
    public class APIService: IAPIService
    {
        public static string _baseUrl;
        public HttpClient _httpClient;
        public APIService()

        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
            _baseUrl = builder.GetSection("ApiSettings:BaseUrl").Value;
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri(_baseUrl);
        }
        //Factura
        public async Task<List<Factura>> ObtenerFacturas()
        {
            try
            {
                var response = await _httpClient.GetAsync($"/api/Factura/Facturas");

                if (response.IsSuccessStatusCode)
                {
                    var json_response = await response.Content.ReadAsStringAsync();
                    List<Factura> facturas = JsonConvert.DeserializeObject<List<Factura>>(json_response);
                    return facturas;
                }
                return new List<Factura>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al obtener las facturas: {ex.Message}");
                return new List<Factura>();
            }
        }


        public async Task<Factura> ObtenerFactura(int idFactura)
        {
            try
            {
                var response = await _httpClient.GetAsync($"/api/Factura/IdFactura/{idFactura}");

                if (response.IsSuccessStatusCode)
                {
                    var json_response = await response.Content.ReadAsStringAsync();
                    var factura = JsonConvert.DeserializeObject<Factura>(json_response);
                    return factura;
                }
                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al obtener la factura: {ex.Message}");
                return null;
            }
        }

        public async Task<Factura> CrearFactura(Factura nuevaFactura)
        {
            try
            {
                var content = new StringContent(JsonConvert.SerializeObject(nuevaFactura), Encoding.UTF8, "application/json");

                var response = await _httpClient.PostAsync($"/api/Factura/CrearFactura", content);

                if (response.IsSuccessStatusCode)
                {
                    var json_response = await response.Content.ReadAsStringAsync();
                    var facturaCreada = JsonConvert.DeserializeObject<Factura>(json_response);
                    return facturaCreada;
                }
                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al crear la factura: {ex.Message}");
                return null;
            }
        }

        public async Task<double> CalcularTotal(int idFactura, int idOrden)
        {
            try
            {
                var response = await _httpClient.PutAsync($"/api/Factura/CalcularFactura/{idFactura}/{idOrden}", null);

                if (response.IsSuccessStatusCode)
                {
                    var totalString = await response.Content.ReadAsStringAsync();
                    if (double.TryParse(totalString, out double total))
                    {
                        return total;
                    }
                }
                return 0.0;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al calcular el total: {ex.Message}");
                return 0.0;
            }
        }

        //Mesa

        public async Task<List<Mesa>> ObtenerMesas()
        {
            try
            {
                var response = await _httpClient.GetAsync($"/api/Mesa/ListaMesas");

                if (response.IsSuccessStatusCode)
                {
                    var json_response = await response.Content.ReadAsStringAsync();
                    List<Mesa> mesas = JsonConvert.DeserializeObject<List<Mesa>>(json_response);
                    return mesas;
                }
                return new List<Mesa>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al obtener la lista de mesas: {ex.Message}");
                return new List<Mesa>();
            }
        }

        public async Task<Mesa> ObtenerMesa(int idMesa)
        {
            try
            {
                var response = await _httpClient.GetAsync($"/api/Mesa/IdMesa/{idMesa}");

                if (response.IsSuccessStatusCode)
                {
                    var json_response = await response.Content.ReadAsStringAsync();
                    var mesa = JsonConvert.DeserializeObject<Mesa>(json_response);
                    return mesa;
                }
                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al obtener la mesa: {ex.Message}");
                return null;
            }
        }

        public async Task<bool> CambiarEstadoMesa(int idMesa)
        {
            try
            {
                var response = await _httpClient.PutAsync($"/api/Mesa/CambiarEstado/{idMesa}", null);

                if (response.IsSuccessStatusCode)
                {
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al cambiar el estado de la mesa: {ex.Message}");
                return false;
            }
        }

        //Orden

        public async Task<List<Orden>> ObtenerOrdenes()
        {
            try
            {
                var response = await _httpClient.GetAsync($"/ListaOrdenes");

                if (response.IsSuccessStatusCode)
                {
                    var json_response = await response.Content.ReadAsStringAsync();
                    List<Orden> ordenes = JsonConvert.DeserializeObject<List<Orden>>(json_response);
                    return ordenes;
                }
                return new List<Orden>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al obtener las órdenes: {ex.Message}");
                return new List<Orden>();
            }
        }

        public async Task<Orden> ObtenerOrdenMesa(int idMesa)
        {
            try
            {
                var response = await _httpClient.GetAsync($"/OrdenMesa/IdMesa/{idMesa}");

                if (response.IsSuccessStatusCode)
                {
                    var json_response = await response.Content.ReadAsStringAsync();
                    Orden orden = JsonConvert.DeserializeObject<Orden>(json_response);
                    return orden;
                }
                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al obtener la orden de la mesa: {ex.Message}");
                return null;
            }
        }


        public async Task<Orden> ObtenerOrden(int idOrden)
        {
            try
            {
                var response = await _httpClient.GetAsync($"/IdOrden/{idOrden}");

                if (response.IsSuccessStatusCode)
                {
                    var json_response = await response.Content.ReadAsStringAsync();
                    Orden orden = JsonConvert.DeserializeObject<Orden>(json_response);
                    return orden;
                }

                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al obtener la orden: {ex.Message}");
                return null;
            }
        }

        public async Task<List<Orden>> ObtenerOrdenesUsuario(int idUsuario)
        {
            try
            {
                var response = await _httpClient.GetAsync($"/ObtenerOrdenesUsuario/IdUsuario/{idUsuario}");

                if (response.IsSuccessStatusCode)
                {
                    var json_response = await response.Content.ReadAsStringAsync();
                    List<Orden> ordenes = JsonConvert.DeserializeObject<List<Orden>>(json_response);
                    return ordenes;
                }

                return new List<Orden>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al obtener las órdenes del usuario: {ex.Message}");
                return new List<Orden>();
            }
        }

        public async Task<Orden> CrearOrden(Orden nOrden)
        {
            try
            {
                var content = new StringContent(JsonConvert.SerializeObject(nOrden), Encoding.UTF8, "application/json");
                var response = await _httpClient.PostAsync($"/CrearOrden", content);

                if (response.IsSuccessStatusCode)
                {
                    var json_response = await response.Content.ReadAsStringAsync();
                    Orden orden = JsonConvert.DeserializeObject<Orden>(json_response);
                    return orden;
                }

                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al crear la orden: {ex.Message}");
                return null;
            }
        }


        public async Task<bool> CambiarEstadoOrden(int idOrden)
        {
            try
            {
                var response = await _httpClient.PutAsync($"/CambiarEstadoOrden/IdOrden/{idOrden}", null);

                if (response.IsSuccessStatusCode)
                {
                    return true;
                }

                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al cambiar el estado de la orden: {ex.Message}");
                return false;
            }
        }


        public async Task<bool> EliminarOrden(int idOrden)
        {
            try
            {
                var response = await _httpClient.DeleteAsync($"/IdOrden/{idOrden}");

                if (response.StatusCode == HttpStatusCode.NoContent)
                {
                    return true;
                }

                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al eliminar la orden: {ex.Message}");
                return false;
            }
        }


        //Plato 

        public async Task<List<Plato>> ObtenerListaPlatos()
        {
            try
            {
                var response = await _httpClient.GetAsync($"/api/Plato/ListaPlatos");

                if (response.IsSuccessStatusCode)
                {
                    var json_response = await response.Content.ReadAsStringAsync();
                    List<Plato> menu = JsonConvert.DeserializeObject<List<Plato>>(json_response);
                    return menu;
                }

                return new List<Plato>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al obtener la lista de platos: {ex.Message}");
                return new List<Plato>();
            }
        }

        public async Task<Plato> ObtenerPlato(int idPlato)
        {
            try
            {
                var response = await _httpClient.GetAsync($"/api/Plato/IdPlato/{idPlato}");

                if (response.IsSuccessStatusCode)
                {
                    var json_response = await response.Content.ReadAsStringAsync();
                    Plato plato = JsonConvert.DeserializeObject<Plato>(json_response);
                    return plato;
                }

                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al obtener el plato: {ex.Message}");
                return null;
            }
        }

        public async Task<Plato> CrearPlato(Plato nPlato)
        {
            try
            {
                var content = new StringContent(JsonConvert.SerializeObject(nPlato), Encoding.UTF8, "application/json");
                var response = await _httpClient.PostAsync($"/api/Plato/CrearPlato", content);

                if (response.IsSuccessStatusCode)
                {
                    var json_response = await response.Content.ReadAsStringAsync();
                    Plato NuevoPlato = JsonConvert.DeserializeObject<Plato>(json_response);
                    return NuevoPlato;
                }

                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al crear el plato: {ex.Message}");
                return null;
            }
        }


        public async Task<Plato> EditarPlato(Plato nPlato,int IdPlato)
        {
            try
            {
                var content = new StringContent(JsonConvert.SerializeObject(nPlato), Encoding.UTF8, "application/json");
                var response = await _httpClient.PutAsync($"/api/Plato/IdPlato/{IdPlato}", content);

                if (response.IsSuccessStatusCode)
                {
                    var json_response = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<Plato>(json_response);
                }

                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al editar el plato: {ex.Message}");
                return null;
            }
        }

        public async Task<bool> EliminarPlato(int idPlato)
        {
            try
            {
                var response = await _httpClient.DeleteAsync($"/api/Plato/IdPlato/{idPlato}");

                if (response.StatusCode == HttpStatusCode.NoContent)
                {
                    return true;
                }

                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al eliminar el plato: {ex.Message}");
                return false;
            }
        }

        //Plato Orden 

        public async Task<PlatoOrden> ObtenerPlatoOrden(int idPlatoOrden)
        {
            try
            {
                var response = await _httpClient.GetAsync($"/api/PlatoOrden/IdPlatoOrden/{idPlatoOrden}");

                if (response.IsSuccessStatusCode)
                {
                    var json_response = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<PlatoOrden>(json_response);
                }

                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al obtener el plato de la orden: {ex.Message}");
                return null;
            }
        }


        public async Task<List<PlatoOrden>> ObtenerPedido(int idOrden)
        {
            try
            {
                var response = await _httpClient.GetAsync($"/api/PlatoOrden/ObtenerPedido/IdOrden/{idOrden}");

                if (response.IsSuccessStatusCode)
                {
                    var json_response = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<List<PlatoOrden>>(json_response);
                }

                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al obtener el pedido: {ex.Message}");
                return null;
            }
        }

        //Por revisar don chen no estoy seguro, creo que no necesitamos un cuerpo de solicitud, ya que se estás pasando todos los datos  directamente en la URL
        public async Task<PlatoOrden> CrearPlatoOrden(int idPlato)
        {
            try
            {
                var response = await _httpClient.PostAsync($"/api/PlatoOrden/CrearPlatoOrdem/{idPlato}", null);

                if (response.IsSuccessStatusCode)
                {
                    var json_response = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<PlatoOrden>(json_response);
                }

                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al crear el plato de la orden: {ex.Message}");
                return null;
            }
        }
        public async Task<PlatoOrden> SumarCantidad(int idPlatoOrden)
        {
            try
            {
                var response = await _httpClient.PutAsync($"/api/PlatoOrden/SumarCantidad/{idPlatoOrden}", null);

                if (response.IsSuccessStatusCode)
                {
                    var json_response = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<PlatoOrden>(json_response);
                }

                // Manejar el caso en que no se pudo sumar la cantidad
                return null;
            }
            catch (Exception ex)
            {
                // Manejar cualquier excepción durante la solicitud
                Console.WriteLine($"Error al sumar cantidad al plato ordenado: {ex.Message}");
                return null;
            }
        }
        public async Task<PlatoOrden> ActualizarCantidad(int idPlatoOrden,int cantidad)
        {
            try
            {
                var response = await _httpClient.PutAsync($"/api/PlatoOrden/ActualizarCantidad/{idPlatoOrden}", null);

                if (response.IsSuccessStatusCode)
                {
                    var json_response = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<PlatoOrden>(json_response);
                }

                // Manejar el caso en que no se pudo sumar la cantidad
                return null;
            }
            catch (Exception ex)
            {
                // Manejar cualquier excepción durante la solicitud
                Console.WriteLine($"Error al actualizar cantidad: {ex.Message}");
                return null;
            }
        }

        public async Task<List<PlatoOrden>> CambiarEstados(int idOrden)
        {
            try
            {
                var response = await _httpClient.PutAsync($"/api/PlatoOrden/Cambiarestados/{idOrden}", null);

                if (response.IsSuccessStatusCode)
                {
                    var json_response = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<List<PlatoOrden>>(json_response);
                }

                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al cambiar estados de los platos ordenados: {ex.Message}");
                return null;
            }
        }

        //Por revisar ya que en el api devuelve La list de platos Orden, pero nose si hacer el delete con un boolean que retorne    
        public async Task<List<PlatoOrden>> EliminarPlatosOrden(int IdOrden)
        {
            try
            {
                var response = await _httpClient.DeleteAsync($"/api/PlatoOrden/EliminarPlatosOrden/{IdOrden}");

                if (response.IsSuccessStatusCode)
                {
                    var json_response = await response.Content.ReadAsStringAsync();
                    var platosOrden = JsonConvert.DeserializeObject<List<PlatoOrden>>(json_response);
                    return platosOrden;
                }

                // Manejar otros códigos de estado según sea necesario
                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al eliminar platos de la orden: {ex.Message}");
                return null;
            }
        }

        //aqui esta como te decia 
        public async Task<bool> EliminarPlatoOrden(int IdPlatoOrden)
        {
            try
            {
                var response = await _httpClient.DeleteAsync($"/api/PlatoOrden/EliminarPlatoOrden/{IdPlatoOrden}");

                if (response.IsSuccessStatusCode)
                {
                    return true;
                }

                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al eliminar el plato de la orden: {ex.Message}");
                return false;
            }
        }
        //Usuario
        public async Task<List<UsuarioDto>> ObtenerListaUsuarios()
        {
            try
            {
                var response = await _httpClient.GetAsync($"/api/Usuario/Usuarios");

                if (response.IsSuccessStatusCode)
                {
                    var json_response = await response.Content.ReadAsStringAsync();
                    List<UsuarioDto> usuariosdtos = JsonConvert.DeserializeObject<List<UsuarioDto>>(json_response);
                    return usuariosdtos;
                }
                return new List<UsuarioDto>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al obtener las facturas: {ex.Message}");
                return new List<UsuarioDto>();
            }
        }
        public async Task<List<UsuarioDto>> ObtenerListaEmpleados()
        {
            try
            {
                var response = await _httpClient.GetAsync($"/api/Usuario/Empleados");

                if (response.IsSuccessStatusCode)
                {
                    var json_response = await response.Content.ReadAsStringAsync();
                    List<UsuarioDto> empleados = JsonConvert.DeserializeObject<List<UsuarioDto>>(json_response);
                    return empleados;
                }
                return new List<UsuarioDto>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al obtener la lista de empleados: {ex.Message}");
                return new List<UsuarioDto>();
            }
        }
        public async Task<List<UsuarioDto>> ObtenerListaClientes()
        {
            try
            {
                var response = await _httpClient.GetAsync($"/api/Usuario/CLientes");

                if (response.IsSuccessStatusCode)
                {
                    var json_response = await response.Content.ReadAsStringAsync();
                    List<UsuarioDto> clientes = JsonConvert.DeserializeObject<List<UsuarioDto>>(json_response);
                    return clientes;
                }
                return new List<UsuarioDto>();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al obtener la lista de clientes: {ex.Message}");
                return new List<UsuarioDto>();
            }
        }
        public async Task<UsuarioDto> ObtenerUsuario(int IdUsuario)
        {
            try
            {
                var response = await _httpClient.GetAsync($"/api/Usuario/IdUsuario/{IdUsuario}");

                if (response.IsSuccessStatusCode)
                {
                    var json_response = await response.Content.ReadAsStringAsync();
                    var usuario = JsonConvert.DeserializeObject<UsuarioDto>(json_response);
                    return usuario;
                }
                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al obtener el usuario: {ex.Message}");
                return new UsuarioDto();
            }
        }
        public async Task<bool> EliminarUsuario(int IdUsuario)
        {
            try
            {
                var response = await _httpClient.DeleteAsync($"/api/Usuario/IdUsuario/{IdUsuario}");
                if (response.StatusCode == HttpStatusCode.NoContent)
                {
                    return true;
                }
                return false;
            }catch (Exception ex)
            {
                Console.WriteLine($"Error al eliminar el usuario: {ex.Message}");
                return false;
            }
        }
        public async Task<Usuario> RegistrarCliente()
        {
            try
            {
                var response = await _httpClient.PostAsync($"/api/Usuario/RegistroCliente", null);

                if (response.IsSuccessStatusCode)
                {
                    var json_response = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<Usuario>(json_response);
                }

                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al crear al registrar cliente: {ex.Message}");
                return null;
            }
        }
        public async Task<Usuario> RegistrarEmpleado(Usuario nEmpleado)
        {
            try
            {

                var json = JsonConvert.SerializeObject(nEmpleado);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await _httpClient.PostAsync($"/api/Usuario/RegistroEmpleado", content);

                if (response.IsSuccessStatusCode)
                {
                    var json_response = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<Usuario>(json_response);
                }

                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al crear al registrar cliente: {ex.Message}");
                return null;
            }
        }
        //UsuarioCredencial
        public async Task<Usuario> ValidarUsuario(UsuarioCredencial credenciales)
        {
            try
            {
                var jsonContent = new StringContent(JsonConvert.SerializeObject(credenciales), Encoding.UTF8, "application/json");

                var response = await _httpClient.PostAsync($"/api/UsuarioCredencial/ValidarUsuario", jsonContent);

                if (response.IsSuccessStatusCode)
                {
                    var json_response = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<Usuario>(json_response);
                }

                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al validar usuario: {ex.Message}");
                return null;
            }
        }

    }
}
