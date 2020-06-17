using Sec.Bll.Interfaces;
using Sec.Dal.Interfaces;
using SEC.ENTITI;
using System;
using System.Threading.Tasks;

namespace Sec.Bll.Servicios
{
    public class UsuariosService<T>: Service<T>, IUsuariosService<T> where T : Usuarios
    {
        public UsuariosService(IAsyncRepository<T> repository) : base(repository)
        {

        }
        public override async Task<T> Add(T reg)
        {
            reg.FechaCreacion = DateTime.Now;
            return await _repository.Add(reg);
        }
    }
}
