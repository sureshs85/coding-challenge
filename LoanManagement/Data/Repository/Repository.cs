using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Collections.Generic;
using System.Data;

namespace LoanManagement.Data.Repository
{
    public abstract class Repository<T> where T : class
    {
        protected abstract string GetQuery { get; }
        protected abstract string GetAllQuery { get; }
        protected Database Database { get; set; }

        protected Repository()
        {
            DatabaseProviderFactory factory = new DatabaseProviderFactory(ConfigurationSource.GenerateConfiguration());
            Database = factory.CreateDefault();
        }
        public virtual T Populate(IDataReader reader)
        {
            return null;
        }
        public IEnumerable<T> GetAll()
        {
            System.Data.Common.DbCommand command = Database.GetSqlStringCommand(GetAllQuery);
            List<T> list = new List<T>();
            using (IDataReader dataReader = Database.ExecuteReader(command))
            {
                while (dataReader.Read())
                {
                    list.Add(Populate(dataReader));
                }
            }
            return list;
        }
        public T Get(int id)
        {
            System.Data.Common.DbCommand command = Database.GetSqlStringCommand(GetQuery);
            System.Data.Common.DbParameter param = command.CreateParameter();
            param.ParameterName = "@id";
            param.Value = id;
            command.Parameters.Add(param);

            T record = null;
            using (IDataReader dataReader = Database.ExecuteReader(command))
            {
                while (dataReader.Read())
                {
                    record = Populate(dataReader);
                    break;
                }
            }
            return record;
        }
    }

}