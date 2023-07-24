using Microsoft.AspNetCore.Identity;

namespace HomeMade_Burger.Models
{
    public class User : IdentityUser
    {
        public User()
        {
            Orders = new HashSet<Order>();
        }

        // Order Navigation Properties
        public ICollection<Order> Orders { get; set; }
    }
}
