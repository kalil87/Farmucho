namespace Farmucho.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

public class Lista
{
    public static List<Inventario>? ListarInventario()
    {
        List<Inventario>? inventario;
        using (FarmaciaContext context = new())
        {
            inventario = context.Inventario?.ToList();
        }
        return inventario;
    }

    public static List<Cliente>? ListarClientes()
    {
        List<Cliente>? clientes;
        using (FarmaciaContext context = new())
        {
            clientes = context.Clientes?.ToList();
        }
        return clientes;
    }
}