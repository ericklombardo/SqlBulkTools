using System;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace SqlBulkToolsCore
{
    /// <summary>
    /// 
    /// </summary>
    public interface IBulkOperations
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="connection"></param>
        void CommitTransaction(SqlConnection connection);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="connection"></param>
        /// <returns></returns>
        Task CommitTransactionAsync(SqlConnection connection);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="connectionString"></param>
        void CommitTransaction(string connectionString);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="connectionString"></param>
        /// <returns></returns>
        Task CommitTransactionAsync(string connectionString);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="list"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        CollectionSelect<T> Setup<T>(Func<Setup<T>, CollectionSelect<T>> list);
    }
}