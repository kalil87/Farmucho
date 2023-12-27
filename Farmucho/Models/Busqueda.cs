namespace Farmucho.Models
{
    public class Busqueda
    {
        public static Cliente? BuscarCliente(int id)
        {
            return Lista.ListarClientes()?.FirstOrDefault(p => p.Id == id);
        }
        public static Inventario? BuscarInventario(int id)
        {
            return Lista.ListarInventario()?.FirstOrDefault(p => p.Id == id);
        }
    }
}