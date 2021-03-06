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

namespace Persistence.Interfaces.GenericRepo
{
    public interface ICrudDapper : IDisposable
    {
        List<T> GetAll<T>(string sp);
        Task<string> DeleteAll(string sp);



    }
    public class CrudDapper : ICrudDapper
    {
        private readonly IConfiguration _config;


        public CrudDapper(IConfiguration config)
        {
            this._config = config;
        }

        public void Dispose()
        {

        }


        public List<T> GetAll<T>(string ModelEntity)
        {
            string connectionString = _config.GetConnectionString("DefaultConnection");
            var sqlQuery = $@"Select * from {ModelEntity}";
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {

                return connection.Query<T>(sqlQuery).ToList();

            }
        }

        public List<T> GetAllInPaging<T>(int skip, int take, string ModelEntity)
        {
            string connectionString = _config.GetConnectionString("DefaultConnection");

            var sqlQuery = $@"SELECT * FROM {ModelEntity}
                           ORDER BY Id OFFSET {skip} 
                           ROWS FETCH NEXT {take} ROWS ONLY";
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {

                return connection.Query<T>(sqlQuery).ToList();

            }
        }

        public async Task<string> DeleteAll(string ModelEntity)
        {
            string connectionString = _config.GetConnectionString("DefaultConnection");
            var sqlQuery = $@"delete from {ModelEntity}";


            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                return connection.Execute(sqlQuery).ToString();




            }
        }


    }
}
