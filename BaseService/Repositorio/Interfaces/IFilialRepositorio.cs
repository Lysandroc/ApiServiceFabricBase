using Base.Infraestrutura.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BaseService.Repositorio.Interfaces
{
    public interface IFilialRepositorio
    {
        Task<Filial> BuscarFilial();
    }
}
