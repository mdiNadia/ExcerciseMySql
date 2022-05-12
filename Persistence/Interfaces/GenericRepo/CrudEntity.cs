using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using Persistence;
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
    public interface ICrudEntity<TEntity> where TEntity : class
    {

        IQueryable<TEntity> GetQueryList();



    }
    public class CrudEntity<TEntity> : ICrudEntity<TEntity> where TEntity : class
    {
        private readonly IConfiguration _config;
        private readonly DataContext _context;
        internal DbSet<TEntity> dbSet;

        public CrudEntity(IConfiguration config, DataContext context)
        {
            this._config = config;
            this._context = context;
            this.dbSet = _context.Set<TEntity>();


        }

        public IQueryable<TEntity> GetQueryList()
        {
            return dbSet;
        }
    }
}
