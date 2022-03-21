using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CRUD.Models;

namespace CRUD.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            Mantenimiento mant = new Mantenimiento();
            return View(mant.RecuperarTodos());
        }

        public ActionResult Alta()
        {           
            return View();
        }
        [HttpPost]
        public ActionResult Alta(FormCollection collection)
        {
            Mantenimiento mant = new Mantenimiento();
            Articulo art = new Articulo()
            {
                codigo = int.Parse(collection["codigo"]),
                descripcion = collection["descripcion"],
                precio = float.Parse(collection["precio"])
            };
            mant.Alta(art);
            return RedirectToAction("Index");
        }
        public ActionResult Baja(int cod)
        {
            Mantenimiento mant = new Mantenimiento();
            mant.Borrar(cod);
            return RedirectToAction("Index");
        }
        public ActionResult Modificacion(int cod)
        {
            Mantenimiento mant = new Mantenimiento();
            Articulo art = mant.Recuperar(cod);
            return View(art);
        }
        [HttpPost]
        public ActionResult Modificacion(FormCollection collection)
        {
            Mantenimiento mant = new Mantenimiento();
            Articulo art = new Articulo
            {
                codigo = int.Parse(collection["codigo"].ToString()),
                descripcion = collection["descripcion"].ToString(),
                precio = float.Parse(collection["precio"].ToString())
            };
            mant.Modificar(art);
            return RedirectToAction("Index");
        }
    }
}