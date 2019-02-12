namespace LoanManagement.Data.Const
{
    public struct LoanConst
    {
        public const string GetQuery = "SELECT * FROM Loan WHERE Id = @id";
        public const string GetAllQuery = "SELECT * FROM Loan";
    }
}