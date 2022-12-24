namespace ApiDemo.DataAccess
{
    public interface IDapperORM
    {
        public IEnumerable<T> ReturnList<T, U>(string query, U param);
    }
}
