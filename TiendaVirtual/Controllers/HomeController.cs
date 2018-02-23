using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TiendaVirtual.Controllers
{
    public class HomeController : Controller
    {
        private tienda_virtual2018Entities db = new tienda_virtual2018Entities();

        // GET: Home
        public ActionResult Index()
        {
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
    }
}