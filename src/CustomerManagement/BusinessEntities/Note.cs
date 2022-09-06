using System.ComponentModel.DataAnnotations;

namespace CustomerManagement.BusinessEntities
{
    public class Note
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        [Required]
        [StringLength(255)]
        public string NoteText { get; set; } = string.Empty;
    }
}
