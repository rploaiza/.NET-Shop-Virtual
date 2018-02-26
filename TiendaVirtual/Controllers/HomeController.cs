using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;
using TiendaVirtual.Models;

namespace TiendaVirtual.Controllers
{
    public class HomeController : Controller
    {
        private tienda_virtual2018Entities db = new tienda_virtual2018Entities();

        // GET: Home
        public ActionResult Index(CarritoCompra carritoCompra)
        {
            ViewData["Carrito"] = carritoCompra.Count();
            return View(db.Producto.ToList());
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        // GET: Product/Details/5
        public ActionResult Details(int? id, CarritoCompra carritoCompra)
        {
            ViewData["Carrito"] = carritoCompra.Count();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Producto producto = db.Producto.Find(id);
            if (producto == null)
            {
                return HttpNotFound();
            }
            return View(producto);
        }      
    }
}