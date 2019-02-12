using System;

namespace LoanManagement.Data
{
    public static class DbUtility
    {
        public static T GetValue<T>(this object obj)
        {
            if (typeof(DBNull) != obj.GetType())
            {
                return (T)Convert.ChangeType(obj, typeof(T));
            }
            return default(T);
        }
    }
}