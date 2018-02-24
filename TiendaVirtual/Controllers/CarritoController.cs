using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TiendaVirtual.Models;

namespace TiendaVirtual.Controllers
{
    public class CarritoController : Controller
    {
        private tienda_virtual2018Entities db = new tienda_virtual2018Entities();
        private Pedido pedido = new Pedido();
        private PedidosProd pedidosProd = new PedidosProd();

        // GET: Carrito
        public ActionResult Index(CarritoCompra cart)
        {
            return View(cart);
        }
        public ActionResult Carrito(int id, CarritoCompra carrito)
        {

            Producto producto = db.Producto.Find(id);
            carrito.Add(producto);
            return RedirectToAction("Index", "Home");
        }


        public ActionResult DeleteCarrito(int id, CarritoCompra carrito)
        {
            if (ModelState.IsValid)
            {
                Producto producto = carrito.Find(val => val.Id == id);
                carrito.Remove(producto);
            }

            return RedirectToAction("Index", "Carrito");
        }
        [Authorize]
        public ActionResult AddPedido(CarritoCompra carrito)
        {
            var query = from producto in db.Producto
                        where producto.Id == pedidosProd.id_producto
                        select producto;
            if (carrito.Count() == 0)
            {
                return View("Error");
            }
            else
            {
                foreach (Producto producto in carrito)
                {
                    pedido.Nombre = producto.Nombre;
                    pedido.Cantidad = 1;
                    db.Pedido.Add(pedido);

                    // LLave entre productos y pedidos

                    pedidosProd.id_producto = producto.Id;
                    pedidosProd.id_pedido = pedido.Id;

                    db.PedidosProd.Add(pedidosProd);
                    db.SaveChanges();
                    //Stock de productos
                    foreach (Producto productos in query)
                    {
                        productos.Cantidad = producto.Cantidad - 1;
                    }
                }
                db.SaveChanges();
                carrito.Clear();
                return View("Compra");
            }
        }
    }
}