using Dapper;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.GenericRepo
{
    public interface IDapper : IDisposable
    {
        List<T> GetAll<T>(string sp);

    }
    public class Dapperr : IDapper
    {
        private readonly IConfiguration _config;

        public Dapperr(IConfiguration config)
        {
            _config = config;
        }
        public void Dispose()
        {

        }


        public List<T> GetAll<T>(string ModelEntity)
        {
            var sqlQuery = $@"Select * from {ModelEntity}";
            string connectionString = _config.GetConnectionString("DefaultConnection");
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {

                return connection.Query<T>(sqlQuery).ToList();

            }
        }

        public List<T> GetAllInPaging<T>(int skip, int take, string ModelEntity)
        {

            var sqlQuery = $@"SELECT * FROM {ModelEntity}
                           ORDER BY Id OFFSET {skip} 
                           ROWS FETCH NEXT {take} ROWS ONLY";
            string connectionString = _config.GetConnectionString("DefaultConnection");
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {

                return connection.Query<T>(sqlQuery).ToList();

            }
        }

    }
}
