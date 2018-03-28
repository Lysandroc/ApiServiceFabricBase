using Microsoft.ServiceFabric.Services.Remoting;
using System.Threading.Tasks;

namespace Base.Infraestrutura.Interfaces
{
    public interface IBaseService : IService
    {
        Task<string> Get();
    }

    public interface IBaseService1 : IService
    {
        Task<string> Get(string name, object[] args);
    }
}
