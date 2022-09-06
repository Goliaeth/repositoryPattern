using System.ComponentModel.DataAnnotations;

namespace CustomerManagement.BusinessEntities
{
    public class Address
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        [Required]
        [StringLength(100)]
        public string AddressLine { get; set; } = string.Empty;
        [StringLength(100)]
        public string AddressLine2 { get; set; }
        [RegularExpression("^Shipping|Billing$")]
        public string AddressType { get; set; } = string.Empty;
        [StringLength(50)]
        public string City { get; set; } = string.Empty;
        [MinLength(4)]
        [MaxLength(6)]
        [RegularExpression("^[0-9]*$")]
        public string PostalCode { get; set; } = string.Empty;
        [StringLength(20)]
        public string State { get; set; } = string.Empty;
        [StringLength(100)]
        [RegularExpression("^United States|Canada$")]
        public string Country { get; set; } = string.Empty;
    }
}
