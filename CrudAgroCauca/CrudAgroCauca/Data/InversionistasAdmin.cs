using CrudAgroCauca.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CrudAgroCauca.Data
{
    public class InversionistasAdmin
    {
        /// <summary>
        /// Consultar las organizaciones
        /// </summary>
        /// <returns>datos de la organizacion a consultar</returns>
        public IEnumerable<Inversionistas> Consultar()
        {
            using (AgroCaucaEntities contexto = new AgroCaucaEntities())
            {
                return contexto.Inversionistas.AsNoTracking().ToList();
            }
        }
        /// <summary>
        /// Guardar un inversionista dentro de la base de datos
        /// </summary>
        /// <param name="modelo">datos del inversionista</param>
        public void Guardar(Inversionistas modelo)
        {
            using (AgroCaucaEntities contexto = new AgroCaucaEntities())
            {
                contexto.Inversionistas.Add(modelo);
                contexto.SaveChanges();
            }
        }
        /// <summary>
        /// Consulta a un inversionista por una id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Inversionistas Consultar(int id)
        {
            using (AgroCaucaEntities contexto = new AgroCaucaEntities())
            {
                return contexto.Inversionistas.FirstOrDefault(v => v.Id == id);
            }
        }

        /// <summary>
        /// Editar un Inversionista
        /// </summary>
        /// <param name="modelo"></param>
        public void Editar(Inversionistas modelo)
        {
            using (AgroCaucaEntities contexto = new AgroCaucaEntities())
            {
                contexto.Entry(modelo).State = System.Data.Entity.EntityState.Modified;
                contexto.SaveChanges();
            }
        }
        /// <summary>
        /// Eliminacion del inversionista
        /// </summary>
        /// <param name="modelo"></param>
        public void Eliminar(Inversionistas modelo)
        {
            using (AgroCaucaEntities contexto = new AgroCaucaEntities())
            {
                contexto.Entry(modelo).State = System.Data.Entity.EntityState.Deleted;
                contexto.SaveChanges();
            }
        }
    }
}