using Farmucho.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Reflection.Metadata;

namespace Farmucho.Controllers
{
    public class FacturaController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Update(int cant)
        {
            if (cant > 0 && cant <= 30)
            {
                ViewModel.Prod = cant;
                return RedirectToAction("DatosFactura");
            }
            else
            {
                //TempData["msg"] = "<script>alert('La cantidad debe ser entre 1-30');</script>";
                return RedirectToAction("Index");
            }
        }

        [HttpGet]
        public IActionResult DatosFactura()
        {
            ViewModel viewModel = new();
            viewModel.CantProductos = new int[viewModel.Cant];
            viewModel.IdProductos = new int[viewModel.Cant];
            viewModel.ListaClientes?.Add(new() { Text = "Consumidor Final", Value = "-1" });
            viewModel.ListaMedicamentos?.Add(new() { Text = "Seleccione un producto", Value = "-1" });
            List<Cliente>? clientes = Lista.ListarClientes();
            List<Inventario>? inventarios = Lista.ListarInventario();
            if (clientes != null)
            {
                foreach (var c in clientes)
                {
                    viewModel.ListaClientes?.Add(new() { Text = c.Cuit.ToString(), Value = c.Id.ToString() });
                }
            }
            if (inventarios != null)
            {
                foreach (var m in inventarios)
                {
                    viewModel.ListaMedicamentos?.Add(new() { Text = m.Nombre, Value = m.Id.ToString() });
                }
            }
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult MostrarFactura(ViewModel vm)
        {
            Cliente? cliente = null;
            if (vm.IdCliente != -1)
            {
                cliente = Busqueda.BuscarCliente(vm.IdCliente);
            }

            List<ItemFactura> itemsFactura = new();
            for (int i = 0; i < vm.IdProductos?.Length; i++)
            {
                Inventario? medicamento = Busqueda.BuscarInventario(vm.IdProductos[i]);
                if (medicamento != null && vm.CantProductos?[i] > 0)
                {
                    itemsFactura.Add(new ItemFactura(medicamento, vm.CantProductos[i], medicamento.PrecioVenta));
                }
            }
            if (itemsFactura.Any() && cliente != null)
            {
                Factura factura = new(cliente, itemsFactura);
                return View(factura);
            }
            else if (itemsFactura.Any())
            {
                Factura factura = new(itemsFactura);
                return View(factura);
            }
            else
            {
                TempData["msg"] = "<script>alert('Ingrese al menos un producto, cantidad superior a 0');</script>";
                return RedirectToAction("DatosFactura");
            }
        }
    }
}