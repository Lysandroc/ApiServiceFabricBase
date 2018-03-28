using Base.Infraestrutura.Models;
using BaseService.Repositorio.Interfaces;
using Dapper.FastCrud;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace BaseService.Repositorio
{
    public class FilialRepositorio : IFilialRepositorio
    {
        public async Task<Filial> BuscarFilial()
        {
            try
            {
                using (var con = new SqlConnection(Environment.GetEnvironmentVariable("StringConexao")))
                {
                    return await con.GetAsync(new Filial { ID = 1 });
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }


    }
}
