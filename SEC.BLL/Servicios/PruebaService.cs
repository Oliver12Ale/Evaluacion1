using Sec.Bll.Servicios;
using Sec.Dal.Interfaces;
using SEC.BLL.Intefaces;
using SEC.ENTITI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEC.BLL.Servicios
{
    class PruebaService<T> : Service<T>, IPruebaService<T> where T : Pruebas
    {
        public PruebaService(IAsyncRepository<T> repository) : base(repository)
        {
        }
    }
}
