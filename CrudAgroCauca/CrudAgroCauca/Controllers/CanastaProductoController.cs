using CrudAgroCauca.Data;
using CrudAgroCauca.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CrudAgroCauca.Controllers
{
   
        public class CanastaProductoController : Controller
        {
            CanastaProductoAdmin Admin = new CanastaProductoAdmin();
            // GET: CanastaProducto
            public ActionResult Index()
            {
                IEnumerable<CanastaProducto> lista = Admin.Consultar();
                return View(lista);
            }
            public ActionResult Guardar()
            {
                ViewBag.mensaje = "";
                return View();
            }
            public ActionResult Nuevo(CanastaProducto modelo)
            {
                Admin.Guardar(modelo);
                ViewBag.mensaje = "Producto Guardado";
                return View("Guardar", modelo);
            }
            public ActionResult Detalle(int id = 0)
            {
                CanastaProducto modelo = Admin.Consultar(id);
                return View(modelo);
            }

            public ActionResult Editar(int id = 0)
            {
                ViewBag.mensaje = "";
                CanastaProducto modelo = Admin.Consultar(id);
                return View(modelo);
            }

            public ActionResult Actualizar(CanastaProducto modelo)
            {
                Admin.Editar(modelo);
                ViewBag.mensaje = "Producto Actualizado";
                return View("Editar", modelo);
            }
            public ActionResult Eliminar(int id = 0)
            {
                ViewBag.mensaje = "";
                CanastaProducto modelo = new CanastaProducto()
                {
                    Id = id
                };
                Admin.Eliminar(modelo);
                IEnumerable<CanastaProducto> lista = Admin.Consultar();
                ViewBag.mensaje = "Producto Eliminado";
                return View("Index", lista);

            }

        }
    }
