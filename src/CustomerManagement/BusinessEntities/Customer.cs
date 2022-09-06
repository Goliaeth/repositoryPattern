using System;
using System.ComponentModel.DataAnnotations;

namespace CustomerManagement.BusinessEntities
{
    public class Customer
    {
        public int Id { get; set; }
        [StringLength(50)]
        public string FirstName { get; set; }
        [Required]
        [StringLength(50)]
        public string LastName { get; set; } = string.Empty;
        [Phone]
        [MaxLength(15)]
        public string PhoneNumber { get; set; }
        [EmailAddress]
        [MaxLength(255)]
        public string Email { get; set; } = string.Empty;
        [Range(0, Int32.MaxValue)]
        public decimal? TotalPurchasesAmount { get; set; }

    }
}
