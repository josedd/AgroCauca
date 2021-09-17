using CrudAgroCauca.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CrudAgroCauca.Data
{
    public class CanastaProductoAdmin
    {
        /// <summary>
        /// Consultar los productos de la canasta
        /// </summary>
        /// <returns>datos del producto de la CanastaProductos</returns>
        public IEnumerable<CanastaProducto> Consultar()
        {
            using (AgroCaucaEntities contexto = new AgroCaucaEntities())
            {
                return contexto.CanastaProducto.AsNoTracking().ToList();
            }
        }
        /// <summary>
        /// Guardar un producto dentro de la canasta de productos
        /// </summary>
        /// <param name="modelo">datos del producto</param>
        public void Guardar(CanastaProducto modelo)
        {
            using (AgroCaucaEntities contexto = new AgroCaucaEntities())
            {
                contexto.CanastaProducto.Add(modelo);
                contexto.SaveChanges();
            }
        }
        /// <summary>
        /// Consulta un producto por id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public CanastaProducto Consultar(int id)
        {
            using (AgroCaucaEntities contexto = new AgroCaucaEntities())
            {
                return contexto.CanastaProducto.FirstOrDefault(v => v.Id == id);
            }
        }
        /// <summary>
        /// Editar un Producto de la canasta
        /// </summary>
        /// <param name="modelo"></param>
        public void Editar(CanastaProducto modelo)
        {
            using (AgroCaucaEntities contexto = new AgroCaucaEntities())
            {

                contexto.Entry(modelo).State = System.Data.Entity.EntityState.Modified;
                contexto.SaveChanges();
            }
        }
        /// <summary>
        /// Eliminacion del producto
        /// </summary>
        /// <param name="modelo"></param>
        public void Eliminar(CanastaProducto modelo)
        {
            using (AgroCaucaEntities contexto = new AgroCaucaEntities())
            {
                contexto.Entry(modelo).State = System.Data.Entity.EntityState.Deleted;
                contexto.SaveChanges();
            }
        }
    }
}