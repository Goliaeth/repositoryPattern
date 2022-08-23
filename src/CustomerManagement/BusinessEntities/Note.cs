namespace CustomerManagement.BusinessEntities
{
    public class Note
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public string? NoteText { get; set; } = string.Empty;
    }
}
