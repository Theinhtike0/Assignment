namespace Product.Data.DataAccess
{
    public interface ISqlDataAccess
    {
        Task<IEnumerable<T>> GetData<T, P>(string spName, P parameters, string connectionid = "conn");
        Task SaveData<T>(string spName, T parameters, string connectionid = "conn");
    }
}