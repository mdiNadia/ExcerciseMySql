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
            //var sqlQuery = $@"SELECT DeviceId FROM ExcerciseEntities USE INDEX (SerialNumber) where SerialNumber={serial}
            //               ORDER BY DeviceId";
            var sqlQuery = $@"SELECT t.DeviceId,t.FirstDate,t.LastDate,t.IdMachine,t.RefId,t.IdEvent,t.devId,t.idMachin,
                              t.idRef,t.eveId From (
                              SELECT g.DeviceId,g.FirstDate,g.LastDate,g.IdMachine,g.RefId,g.IdEvent
                              ,ROW_NUMBER() OVER (PARTITION BY g.DeviceId ORDER BY g.DeviceId ASC) as devId
                              ,ROW_NUMBER() OVER(PARTITION BY g.DeviceId ORDER BY g.IdEvent ASC) as eveId
                              ,ROW_NUMBER() OVER(PARTITION BY g.DeviceId ORDER BY g.IdMachine DESC) as idMachin
                              ,ROW_NUMBER() OVER(PARTITION BY g.DeviceId ORDER BY g.RefId DESC) as idRef
                              FROM
                              (SELECT
                              e.DeviceId
                              ,e.IdMachine
                              ,e.RefId
                              ,e.IdEvent
                              ,min(cast(e.CreateDate as date)) as FirstDate
                              ,max(cast(e.CreateDate as date)) as LastDate
                              FROM excerciseentities e where SerialNumber={serial}
                              group by DeviceId) as g
                              ) as t";

            string connectionString = _config.GetConnectionString("DefaultConnection");
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                return connection.Query<T>(sqlQuery).ToList();

            }
        }
    }
}
