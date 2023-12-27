using Microsoft.AspNetCore.Mvc;
using Farmucho.Models;
using System.Collections.Generic;

namespace Farmucho.Controllers
{
    public class InventarioController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View(Lista.ListarInventario());
        }
        [HttpGet]
        public IActionResult Agregar()
        {
            return View();
        }
        [HttpPost]
        public IActionResult GuardarAgregar(Inventario inventario)
        {
            if (ModelState.IsValid)
            {
                using (FarmaciaContext context = new())
                {
                    context.Inventario?.Add(inventario);
                    context.SaveChanges();
                }
                TempData["msg"] = "<script>alert('El medicamento fue agregado con éxito');</script>";
                return RedirectToAction("Index");
            }
            else
            {
                TempData["msg"] = "<script>alert('Por favor, llene todos los campos');</script>";
                return View("Agregar");
            }
        }
        [HttpGet]
        public IActionResult Editar(int id)
        {
            using FarmaciaContext context = new();
            
                Inventario? inventario = context.Inventario?.Find(id);

                if (inventario != null)
                {
                    return View(inventario);
                }
                else
                {
                    return RedirectToAction("Index");
                }
            
        }
        [HttpPost]
        public IActionResult Update(int id, Inventario inventario)
        {
            if (ModelState.IsValid)
            {
                using (FarmaciaContext context = new())
                {
                    if (id != inventario.Id)
                    {
                        return NotFound();
                    }
                    else
                    {
                        context.Inventario?.Update(inventario);
                        context.SaveChanges();
                        TempData["msg"] = "<script>alert('El medicamento fue editado con éxito');</script>";
                    }
                }
                return RedirectToAction("Index");
            }
            else
            {
                TempData["msg"] = "<script>alert('Por favor, llene todos los campos');</script>";
                return View("Editar");
            }
        }
        [HttpGet]
        public IActionResult Borrar(int id)
        {
            using (FarmaciaContext context = new())
            {
                if (id != 0)
                {
                    Inventario? inventario = context.Inventario?.Find(id);
                    if (inventario != null)
                    {
                        context.Inventario?.Remove(inventario);
                        context.SaveChanges(true);
                        TempData["msg"] = "<script>alert('El medicamento fue borrado con éxito');</script>";
                    }
                }
            }
            return RedirectToAction("Index");
        }
    }
}
