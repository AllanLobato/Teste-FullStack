namespace LeadManager.Api.Models
{
    public class Lead
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string FullName { get; set; } = string.Empty;
        public string Suburb { get; set; } = string.Empty;
        public string Category { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public string Phone { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public string Status { get; set; } = "invited";
    }
}
