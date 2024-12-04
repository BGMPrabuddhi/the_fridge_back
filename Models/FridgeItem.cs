namespace FridgeAPI.Models
{
    public class FridgeItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime ExpiryDate { get; set; }
    }
}
