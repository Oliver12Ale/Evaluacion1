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
    public class NivelesService<T> : Service<T>, INivelesService<T> where T : Niveles
    {
        public NivelesService(IAsyncRepository<T> repository) : base(repository)
        {
        }
    }
}
