namespace LoanManagement.Data.Repository
{
    using Microsoft.Practices.EnterpriseLibrary.Data;
    using MySql.Data.MySqlClient;
    using System;
    using System.Collections.Generic;
    using System.Data;

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
        /// <summary>
        /// Generic method to retrieve all the entities
        /// </summary>
        /// <returns>List of entities</returns>
        public IEnumerable<T> GetAll()
        {
            List<T> list = new List<T>();
            try
            {
                System.Data.Common.DbCommand command = Database.GetStoredProcCommand(GetAllQuery);
                using (IDataReader dataReader = Database.ExecuteReader(command))
                {
                    while (dataReader.Read())
                    {
                        list.Add(Populate(dataReader));
                    }
                }
                return list;
            }
            catch (MySqlException myEx)
            {
                Logger.Instance.Log(myEx);
                throw myEx;
            }
            catch (Exception ex)
            {
                Logger.Instance.Log(ex);
                throw ex;
            }

        }
        /// <summary>
        /// Generic method to retrieve one single entity with Id
        /// </summary>
        /// <returns>single entity</returns>
        public T Get(int id)
        {
            T record = null;
            try
            {
                System.Data.Common.DbCommand command = Database.GetStoredProcCommand(GetQuery);
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
            catch (MySqlException myEx)
            {
                Logger.Instance.Log(myEx);
                throw myEx;
            }
            catch (Exception ex)
            {
                Logger.Instance.Log(ex);
                throw ex;
            }
        }
    }

}