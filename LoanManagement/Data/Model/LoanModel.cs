namespace LoanManagement.Data.Model
{
    public class LoanModel
    {
        public int Id { get; set; }
        public string LoanName { get; set; }
        public double Balance { get; set; }
        public double Interest { get; set; }
        public double RepaymentFee { get; set; }
        public double Payout { get; set; }
        public bool IsExpanded { get; set; }
    }
}