using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using Microsoft.Extensions.Configuration;

namespace Persistence
{
    public class Seed
    {

        public static async Task SeedData(DataContext context, IConfiguration configuration)
        {
            if (!context.ExcerciseEntities.Any())
            {
                var list = new List<ExcerciseEntity>();

                for (var i = 0; i < 15000; i++)
                {
                    context.ExcerciseEntities.Add(new ExcerciseEntity {  CreateDate = new DateTime(), SerialNumber = "s" + i, DeviceId = 1 + i + 1, IdEvent = 1 + i + 2, IdMachine = 1 + i + 3, RefId = 1 + i + 4 });
                };

                
                await context.SaveChangesAsync();

            }

        }


    }



}

