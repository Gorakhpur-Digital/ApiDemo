using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace ApiDemo.DataAccess
{
    public class DapperORM : IDapperORM
    {
        private readonly IConfiguration _config;

        public DapperORM(IConfiguration config)
        {
            _config = config;
        }
        public IEnumerable<T> ReturnList<T, U>(string procedureName, U param)
        {
            using (IDbConnection sqlCon = new SqlConnection(_config.GetConnectionString("default")))
            {
                return sqlCon.Query<T>(procedureName, param, commandType: CommandType.StoredProcedure);
            }
        }
        public IEnumerable<TResult> ReturnList<TFirst, TSecond, TResult, U>(string procedureName, Func<TFirst, TSecond, TResult> map, U param)
        {
            using (IDbConnection sqlCon = new SqlConnection(_config.GetConnectionString("default")))
            {
                return sqlCon.Query<TFirst, TSecond, TResult>(procedureName, map, param, commandType: CommandType.StoredProcedure);
            }
        }
    }
}
