using Sec.Dal.Interfaces;
using SEC.ENTITI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEC.DAL.Interfaces
{
    public interface IPreguntasRepository<T> : IAsyncRepository<T> where T :Preguntas
    {

    }
}
