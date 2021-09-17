using CrudAgroCauca.Data;
using CrudAgroCauca.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CrudASPNETAgroCauca.Controllers
{
    public class OrganizacionesController : Controller
    {
        OrganizacionesAdmin Admin = new OrganizacionesAdmin();
        // GET: Organizaciones
        public ActionResult Index()
        {
            IEnumerable<Organizaciones> lista = Admin.Consultar();
            return View(lista);
        }
        public ActionResult Guardar()
        {
            ViewBag.mensaje = "";
            return View();
        }
        public ActionResult Nuevo(Organizaciones modelo)
        {
            Admin.Guardar(modelo);
            ViewBag.mensaje = "Organizacion Guardada";
            return View("Guardar", modelo);
        }
        public ActionResult Detalle(int id = 0)
        {
            Organizaciones modelo = Admin.Consultar(id);
            return View(modelo);
        }

        public ActionResult Editar(int id = 0)
        {
            ViewBag.mensaje = "";
            Organizaciones modelo = Admin.Consultar(id);
            return View(modelo);
        }


        public ActionResult Actualizar(Organizaciones modelo)
        {
            Admin.Editar(modelo);
            ViewBag.mensaje = "Producto Actualizado";
            return View("Editar", modelo);
        }
        public ActionResult Eliminar(int id = 0)
        {
            ViewBag.mensaje = "";
            Organizaciones modelo = new Organizaciones()
            {
                Id = id
            };
            Admin.Eliminar(modelo);
            IEnumerable<Organizaciones> lista = Admin.Consultar();
            ViewBag.mensaje = "Inversionista Eliminado";
            return View("Index", lista);

        }
    }
}