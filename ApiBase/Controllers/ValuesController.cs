using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.ServiceFabric.Services.Remoting.Client;
using Base.Infraestrutura.Interfaces;
using Microsoft.AspNetCore.Cors;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net;

namespace ApiBase.Controllers
{
    /// <summary>
    /// Controle base de valores.
    /// </summary>
    [EnableCors("AllowAll")]
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        /// <summary>
        /// Variavel de ambiente do logger
        /// </summary>
        public ILogger logger { get; set; }

        /// <summary>
        /// Injeta o logger.
        /// </summary>
        /// <param name="loggerFactory"></param>
        public ValuesController(ILoggerFactory loggerFactory)
        {
            logger = loggerFactory.CreateLogger<ValuesController>();
        }

        /// <summary>
        /// Adicionar comentário do método
        /// </summary>
        /// <returns>retorna array de valores</returns>
        [ProducesResponseType(typeof(IEnumerable<string>), 200)]
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            try
            {
                Response.ContentType = "application/json";

                var param = ServiceProxy.Create<IBaseService>(new Uri("fabric:/ENG_RT_SERVICEFABRIC_BASE/BaseService"));

                var obj = await param.Get();

                return Ok(obj);
            }
            catch (Exception ex)
            {
                var e = ex.GetBaseException();
                logger.LogError(1000, $"{e.Message} \n Exception: {e.StackTrace}");

                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// Método para testar o cultureInfo do projeto.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("[action]")]
        public string GetCultureInfo()
        {
            var a = Thread.CurrentThread.CurrentCulture;
            return a.DisplayName;
        }
        
    }
}
