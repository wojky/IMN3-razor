namespace WebApp.Models
{
    public class Character
    {
        public int Id { get; set; }
        public string? Name { get; set; }

        public string? Status { get; set; }

        public int LocationId { get; set; }

        // Navigation property
        public Location Location { get; set; }
    }
}
