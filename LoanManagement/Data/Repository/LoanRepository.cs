namespace LoanManagement.Data.Repository
{
    using Data.Const;
    using Data.Model;
    using Interface;
    using System;
    using System.Data;

    public class LoanRepository : Repository<LoanModel>, ILoanRepository
    {
        protected override string GetQuery => LoanConst.GetQuery;
        protected override string GetAllQuery => LoanConst.GetAllQuery;
        /// <summary>
        /// Method is to bind the value of the Loan Modal object retrieved from DB
        /// </summary>
        /// <param name="reader"></param>
        /// <returns>LoanModel object</returns>
        public override LoanModel Populate(IDataReader reader)
        {
            try
            {
                return new LoanModel
                {
                    Id = reader["Id"].GetValue<int>(),
                    LoanName = reader["LoanName"].GetValue<string>(),
                    Balance = reader["Balance"].GetValue<double>(),
                    Interest = reader["Interest"].GetValue<double>(),
                    Payout = reader["Payout"].GetValue<double>(),
                    RepaymentFee = reader["RepaymentFee"].GetValue<double>(),
                    IsExpanded = reader["IsExpanded"].GetValue<bool>(),
                };
            }
            catch (Exception ex)
            {
                Logger.Instance.Log(ex);
                throw new Exception("Error Occurred, Please contact admin...");
            }
        }
    }
}