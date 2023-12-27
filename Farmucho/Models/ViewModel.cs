using Microsoft.AspNetCore.Mvc.Rendering;

namespace Farmucho.Models
{
    public class ViewModel
    {
        public List<SelectListItem>? ListaMedicamentos { get; set; }
        public List<SelectListItem>? ListaClientes { get; set; }
        public int[]? IdProductos { get; set; }
        public int[]? CantProductos { get; set; }
        public static int Prod { get; set; }
        public int Cant { get; set; }
        public int IdCliente { get; set; }
        public ViewModel()
        {
            ListaMedicamentos = new();
            ListaClientes = new();
            Cant = Prod;
        }
    }
}
