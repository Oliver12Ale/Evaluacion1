using Sec.Bll.Servicios;
using Sec.Dal.Interfaces;
using SEC.BLL.Intefaces;
using SEC.DAL.Interfaces;
using SEC.ENTITI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEC.BLL.Servicios
{
    public class PreguntasService<T> : Service<T>, IPreguntasService<T> where T : Preguntas
    {
        public PreguntasService(IPreguntasRepository<T> repository) : base(repository)
        {
        }
    }
}
