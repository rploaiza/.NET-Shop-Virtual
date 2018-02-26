using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TiendaVirtual.Models.Bilders
{
    public class CarritoCompraModelBilder : IModelBinder

    {
        private string idCarritoSession = "idCarritoSession";
        public object BindModel(ControllerContext mbctx, ModelBindingContext bctx)
        {
            CarritoCompra carritoCompra =(CarritoCompra)mbctx.HttpContext.Session[idCarritoSession];
            if (carritoCompra == null)
            {
                carritoCompra = new CarritoCompra();
                mbctx.HttpContext.Session[idCarritoSession] = carritoCompra;
            }
            return carritoCompra;
        }
    }
}