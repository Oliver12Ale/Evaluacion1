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
    public class TecnologiasService<T> : Service<T>, ITecnologiasService<T> where T : Tecnologias
    {
        public TecnologiasService(IAsyncRepository<T> repository) : base(repository)
        {
        }
    }
}
