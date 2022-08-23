namespace CustomerManagement.BusinessEntities
{
    public class Address
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public string AddressLine { get; set; } = string.Empty;
        public string? AddressLine2 { get; set; }
        public string AddressType { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string PostalCode { get; set; } = string.Empty;
        public string State { get; set; } = string.Empty;
        public string Country { get; set; } = string.Empty;
    }
}
