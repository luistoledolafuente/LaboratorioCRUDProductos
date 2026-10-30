using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using LaboratorioCRUDProductos.Models;

namespace LaboratorioCRUDProductos.Controllers
{
    public class ProductoController : Controller
    {
        // Método auxiliar para gestionar Session["productos"] con 3 productos iniciales
        private List<ProductoModel> ObtenerProductosSesion()
        {
            if (Session["productos"] == null)
            {
                var listaInicial = new List<ProductoModel>
                {
                    new ProductoModel { Id = 1, Nombre = "Laptop HP", Descripcion = "Laptop HP Core i5 16GB RAM", Precio = 2500.00m, Stock = 10 },
                    new ProductoModel { Id = 2, Nombre = "Mouse Inalámbrico", Descripcion = "Mouse óptico USB ergonómico", Precio = 45.50m, Stock = 50 },
                    new ProductoModel { Id = 3, Nombre = "Monitor 24\"", Descripcion = "Monitor Full HD IPS 75Hz", Precio = 650.00m, Stock = 15 }
                };
                Session["productos"] = listaInicial;
            }
            return (List<ProductoModel>)Session["productos"];
        }

        // GET: Producto/Index (Listar)
        public ActionResult Index()
        {
            var productos = ObtenerProductosSesion();
            return View(productos);
        }

        // GET: Producto/Details/5 (Consultar)
        public ActionResult Details(int id)
        {
            var productos = ObtenerProductosSesion();
            var producto = productos.FirstOrDefault(p => p.Id == id);
            if (producto == null)
            {
                return HttpNotFound();
            }
            return View(producto);
        }

        // GET: Producto/Create (Registrar - Vista)
        public ActionResult Create()
        {
            return View();
        }

        // POST: Producto/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ProductoModel producto)
        {
            var productos = ObtenerProductosSesion();

            if (ModelState.IsValid)
            {
                int nuevoId = productos.Count > 0 ? productos.Max(p => p.Id) + 1 : 1;
                producto.Id = nuevoId;

                productos.Add(producto);
                Session["productos"] = productos;

                return RedirectToAction("Index");
            }

            return View(producto);
        }

        // GET: Producto/Edit/5 (Editar - Vista)
        public ActionResult Edit(int id)
        {
            var productos = ObtenerProductosSesion();
            var producto = productos.FirstOrDefault(p => p.Id == id);
            if (producto == null)
            {
                return HttpNotFound();
            }
            return View(producto);
        }

        // POST: Producto/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ProductoModel producto)
        {
            var productos = ObtenerProductosSesion();

            if (ModelState.IsValid)
            {
                var productoExistente = productos.FirstOrDefault(p => p.Id == producto.Id);
                if (productoExistente != null)
                {
                    productoExistente.Nombre = producto.Nombre;
                    productoExistente.Descripcion = producto.Descripcion;
                    productoExistente.Precio = producto.Precio;
                    productoExistente.Stock = producto.Stock;

                    Session["productos"] = productos;
                }
                return RedirectToAction("Index");
            }

            return View(producto);
        }

        // GET: Producto/Delete/5 (Eliminar - Confirmación)
        public ActionResult Delete(int id)
        {
            var productos = ObtenerProductosSesion();
            var producto = productos.FirstOrDefault(p => p.Id == id);
            if (producto == null)
            {
                return HttpNotFound();
            }
            return View(producto);
        }

        // POST: Producto/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var productos = ObtenerProductosSesion();
            var producto = productos.FirstOrDefault(p => p.Id == id);
            if (producto != null)
            {
                productos.Remove(producto);
                Session["productos"] = productos;
            }
            return RedirectToAction("Index");
        }
    }
}