using Farmucho.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections;
using System.Collections.Generic;

namespace Farmucho.Controllers
{
    public class ReabastecimientoController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            List<Inventario>? inventario = Lista.ListarInventario()?.Where(x => x.Cantidad <= 5).ToList();
            return View(inventario);
        }
        [HttpPost]
        public IActionResult Todos(int cantidad)
        {
            if (cantidad > 0)
            {
                using (FarmaciaContext context = new())
                {
                    List<Inventario>? inventario = Lista.ListarInventario()?.Where(x => x.Cantidad <= 5).ToList();
                    if (inventario != null)
                    {
                        foreach (var item in inventario)
                        {
                            item.Cantidad += cantidad;
                            context.Inventario?.Update(item);
                            context.SaveChanges(true);
                            TempData["msg"] = "<script>alert('Todos los productos fueron reabastecidos con éxito');</script>";
                        }
                    }
                }
            }
            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult Update(int id, int cantidad)
        {
            if (cantidad > 0)
            {
                {
                    using (FarmaciaContext context = new())
                    {
                        if (id != 0)
                        {
                            Inventario? inventario = context.Inventario?.Find(id);
                            if (inventario != null)
                            {
                                inventario.Cantidad += cantidad;
                                context.Inventario?.Update(inventario);
                                context.SaveChanges(true);
                                TempData["msg"] = "<script>alert('El producto fue reabastecido con éxito');</script>";
                            }
                        }
                    }
                }
            }
            return RedirectToAction("Index");
        }
    }
}

//[HttpGet]
//public IActionResult Todos1()
//{
//    using (InventarioContext context = new InventarioContext())
//    {
//        List<Inventario>? inventario = null;
//        inventario = Lista.listar().Where(x => x.Cantidad <= 5).ToList();
//        foreach (var item in inventario)
//        {
//            item.Cantidad = 55;
//            context.Inventario.Update(item);
//            context.SaveChanges(true);
//        }
//    }
//    return RedirectToAction("Index", "Reabastecimiento");
//}
//[HttpGet]
//public IActionResult Update1(int id)
//{
//    {
//        using (InventarioContext context = new InventarioContext())
//        {
//            if (id != 0)
//            {
//                Inventario? inventario = context.Inventario.Find(id);
//                if (inventario != null)
//                {
//                        inventario.Cantidad = 55;
//                        context.Inventario.Update(inventario);
//                        context.SaveChanges(true);
//                }
//            }
//        }
//    }
//    return RedirectToAction("Index");
//}