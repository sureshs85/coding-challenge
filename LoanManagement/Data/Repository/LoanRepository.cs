namespace LoanManagement.Data.Repository
{
    using Data.Const;
    using Data.Model;
    using System;
    using System.Data;

    public class LoanRepository : Repository<LoanModel>
    {
        protected override string GetQuery => LoanConst.GetQuery;
        protected override string GetAllQuery => LoanConst.GetAllQuery;

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
            }
            return new LoanModel();
        }
    }
}