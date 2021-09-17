using CrudAgroCauca.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CrudAgroCauca.Data
{
    public class OrganizacionesAdmin
    {
        /// <summary>
        /// Consultar las organizaciones
        /// </summary>
        /// <returns>datos de la organizacion a consultar</returns>
        public IEnumerable<Organizaciones> Consultar()
        {
            using (AgroCaucaEntities contexto = new AgroCaucaEntities())
            {
                return contexto.Organizaciones.AsNoTracking().ToList();
            }
        }
        /// <summary>
        /// Guardar una Organizacion en la base de datos
        /// </summary>
        /// <param name="modelo">datos de la organizacion</param>
        public void Guardar(Organizaciones modelo)
        {

            try
            {
                using (AgroCaucaEntities contexto = new AgroCaucaEntities())
                {
                    contexto.Organizaciones.Add(modelo);
                    contexto.SaveChanges();
                }
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException dbEx)
            {
                Exception raise = dbEx;
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        string message = string.Format("{0}:{1}",
                            validationErrors.Entry.Entity.ToString(),
                            validationError.ErrorMessage);
                        // raise a new exception nesting
                        // the current instance as InnerException
                        raise = new InvalidOperationException(message, raise);
                    }
                }
                throw raise;
            }

        }
        /// <summary>
        /// Consulta una organizacion por una id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Organizaciones Consultar(int id)
        {
            using (AgroCaucaEntities contexto = new AgroCaucaEntities())
            {
                return contexto.Organizaciones.FirstOrDefault(v => v.Id == id);
            }
        }
        /// <summary>
        /// Editar una Organizacion
        /// </summary>
        /// <param name="modelo"></param>
        public void Editar(Organizaciones modelo)
        {
            using (AgroCaucaEntities contexto = new AgroCaucaEntities())
            {
                contexto.Entry(modelo).State = System.Data.Entity.EntityState.Modified;
                contexto.SaveChanges();
            }
        }
        /// <summary>
        /// Eliminar la organizacion
        /// </summary>
        /// <param name="modelo"></param>
        public void Eliminar(Organizaciones modelo)
        {
            using (AgroCaucaEntities contexto = new AgroCaucaEntities())
            {
                contexto.Entry(modelo).State = System.Data.Entity.EntityState.Deleted;
                contexto.SaveChanges();
            }
        }
    }
}