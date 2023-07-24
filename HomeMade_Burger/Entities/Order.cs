namespace HomeMade_Burger.Models
{
    public class Order
    {
        public Order()
        {
            OrderDetails = new HashSet<OrderDetail>();
            OrderDate = DateTime.Now;
        }

        public int OrderID { get; set; }
        public bool IsOrderApproved { get; set; } = false;
        public DateTime OrderDate { get; set; }

        // User Navigation Properties
        public string UserID { get; set; }
        public User User { get; set; }

        // OrderDetail Navigation Properties
        public ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
