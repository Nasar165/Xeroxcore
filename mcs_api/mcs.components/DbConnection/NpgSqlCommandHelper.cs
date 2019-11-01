using Npgsql;

namespace mcs.components.DbConnection
{
    public class SqlCommandHelper<T>
    {
        public SqlCommandHelper(T data, params string[] skipProperties)
        {
            Data = data;
            SkipProperties = skipProperties;
        }
        public T Data { get; }
        public string[] SkipProperties { get; set; }
        public NpgsqlCommand SqlCommand { get; set; }
    }
}