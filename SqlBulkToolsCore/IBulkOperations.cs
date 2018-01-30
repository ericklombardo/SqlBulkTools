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
        void CommitTransaction();

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        Task CommitTransactionAsync();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="list"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        CollectionSelect<T> Setup<T>(Func<Setup<T>, CollectionSelect<T>> list);
    }
}