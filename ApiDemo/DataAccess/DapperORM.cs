using Dapper;
using Microsoft.Data.SqlClient;
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
    }
}
