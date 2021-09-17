using CrudAgroCauca.Data;
using CrudAgroCauca.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CrudASPNETAgroCauca.Controllers
{
    public class InversionistasController : Controller
    {
        InversionistasAdmin Admin = new InversionistasAdmin();
        // GET: Inversionistas
        public ActionResult Index()
        {
            IEnumerable<Inversionistas> lista = Admin.Consultar();
            return View(lista);
        }
        public ActionResult Guardar()
        {
            ViewBag.mensaje = "";
            return View();
        }
        public ActionResult Nuevo(Inversionistas modelo)
        {
            Admin.Guardar(modelo);
            ViewBag.mensaje = "Inversionista Guardado";
            return View("Guardar", modelo);
        }
        public ActionResult Detalle(int id = 0)
        {
            Inversionistas modelo = Admin.Consultar(id);
            return View(modelo);
        }

        public ActionResult Editar(int id = 0)
        {
            ViewBag.mensaje = "";
            Inversionistas modelo = Admin.Consultar(id);
            return View(modelo);
        }


        public ActionResult Actualizar(Inversionistas modelo)
        {
            Admin.Editar(modelo);
            ViewBag.mensaje = "Inversionista Actualizado";
            return View("Editar", modelo);
        }
        public ActionResult Eliminar(int id = 0)
        {
            ViewBag.mensaje = "";
            Inversionistas modelo = new Inversionistas()
            {
                Id = id
            };
            Admin.Eliminar(modelo);
            IEnumerable<Inversionistas> lista = Admin.Consultar();
            ViewBag.mensaje = "Inversionista Eliminado";
            return View("Index", lista);

        }
    }
}