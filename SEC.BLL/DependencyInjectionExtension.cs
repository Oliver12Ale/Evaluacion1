using Unity.Extension;
using Unity;
using Sec.Dal.Interfaces;
using Sec.Dal.Servicios;
using SEC.DAL.Interfaces;
using SEC.DAL.Servicios;

namespace SEC.BLL
{
    public class DependencyInjectionExtension: UnityContainerExtension
    {
        protected override void Initialize()
        {
            Container.RegisterType(typeof(IAsyncRepository<>), typeof(AsyncRepository<>));
            Container.RegisterType(typeof(IPreguntasRepository<>), typeof(PreguntasRepository<>));

        }
    }
}
