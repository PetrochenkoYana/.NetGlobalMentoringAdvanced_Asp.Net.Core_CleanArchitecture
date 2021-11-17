namespace Domain.Models
{
    public class ItemsRequest
    {
        public int? CategoryId { get; set; }

        public int? Size { get; set; }

        public int StartAt { get; set; }
    }
}