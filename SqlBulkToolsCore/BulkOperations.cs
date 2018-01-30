using System;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace SqlBulkToolsCore
{
    /// <summary>
    /// 
    /// </summary>
    public class BulkOperations : IBulkOperations
    {
        private ITransaction _transaction;
        private const string SourceAlias = "Source";
        private const string TargetAlias = "Target";

        private readonly string _connectionString;
        public BulkOperations(string connectionString)
        {
            _connectionString = connectionString;
        }

        internal void SetBulkExt(ITransaction transaction)
        {
            _transaction = transaction;
        }

        /// <summary>
        /// Commits a transaction to database. A valid setup must exist for operation to be 
        /// successful. Notes: (1) The connectionName parameter is a name that you provide to 
        /// uniquely identify a connection string so that it can be retrieved at run time.
        /// </summary>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="InvalidOperationException"></exception>
        public void CommitTransaction()
        {
            if (_transaction == null)
                throw new InvalidOperationException("No setup found. Use the Setup method to build a new setup then try again.");
            

            _transaction.CommitTransaction(_connectionString);
        }

        /// <summary>
        /// Commits a transaction to database. A valid setup must exist for operation to be 
        /// successful. Notes: (1) The connectionName parameter is a name that you provide to 
        /// uniquely identify a connection string so that it can be retrieved at run time.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="InvalidOperationException"></exception>
        public async Task CommitTransactionAsync()
        {
            if (_transaction == null)
                throw new InvalidOperationException("No setup found. Use the Setup method to build a new setup then try again.");

            await _transaction.CommitTransactionAsync(_connectionString);
        }


        /// <summary>
        /// Commits a transaction to database. A valid setup must exist for operation to be 
        /// successful. 
        /// </summary>
        /// <param name="connection"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public void CommitTransaction(SqlConnection connection)
        {
            if (connection == null)
                throw new ArgumentNullException(nameof(connection));

            if (_transaction == null)
                throw new InvalidOperationException("No setup found. Use the Setup method to build a new setup then try again.");

            _transaction.CommitTransaction(connection : connection);

        }


        /// <summary>
        /// Commits a transaction to database. A valid setup must exist for operation to be 
        /// successful. 
        /// </summary>
        /// <param name="connection"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="InvalidOperationException"></exception>
        public async Task CommitTransactionAsync(SqlConnection connection)
        {
            if (connection == null)
                throw new ArgumentNullException(nameof(connection));

            if (_transaction == null)
                throw new InvalidOperationException("No setup found. Use the Setup method to build a new setup then try again.");

            await _transaction.CommitTransactionAsync(connection : connection);
        }

        /// <summary>
        /// Each transaction requires a valid setup. Examples available at: https://github.com/gtaylor44/SqlBulkTools 
        /// </summary>
        /// <typeparam name="T">The type of collection to be used.</typeparam>
        /// <param name="list"></param>
        /// <returns></returns>
        public CollectionSelect<T> Setup<T>(Func<Setup<T>, CollectionSelect<T>> list)
        {
            CollectionSelect<T> tableSelect = list(new Setup<T>(SourceAlias, TargetAlias, this));
            return tableSelect;
        }
    }
}