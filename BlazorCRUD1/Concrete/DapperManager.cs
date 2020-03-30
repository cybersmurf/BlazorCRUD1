using BlazorCRUD1.Contracts;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;

namespace BlazorCRUD1.Concrete
{
    public class DapperManager : IDapperManager
    {
        private readonly IConfiguration _config;
        public DapperManager(IConfiguration config)
        {
            _config = config;
        }

        public DbConnection GetConnection()
        {
            return new MySqlConnection(_config.GetConnectionString("DefaultConnection"));
        }

        public T Get<T>(string sp, DynamicParameters parms, CommandType commandType = CommandType.StoredProcedure)
        {
            using IDbConnection db = new MySqlConnection(_config.GetConnectionString("DefaultConnection"));
            return db.Query<T>(sp, parms, commandType: commandType).FirstOrDefault();
        }

        public List<T> GetAll<T>(string sp, DynamicParameters parms, CommandType commandType = CommandType.StoredProcedure)
        {
            using IDbConnection db = new MySqlConnection(_config.GetConnectionString("DefaultConnection"));
            return db.Query<T>(sp, parms, commandType: commandType).ToList();
        }

        public int Execute(string sp, DynamicParameters parms, CommandType commandType = CommandType.StoredProcedure)
        {
            using IDbConnection db = new MySqlConnection(_config.GetConnectionString("DefaultConnection"));
            return db.Execute(sp, parms, commandType: commandType);
        }

        public T Insert<T>(string sp, DynamicParameters parms, CommandType commandType = CommandType.StoredProcedure)
        {
            T result;
            using IDbConnection db = new MySqlConnection(_config.GetConnectionString("DefaultConnection"));
            try
            {
                if (db.State == ConnectionState.Closed)
                    db.Open();
                //string insertQuery = @"INSERT INTO c_order (name,note) VALUES (@Name,@Note);";
                result = db.Query<T>(sp, parms, commandType: commandType).FirstOrDefault();

                /*               using var tran = db.BeginTransaction();
                               try
                               {
                                   result = db.Query<T>(sp, parms, commandType: commandType).FirstOrDefault();
                   //                tran.Commit();
                               }
                               catch (Exception ex)
                               {
                   //                tran.Rollback();
                                   throw ex;
                               }
                  */         } 

                           catch (Exception ex)
                           {
                               throw ex;
                           }
                           finally
                           {
                               if (db.State == ConnectionState.Open)
                                   db.Close();
                           }
               
                return result;
        }

        public T Update<T>(string sp, DynamicParameters parms, CommandType commandType = CommandType.StoredProcedure)
        {
            T result;
            using IDbConnection db = new MySqlConnection(_config.GetConnectionString("DefaultConnection"));
            try
            {
                if (db.State == ConnectionState.Closed)
                    db.Open();

                using var tran = db.BeginTransaction();
                try
                {
                    result = db.Query<T>(sp, parms, commandType: commandType, transaction: tran).FirstOrDefault();
                    tran.Commit();
                }
                catch (Exception ex)
                {
                    tran.Rollback();
                    throw ex;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (db.State == ConnectionState.Open)
                    db.Close();
            }

            return result;
        }


        public void Dispose()
        {

        }
    }
}
