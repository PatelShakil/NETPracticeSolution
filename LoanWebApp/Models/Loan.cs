namespace LoanWebApp.Models
{
    public class Loan
    {
        public int LoanId { get; set; }
        public string CustomerName { get; set; }
        public string Gender { get; set; }
        public double PrincipalAmount { get; set; }
        public int NoOfYears { get; set; }
        public double InterestRate{ get; set; }
        public double InterestAmount { get; set; }
    }
}
