using Farmucho.Models;
using Microsoft.AspNetCore.Mvc;

namespace Farmucho.Controllers
{
    public class ClienteController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View(Lista.ListarClientes());
        }
        [HttpGet]
        public IActionResult Agregar()
        {
            return View();
        }
        [HttpPost]
        public IActionResult GuardarAgregar(Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                using (FarmaciaContext context = new())
                {
                    context.Clientes?.Add(cliente);
                    context.SaveChanges();
                    TempData["msg"] = "<script>alert('El cliente fue agregado con éxito');</script>";
                }
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
            using (FarmaciaContext context = new())
            {
                Cliente? cliente = context.Clientes?.Find(id);

                if (cliente != null)
                {
                    return View(cliente);
                }
                else
                {
                    return RedirectToAction("Index");
                }
            }
        }
        [HttpPost]
        public IActionResult Update(int id, Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                using (FarmaciaContext context = new())
                {
                    if (id != cliente.Id)
                    {
                        return NotFound();
                    }
                    else
                    {
                        context.Clientes?.Update(cliente);
                        context.SaveChanges();
                        TempData["msg"] = "<script>alert('El cliente fue editado con éxito');</script>";
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
                    Cliente? cliente = context.Clientes?.Find(id);
                    if (cliente != null)
                    {
                        context.Clientes?.Remove(cliente);
                        context.SaveChanges(true);
                        TempData["msg"] = "<script>alert('El cliente fue borrado con éxito');</script>";
                    }
                }
            }
            return RedirectToAction("Index");
        }
    }
}