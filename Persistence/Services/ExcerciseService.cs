using Dapper;
using Domain;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using Persistence;
using Persistence.Interfaces;
using Persistence.Interfaces.GenericRepo;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Persistence.Services
{
    public class ExcerciseService : CrudEntity<ExcerciseEntity>, IExcerciseService
    {
        private readonly IConfiguration _config;

        public ExcerciseService(IConfiguration config, DataContext context) : base(config, context)
        {
            this._config = config;
        }



        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="serial"></param>
        /// <returns></returns>
        public List<T> GetReportData<T>(string serial)
        {
            string connectionString = _config.GetConnectionString("DefaultConnection");
            var sqlQuery = $@"SELECT DeviceId FROM ExcerciseEntities USE INDEX (SerialNumber) where SerialNumber={serial}
                           ORDER BY DeviceId";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {

                return connection.Query<T>(sqlQuery).ToList();

            }
        }
    }
}
