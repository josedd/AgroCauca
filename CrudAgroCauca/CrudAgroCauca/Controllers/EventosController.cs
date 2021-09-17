using CrudAgroCauca.Data;
using CrudAgroCauca.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CrudASPNETAgroCauca.Controllers
{
    public class EventosController : Controller
    {
        EventosAdmin Admin = new EventosAdmin();
        // GET: Eventos
        public ActionResult Index()
        {
            IEnumerable<Eventos> lista = Admin.Consultar();
            return View(lista);
        }
        public ActionResult Guardar()
        {
            ViewBag.mensaje = "";
            return View();
        }
        public ActionResult Nuevo(Eventos modelo)
        {
            Admin.Guardar(modelo);
            ViewBag.mensaje = "Evento Guardado";
            return View("Guardar", modelo);
        }
        public ActionResult Detalle(int id = 0)
        {
            Eventos modelo = Admin.Consultar(id);
            return View(modelo);
        }

        public ActionResult Editar(int id = 0)
        {
            ViewBag.mensaje = "";
            Eventos modelo = Admin.Consultar(id);
            return View(modelo);
        }


        public ActionResult Actualizar(Eventos modelo)
        {
            Admin.Editar(modelo);
            ViewBag.mensaje = "Evento Actualizado";
            return View("Editar", modelo);
        }

        public ActionResult Eliminar(int id = 0)
        {
            ViewBag.mensaje = "";
            Eventos modelo = new Eventos()
            {
                Id = id
            };
            Admin.Eliminar(modelo);
            IEnumerable<Eventos> lista = Admin.Consultar();
            ViewBag.mensaje = "Producto Eliminado";
            return View("Index", lista);

        }
    }
}