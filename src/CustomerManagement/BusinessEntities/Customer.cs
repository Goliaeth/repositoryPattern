namespace CustomerManagement.BusinessEntities
{
    public class Customer
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; } = string.Empty;
        public string PhoneNumber { get; set; }
        public string Email { get; set; } = string.Empty;
        public decimal TotalPurchasesAmount { get; set; }

    }
}
