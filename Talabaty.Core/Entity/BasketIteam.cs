namespace Talabaty.Core.Entity
{
    public class BasketIteam
    {
        public string Id { get; set; }
        public string ProductName { get; set; }  // changed from int to string
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public string PictureUrl { get; set; }   // changed from int to string
        public string Brand { get; set; }
        public string Type { get; set; }
    }
}
// This class represents an item in the customer's basket, with properties for product name, price, quantity, picture URL, brand, and type.