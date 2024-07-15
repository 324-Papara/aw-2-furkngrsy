namespace Para.Schema.Models
{
    public class CustomerDetail
    {
        public long Id { get; set; }
        public long CustomerId { get; set; }
        public Customer Customer { get; set; }

        public string FatherName { get; set; }
        public string MotherName { get; set; }
        public string EducationStatus { get; set; }
        public string MontlyIncome { get; set; }
        public string Occupation { get; set; }
    }
}
