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
        Task<string> DeleteAll(string sp);
        List<T> GetReportData<T>(string sp, string filterField, string filterValue, string selectedField);



    }
    public class Dapperr : IDapper
    {
        private readonly IConfiguration _config;


        public Dapperr(IConfiguration config)
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
        public List<T> GetReportData<T>(string ModelEntity, string filterField, string filterValue,string selectedField)
        {
            string connectionString = _config.GetConnectionString("DefaultConnection");
            var sqlQuery = $@"SELECT {selectedField} FROM {ModelEntity} USE INDEX ({filterField}) where {filterField}={filterValue}
                           ORDER BY Id";
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {

                return connection.Query<T>(sqlQuery).ToList();

            }
        }

    }
}
