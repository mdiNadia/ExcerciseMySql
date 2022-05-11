using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;

namespace Persistence
{
    public class Seed
    {

        public static async Task SeedData(DataContext context, IConfiguration configuration)
        {
            //if (!context.ExcerciseEntities.Any())
            //{
            //    var list = new List<ExcerciseEntity>();

            //    for (var i = 0; i < 15000; i++)
            //    {
            //        context.ExcerciseEntities.Add(new ExcerciseEntity {  CreateDate = new DateTime(), SerialNumber = "s" + i, DeviceId = 1 + i + 1, IdEvent = 1 + i + 2, IdMachine = 1 + i + 3, RefId = 1 + i + 4 });
            //    };


            //    await context.SaveChangesAsync();

            //}
            if (!context.ExcerciseEntities.Any())
            {
                string connectionString = configuration.GetConnectionString("DefaultConnection");
                MySqlConnection connection = new MySqlConnection(connectionString);
                string targetFolder = Path.Combine("../Application", "Queries", "test.sql");
                FileInfo file = new FileInfo(targetFolder);
                using (connection)
                {
                    string sqlQuery = file.OpenText().ReadToEnd();
                    MySqlCommand cmd = new MySqlCommand(sqlQuery, connection);
                    await connection.OpenAsync();
                    await cmd.ExecuteReaderAsync();
                    await connection.CloseAsync();
                }
            }


        }


    }



}

