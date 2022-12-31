namespace ApiDemo.DataAccess
{
    public interface IDapperORM
    {
        public IEnumerable<T> ReturnList<T, U>(string query, U param);
        IEnumerable<TResult> ReturnList<TFirst, TSecond, TResult, U>(string procedureName, Func<TFirst, TSecond, TResult> map, U param);

    }
}
