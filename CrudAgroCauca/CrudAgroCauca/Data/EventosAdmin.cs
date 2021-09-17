using CrudAgroCauca.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CrudAgroCauca.Data
{
    public class EventosAdmin
    {
        /// <summary>
        /// Consultar los eventos
        /// </summary>
        /// <returns>datos del evento a consultar</returns>
        public IEnumerable<Eventos> Consultar()
        {
            using (AgroCaucaEntities contexto = new AgroCaucaEntities())
            {
                return contexto.Eventos.AsNoTracking().ToList();
            }
        }
        /// <summary>
        /// Guardar un evento dentro de la base de datos
        /// </summary>
        /// <param name="modelo">Datos del evento</param>
        public void Guardar(Eventos modelo)
        {
            using (AgroCaucaEntities contexto = new AgroCaucaEntities())
            {
                contexto.Eventos.Add(modelo);
                contexto.SaveChanges();
            }
        }
        /// <summary>
        /// Consulta un Evento por una id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Eventos Consultar(int id)
        {
            using (AgroCaucaEntities contexto = new AgroCaucaEntities())
            {
                return contexto.Eventos.FirstOrDefault(v => v.Id == id);
            }
        }
        /// <summary>
        /// Editar un evento 
        /// </summary>
        /// <param name="modelo"></param>
        public void Editar(Eventos modelo)
        {
            using (AgroCaucaEntities contexto = new AgroCaucaEntities())
            {
                contexto.Entry(modelo).State = System.Data.Entity.EntityState.Modified;
                contexto.SaveChanges();
            }
        }
        /// <summary>
        /// Eliminacion del evento
        /// </summary>
        /// <param name="modelo"></param>
        public void Eliminar(Eventos modelo)
        {
            using (AgroCaucaEntities contexto = new AgroCaucaEntities())
            {
                contexto.Entry(modelo).State = System.Data.Entity.EntityState.Deleted;
                contexto.SaveChanges();
            }
        }
    }
}