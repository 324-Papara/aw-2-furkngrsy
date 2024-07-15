namespace Para.Schema.Models
{
    public class CustomerPhone
    {
        public long Id { get; set; }
        public long CustomerId { get; set; }
        public Customer Customer { get; set; }

        public string CountyCode { get; set; }
        public string Phone { get; set; }
        public bool IsDefault { get; set; }
    }
}
