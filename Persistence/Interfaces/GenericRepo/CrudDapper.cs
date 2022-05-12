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
        List<T> GetReportData<T>(string sp, string filterField, string filterValue, string selectedField);



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

        /// <summary>
        /// ////فیلتر با پارامترهای ورودی و دپر
        /// ////selectedField => باید لیست یا آرایه‌ای از فیلدهای 
        /// جدول را که بعد اعمال فیلتر میخواهیم برگردانیم
        /// در حال حاضر این ورودی آرایه یا لیست نیست و 
        /// استرینگ است.
        /// بعدا باید لیست بشه و در کوءری قرار گیرد
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="ModelEntity">نام مدل یا جدول ما در دیتابیس</param>
        /// <param name="filterField">فیلدی که میخواهیم بر اساس آن فیلتر صورت گیرد</param>
        /// <param name="filterValue">مقدار یا ورودی فیلدی که بر اساس آن فیلتر صورت میگیرد</param>
        /// <param name="selectedField">لیستی از فیلدهایی که بعد از اعمال فیلتر برگردانده می‌شود</param>
        /// <returns>selectedField</returns>
        public List<T> GetReportData<T>(string ModelEntity, string filterField, string filterValue, string selectedField)
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
