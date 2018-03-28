using System.Collections.Generic;
using System.Fabric;
using System.Threading.Tasks;
using Microsoft.ServiceFabric.Services.Communication.Runtime;
using Microsoft.ServiceFabric.Services.Runtime;
using Base.Infraestrutura.Interfaces;
using Newtonsoft.Json;
using Microsoft.ServiceFabric.Services.Remoting.FabricTransport.Runtime;
using BaseService.Repositorio.Interfaces;
using System;
using System.Globalization;

namespace BaseService
{
    /// <summary>
    /// The FabricRuntime creates an instance of this class for each service type instance. 
    /// </summary>
    internal sealed class BaseService : StatelessService, IBaseService
    {
        public IFilialRepositorio _repositorio { get; set; }
        public BaseService(StatelessServiceContext context, IFilialRepositorio repositorio)
            : base(context)
        {
            var cultureInfo = new CultureInfo("pt-BR");

            CultureInfo.DefaultThreadCurrentCulture = cultureInfo;
            CultureInfo.DefaultThreadCurrentUICulture = cultureInfo;

            _repositorio = repositorio;            
            string StringConexao = "stringConexao";
            Environment.SetEnvironmentVariable("StringConexao", StringConexao);
        }

        public async Task<string> Get()
        {
            var resp = await _repositorio.BuscarFilial();
            return JsonConvert.SerializeObject(resp);
        }

        /// <summary>
        /// Optional override to create listeners (like tcp, http) for this service instance.
        /// </summary>
        /// <returns>The collection of listeners.</returns>
        protected override IEnumerable<ServiceInstanceListener> CreateServiceInstanceListeners()
        {
            return new[] { new ServiceInstanceListener(context => new FabricTransportServiceRemotingListener(context, this)) };
        }
    }
}
