using Microsoft.AspNetCore.Identity;

namespace Entities.Models
{
    public class Role: IdentityRole
    {
        public Role() : base() { }

        public Role(string roleName) : base(roleName) { }
    }
}
