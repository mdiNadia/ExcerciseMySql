using Domain;
using Microsoft.EntityFrameworkCore;
using MySql.Data.MySqlClient;
using Persistence.Fluents;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence
{
    [DbConfigurationType(typeof(MySqlConfiguration))]
    public class DataContext: Microsoft.EntityFrameworkCore.DbContext
    {
        public DataContext(DbContextOptions options) : base(options) {

        }



        public Microsoft.EntityFrameworkCore.DbSet<ExcerciseEntity> ExcerciseEntities { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfiguration<ExcerciseEntity>(new ExcerciseEntityFluent());
            


        }
    }

    
}
