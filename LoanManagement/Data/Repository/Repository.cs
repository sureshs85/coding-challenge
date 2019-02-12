using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
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
            List<T> list = new List<T>();
            try
            {
                System.Data.Common.DbCommand command = Database.GetSqlStringCommand(GetAllQuery);
                using (IDataReader dataReader = Database.ExecuteReader(command))
                {
                    while (dataReader.Read())
                    {
                        list.Add(Populate(dataReader));
                    }
                }
                return list;
            }
            catch (Exception ex)
            {
                Logger.Instance.Log(ex);
            }
            return list;

        }
        public T Get(int id)
        {
            T record = null;
            try
            {
                System.Data.Common.DbCommand command = Database.GetSqlStringCommand(GetQuery);
                System.Data.Common.DbParameter param = command.CreateParameter();
                param.ParameterName = "@id";
                param.Value = id;
                command.Parameters.Add(param);


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
            catch (Exception ex)
            {
                Logger.Instance.Log(ex);
            }
            return record;
        }
    }

}