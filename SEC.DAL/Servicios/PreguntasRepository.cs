using Sec.Dal.Servicios;
using SEC.DAL.Interfaces;
using SEC.ENTITI;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEC.DAL.Servicios
{
    public class PreguntasRepository<T> : AsyncRepository<T>, IPreguntasRepository<T> where T : Preguntas
    {
        public PreguntasRepository(EvaluacionEntities context) : base(context)
        {
        }

        public override async Task<T> SearchById(int id)
        {
            return await EntitySet.Where(p => p.IdPregunta == id).Include(opns => opns.Opciones).FirstOrDefaultAsync();

        }

        public override async Task Update(T entity)
        {
            var pregunta = await SearchById(entity.IdPregunta);
            var preguntaEntry = context.Entry(pregunta);
            preguntaEntry.CurrentValues.SetValues(entity);

            foreach (var newopcion in entity.Opciones) {
                var opcion = pregunta.Opciones.Where(op => op.IdOpcion == newopcion.IdOpcion).SingleOrDefault();
               
                if (opcion != null)
                {
                 
                    var opcionEntry = context.Entry(opcion);
                    opcionEntry.CurrentValues.SetValues(newopcion);
                   
                }
                else {
                    pregunta.Opciones.Add(newopcion);
                }
                /*if (pregunta.Opciones.Where(ac => ac.Activo == false).SingleOrDefault();)
                {

                }*/
            }
            
            await context.SaveChangesAsync();
        }
    }
}
